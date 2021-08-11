import pickle
import logging
import torch
import torch.distributions
from torch.nn.modules.container import Sequential
import torch.optim
from torch.nn import Linear
import torch.linalg
from functools import partial
import numpy as np
from belief import InfCube, SignSGD,model_explore,model_exploit,EncoderList,Head,SquareErrorTracker
from torch.optim.swa_utils import AveragedModel

from projector import LinearProjector

def neural_create_model(size,dim_head=2 ** 4,dim_emb=2 ** 5):
    proj = LinearProjector(13,27)
    value = EncoderList(0,dim_head,dim_emb,size.value)
    value_head = Head(size.action,dim_head*dim_emb,27)
    policy = EncoderList(0,dim_head,dim_emb,size.policy)
    policy_head = Head(size.action,dim_head*dim_emb,1)
    return proj.cuda(), value.cuda(), value_head.cuda(), policy.cuda(), policy_head.cuda()

def neural_player(neural,tracker,modules,model_fun=model_exploit,is_update_value=False,is_update_policy=False): 
    return neural.handler(partial(model_fun,tracker,*modules,is_update_value,is_update_policy))

def create_nn_agent(n,m,vs_self,vs_one,neural,uniform_player,tabular): # self play NN
    batch_size = 2 ** 10
    iter_batch = 2 ** 0
    modules = neural_create_model(neural.size)
    def avg_fn(avg_p, p, t): return avg_p + (p - avg_p) / min(m, t + 1)
    avg_modules = [AveragedModel(x,avg_fn=avg_fn) for x in modules]
    tracker = SquareErrorTracker().cuda()
    proj, value, value_head, policy, policy_head = modules
    vs_self, vs_one = vs_self.cat(proj.combine,proj.to_cat,proj.empty), vs_one.cat(proj.combine,proj.to_cat,proj.empty)
    opt = SignSGD([
        dict(params=x.parameters()) for x in modules
        ],lr=2 ** -7) # Momentum works worse than vanilla signSGD on Leduc. On lower batch sizes I don't see any improvement either.

    def eval(pl):
        vs_self(batch_size,pl)
        opt.step(); opt.zero_grad(True)

    def run(is_avg=False):
        for _ in range(5): eval(neural_player(neural,tracker,modules,model_explore,True,False))
        # eval(neural_player(neural,tracker,modules,model_explore,False,True))

        logging.debug(f"The l2 loss value prediction error is {tracker.mse_and_clear}")

        if is_avg:
            for avg_x,x in zip(avg_modules,modules): avg_x.update_parameters(x)

    def train(n):
        logging.info('Training the NN agent.')
        for a in range(n): run()
    def avg(m):
        logging.info('Averaging the NN agent.')
        for a in range(m): run(True)
    train(n); avg(m)
    def dump(i):
        with open(f"dump leduc/nn_agent_{i}.nnreg",'wb') as f: torch.save(modules,f)
        with open(f"dump leduc/nn_agent_{i}.nnavg",'wb') as f: torch.save([x.module for x in avg_modules],f)
    dump(n+m); avg(m); dump(n+2*m); avg(m); dump(n+3*m)

def evaluate_vs_tabular(i_tabular,i_nn,vs_self,vs_one,neural,uniform_player,tabular): # old NN vs old tabular
    batch_size = 2 ** 10
    with open(f'dump leduc/agent_{i_tabular}_avg.obj','rb') as f: tabular_agent_old = pickle.load(f)

    def r(name,modules):
        def tabular_player(is_update_head=False,is_update_policy=False,epsilon=0.0,tabular_agent=tabular_agent_old): 
            return tabular.create_policy(tabular_agent,is_update_head,is_update_policy,epsilon)

        r = 0
        n = 2 ** 8
        for _ in range(n):
            r += vs_one.exp(batch_size,neural_player(neural,None,modules),tabular_player()).sum()
        r /= batch_size * n
        logging.info(f'The mean is {r} for the {name} player.')
    with open(f'dump leduc/nn_agent_{i_nn}.nnreg','rb') as f: r('regular',torch.load(f))
    with open(f'dump leduc/nn_agent_{i_nn}.nnavg','rb') as f: r('average',torch.load(f))

def create_tabular_agent(n,m,vs_self,vs_one,neural,uniform_player,tabular):
    batch_size = 2 ** 10
    head_decay = 2 ** -2

    tabular_agent = tabular.create_agent()
    tabular_avg_agent = tabular.create_agent()
    def tabular_player(is_update_head=False,is_update_policy=False,epsilon=0.0,agent=tabular_agent): 
        return tabular.create_policy(agent,is_update_head,is_update_policy,epsilon)

    def run(is_avg : bool = False):
        tabular.head_multiply_(tabular_agent,head_decay)
        for a in range(1): 
            vs_self.exp(batch_size,tabular_player(True,False,2 ** -2,agent=tabular_agent))
        vs_self.exp(batch_size,tabular_player(False,True,2 ** -2,agent=tabular_agent))
        tabular.optimize(tabular_agent)
        if is_avg: tabular.average(tabular_avg_agent,tabular_agent)

    def train():
        logging.info('Training the tabular agent.')
        for a in range(n):
            run()

    def avg():
        logging.info('Averaging the tabular agent.')
        for a in range(m):
            run(True)
            if (a + 1) % 30 == 0: 
                r : np.ndarray = vs_self.exp(batch_size * 2 ** 4,tabular_player(agent=tabular_agent))
                logging.info(f'The mean reward is {r.mean()} for the regular agent.')
                r : np.ndarray = vs_self.exp(batch_size * 2 ** 4,tabular_player(agent=tabular_avg_agent))
                logging.info(f'The mean reward is {r.mean()} for the average agent.')
    train(); avg()
    with open(f"dump leduc/agent_{n + m}.obj",'wb') as f: pickle.dump(tabular_agent,f)
    with open(f"dump leduc/agent_{n + m}_avg.obj",'wb') as f: pickle.dump(tabular_avg_agent,f)

if __name__ == '__main__':
    import numpy as np
    import pyximport
    pyximport.install(language_level=3,setup_args={"include_dirs":np.get_include()})
    from create_args_leduc import main
    args = main()

    log_path = 'dump leduc/training.log'
    logging.basicConfig(
        filename=log_path,
        level=logging.DEBUG,
        datefmt='%m/%d/%Y %I:%M:%S %p',
        format='%(asctime)s %(message)s'
        )

    logging.info("** TRAINING START **")
    n,m = 300,150
    ag = n + m
    # create_tabular_agent(n,m,**args)
    for _ in range(1):
        create_nn_agent(n,m,**args)
        # evaluate_vs_tabular(ag,n+m,**args)
        # evaluate_vs_tabular(ag,n+2*m,**args)
        # evaluate_vs_tabular(ag,n+3*m,**args)
        logging.info("----")

    logging.info("** TRAINING DONE **")