import pickle
import logging
import torch
import torch.distributions
import torch.optim
from torch.nn import Linear
import torch.linalg
from functools import partial
import numpy as np
from belief import SignSGD,Head,model_evaluate,InfCube
from torch.optim.swa_utils import AveragedModel

def neural_create_model(size,size_mid=64,size_head=64):
    value = torch.nn.Sequential(
        InfCube(size.value,size_mid),
        Linear(size_mid,size_head)
        )
    policy = torch.nn.Sequential(
        InfCube(size.policy,size_mid),
        Linear(size_mid,size.action)
        )
    head = Head(size.action,size_mid)
    return value.cuda(), policy.cuda(), head.cuda()

def evaluate_vs_tabular(i_tabular,i_nn,vs_self,vs_one,neural,uniform_player,tabular): # old NN vs old tabular
    batch_size = 2 ** 10
    with open(f'dump leduc/agent_{i_tabular}_avg.obj','rb') as f: tabular_agent_old = pickle.load(f)

    def r(name,value,policy,head):
        def tabular_player(is_update_head=False,is_update_policy=False,epsilon=0.0,tabular_agent=tabular_agent_old): 
            return tabular.create_policy(tabular_agent,is_update_head,is_update_policy,epsilon)

        def neural_player(is_update_head=False,is_update_value=False,is_update_policy=False,epsilon=0.0): 
            return neural.handler(partial(model_evaluate,value,policy,head,is_update_head,is_update_value,is_update_policy,epsilon))

        r : np.ndarray = vs_one(batch_size * 2 ** 8,neural_player(),tabular_player())
        logging.info(f'The mean is {r.mean()} for the {name} player.')
    with open(f'dump leduc/nn_agent_{i_nn}.obj','rb') as f: r('regular',*torch.load(f))
    with open(f'dump leduc/nn_agent_{i_nn}_avg.obj','rb') as f: r('average',*torch.load(f))

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
            vs_self(batch_size,tabular_player(True,False,2 ** -2,agent=tabular_agent))
        vs_self(batch_size,tabular_player(False,True,2 ** -2,agent=tabular_agent))
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
                r : np.ndarray = vs_self(batch_size * 2 ** 4,tabular_player(agent=tabular_agent))
                logging.info(f'The mean reward is {r.mean()} for the regular agent.')
                r : np.ndarray = vs_self(batch_size * 2 ** 4,tabular_player(agent=tabular_avg_agent))
                logging.info(f'The mean reward is {r.mean()} for the average agent.')
    train(); avg()
    with open(f"dump leduc/agent_{n + m}.obj",'wb') as f: pickle.dump(tabular_agent,f)
    with open(f"dump leduc/agent_{n + m}_avg.obj",'wb') as f: pickle.dump(tabular_avg_agent,f)

def create_nn_agent(n,m,vs_self,vs_one,neural,uniform_player,tabular): # self play NN
    batch_size = 2 ** 10
    head_decay = 2 ** -2

    value, policy, head = neural_create_model(neural.size)
    opt = SignSGD([
        dict(params=value.parameters(),lr=2 ** -6),
        dict(params=policy.parameters(),lr=2 ** -8)
        ],momentum_decay=0.0) # Momentum works worse than vanilla signSGD on Leduc. On lower batch sizes I don't see any improvement either.
    valuea, policya, heada = AveragedModel(value), AveragedModel(policy), AveragedModel(head)
    def neural_player(is_update_head=False,is_update_value=False,is_update_policy=False,epsilon=2 ** -2): 
        return neural.handler(partial(model_evaluate,value,policy,head,is_update_head,is_update_value,is_update_policy,epsilon))

    def run(is_avg=False):
        nonlocal head,heada
        opt.zero_grad(True)
        vs_self(batch_size,neural_player(True,True,True,2 ** -2))
        opt.step()
        head.decay(head_decay)

        if is_avg: valuea.update_parameters(value); policya.update_parameters(policy); heada.update_parameters(head)

    def train(n):
        logging.info('Training the NN agent.')
        for a in range(n): run()
    def avg(m):
        logging.info('Averaging the NN agent.')
        for a in range(m): run(True)
    train(n); avg(m)
    def dump(i):
        with open(f"dump leduc/nn_agent_{i}.obj",'wb') as f: torch.save((value,policy,head),f)
        with open(f"dump leduc/nn_agent_{i}_avg.obj",'wb') as f: torch.save((valuea.module,policya.module,heada.module),f)
    dump(n+m); avg(m); dump(n+2*m); avg(m); dump(n+3*m)

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
    for _ in range(5):
        create_nn_agent(n,m,**args)
        evaluate_vs_tabular(ag,n+m,**args)
        evaluate_vs_tabular(ag,n+2*m,**args)
        evaluate_vs_tabular(ag,n+3*m,**args)
        logging.info("----")

    logging.info("** TRAINING DONE **")