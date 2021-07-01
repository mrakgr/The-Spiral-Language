import pickle
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
        Linear(size_mid,size.action * size_head)
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
        print(f'The mean is {r.mean()} for the {name} player.')
    with open(f'dump leduc/nn_agent_{i_nn}.obj','rb') as f: r('regular',*pickle.load(f))
    with open(f'dump leduc/nn_agent_{i_nn}_avg.obj','rb') as f: r('average',*pickle.load(f))

def create_tabular_agent(n,m,vs_self,vs_one,neural,uniform_player,tabular):
    batch_size = 2 ** 10
    head_decay = 2 ** -2

    tabular_agent = tabular.create_agent()
    tabular_avg_agent = tabular.create_agent()
    def tabular_player(is_update_head=False,is_update_policy=False,epsilon=0.0,agent=tabular_agent): 
        return tabular.create_policy(agent,is_update_head,is_update_policy,epsilon)

    def run(is_avg : bool = False):
        tabular.head_multiply_(tabular_agent,head_decay)
        # 6/22/2021: I do not want to bother testing it right now, but since it works for neural agent training
        # removing this for loop and updating both the value and the policy at once like...
        # vs_self(batch_size,tabular_player(True,True,2 ** -2,agent=tabular_agent))
        # ...should improve computation time by 4x without degrading the agent performance.
        for a in range(3): 
            vs_self(batch_size,tabular_player(True,False,2 ** -2,agent=tabular_agent))
        vs_self(batch_size,tabular_player(False,True,2 ** -2,agent=tabular_agent))
        tabular.optimize(tabular_agent)
        if is_avg: tabular.average(tabular_avg_agent,tabular_agent)

    def train():
        print('Training the tabular agent.')
        for a in range(n):
            run()
            if (a + 1) % 30 == 0: print(a+1)

    def avg():
        print('Averaging the tabular agent.')
        for a in range(m):
            run(True)
            if (a + 1) % 30 == 0: 
                print(a+1)
                r : np.ndarray = vs_self(batch_size * 2 ** 4,tabular_player(agent=tabular_agent))
                print(f'The mean reward is {r.mean()} for the regular agent.')
                r : np.ndarray = vs_self(batch_size * 2 ** 4,tabular_player(agent=tabular_avg_agent))
                print(f'The mean reward is {r.mean()} for the average agent.')
    train()
    avg()
    with open(f"dump leduc/agent_{n + m}.obj",'wb') as f: pickle.dump(tabular_agent,f)
    with open(f"dump leduc/agent_{n + m}_avg.obj",'wb') as f: pickle.dump(tabular_avg_agent,f)

def create_nn_agent(n,m,vs_self,vs_one,neural,uniform_player,tabular): # self play NN
    batch_size = 2 ** 10
    head_decay = 2 ** -2

    value, policy, head = neural_create_model(neural.size)
    opt = SignSGD([
        dict(params=value.parameters(),lr=2 ** -6),
        dict(params=policy.parameters(),lr=2 ** -8)
        ],momentum=0) # Momentum works worse than vanilla signSGD on Leduc. On lower batch sizes I don't see any improvement either.
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
        print('Training the NN agent.')
        for a in range(n):
            run()
            # if (a + 1) % 25 == 0: print(a+1)
    def avg(m):
        print('Averaging the NN agent.')
        for a in range(m):
            run(True)
            # if (a + 1) % 25 == 0: 
            #     print(a+1)
                # r : np.ndarray = vs_self(batch_size * 2 ** 4,neural_player())
                # print(f'The mean reward vs_self is {r.mean()}')
    train(n); avg(m)
    def dump(i):
        with open(f"dump leduc/nn_agent_{i}.obj",'wb') as f: pickle.dump((value,policy,head),f)
        with open(f"dump leduc/nn_agent_{i}_avg.obj",'wb') as f: pickle.dump((valuea.module,policya.module,heada.module),f)
    dump(n+m); avg(m); dump(n+2*m); avg(m); dump(n+3*m)

if __name__ == '__main__':
    import numpy as np
    import pyximport
    pyximport.install(language_level=3,setup_args={"include_dirs":np.get_include()})
    from create_args_leduc import main
    args = main()
    n,m=300,150
    # create_tabular_agent(n,m,**args)
    ag = n + m
    for _ in range(5):
        create_nn_agent(n,m,**args)
        evaluate_vs_tabular(ag,n+m,**args)
        evaluate_vs_tabular(ag,n+2*m,**args)
        evaluate_vs_tabular(ag,n+3*m,**args)
        print("----")