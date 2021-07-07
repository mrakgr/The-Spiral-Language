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
    present_rep = Linear(size.present,size_head)
    future_rep = Linear(size_head+size.future,size_head,False) # The bias is false because the rewards serializer always puts an 1 to indicate that the reward is active.
    action_pred = Linear(size_head,size.action)
    actor = Linear(size_head,size.action)
    critic = Head(size_head,size.action)
    return present_rep.cuda(), future_rep.cuda(), action_pred.cuda(), actor.cuda(), critic.cuda()

def evaluate_vs_tabular(i_tabular,i_nn,vs_self,vs_one,neural,tabular,uniform_player): # old NN vs old tabular
    batch_size = 2 ** 10
    with open(f'dump leduc/agent_{i_tabular}_avg.obj','rb') as f: tabular_agent_old = pickle.load(f)

    def r(name, present_rep, future_rep, action_pred, actor, critic):
        def tabular_player(is_update_head=False,is_update_policy=False,epsilon=0.0,tabular_agent=tabular_agent_old): 
            return tabular.create_policy(tabular_agent,is_update_head,is_update_policy,epsilon)

        def neural_player(is_update_pred : bool = False,is_update_critic : bool = False,is_update_actor : bool = False): 
            return neural.handler(partial(model_evaluate,present_rep,future_rep,action_pred,actor,critic,None,is_update_pred,is_update_critic,is_update_actor))

        r : np.ndarray = vs_one(batch_size * 2 ** 8,neural_player(),tabular_player())
        logging.info(f'The mean is {r.mean()} for the {name} player.')
    with open(f'dump leduc/nn_agent_{i_nn}.nnreg','rb') as f: r('regular',*torch.load(f))
    with open(f'dump leduc/nn_agent_{i_nn}.nnavg','rb') as f: r('average',*torch.load(f))

def create_tabular_agent(n,m,vs_self,vs_one,tabular,neural,uniform_player):
    batch_size = 2 ** 10
    head_decay = 2 ** -2

    tabular_agent = tabular.create_agent()
    tabular_avg_agent = tabular.create_agent()
    def tabular_player(is_update_head=False,is_update_policy=False,epsilon=0.0,agent=tabular_agent): 
        return tabular.create_policy(agent,is_update_head,is_update_policy,epsilon)

    def run(is_avg : bool = False):
        tabular.head_multiply_(tabular_agent,head_decay)
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

def create_nn_agent(num_iter,avg_window,vs_self,vs_one,tabular,neural,uniform_player): # self play NN
    assert (num_iter % avg_window == 0)
    batch_size = 2 ** 10

    present_rep, future_rep, action_pred, actor, critic = neural_create_model(neural.size)
    opt = SignSGD([
        dict(params=present_rep.parameters()),
        dict(params=future_rep.parameters()),
        dict(params=action_pred.parameters()),
        dict(params=actor.parameters()),
        dict(params=critic.parameters(),weight_decay=0.5),
        ],lr=2 ** -6)
    def avg_fn(avg_p, p, t): return avg_p + (p - avg_p) / min(avg_window, t + 1)
    present_repa, future_repa, action_preda, actora, critica = AveragedModel(present_rep,avg_fn=avg_fn), AveragedModel(future_rep,avg_fn=avg_fn), AveragedModel(action_pred,avg_fn=avg_fn), AveragedModel(actor,avg_fn=avg_fn), AveragedModel(critic,avg_fn=avg_fn)
    def neural_player(is_update_pred : bool = False,is_update_critic : bool = False,is_update_actor : bool = False,is_explorative : bool = False):
        return neural.handler(partial(model_evaluate,present_rep,future_rep,action_pred,actor,critic,actora.module if is_explorative else None,is_update_pred,is_update_critic,is_update_actor))

    pla,plb = neural_player(False,False,True,False),neural_player()
    for a in range(1,1+num_iter):
        opt.zero_grad(True)
        vs_one(batch_size//2,pla,plb)
        vs_one(batch_size//2,plb,pla)
        opt.step()

        present_repa.update_parameters(present_rep); future_repa.update_parameters(future_rep); action_preda.update_parameters(action_pred); actora.update_parameters(actor); critica.update_parameters(critic)
        if a % avg_window == 0:
            with open(f"dump leduc/nn_agent_{a}.nnreg",'wb') as f: torch.save((present_rep, future_rep, action_pred, actor, critic),f)
            with open(f"dump leduc/nn_agent_{a}.nnavg",'wb') as f: torch.save((present_repa.module, future_repa.module, action_preda.module, actora.module, critica.module),f)

if __name__ == '__main__':
    import numpy as np
    import pyximport
    pyximport.install(language_level=3,setup_args={"include_dirs":np.get_include()})
    from create_args_leduc2 import main
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
        create_nn_agent(n+3*m,m,**args)
        evaluate_vs_tabular(ag,n+m,**args)
        evaluate_vs_tabular(ag,n+2*m,**args)
        evaluate_vs_tabular(ag,n+3*m,**args)
        logging.info("----")

    logging.info("** TRAINING DONE **")