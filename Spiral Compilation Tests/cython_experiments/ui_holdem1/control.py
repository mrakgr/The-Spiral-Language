import logging
import time
import timeit
import torch
import torch.nn
from functools import partial
import numpy as np
from torch.optim.swa_utils import AveragedModel
from belief import SignSGD,Head,model_evaluate

def neural_create_model(size,size_mid=256,size_head=128):
    value = torch.nn.Sequential(
        torch.nn.Linear(size.value,size_mid),
        torch.nn.ReLU(inplace=True),

        torch.nn.LayerNorm(size_mid,elementwise_affine=False),
        torch.nn.Linear(size_mid,size_mid),
        torch.nn.ReLU(inplace=True),

        torch.nn.LayerNorm(size_mid,elementwise_affine=False),
        torch.nn.Linear(size_mid,size_head)
        )
    policy = torch.nn.Sequential(
        torch.nn.Linear(size.policy,size_mid),
        torch.nn.ReLU(inplace=True),

        torch.nn.LayerNorm(size_mid,elementwise_affine=False),
        torch.nn.Linear(size_mid,size_mid),
        torch.nn.ReLU(inplace=True),
        
        torch.nn.LayerNorm(size_mid,elementwise_affine=False),
        torch.nn.Linear(size_mid,size.action)
        )
    head = Head(size.action,size_head)
    return value.cuda(), policy.cuda(), head.cuda()

def create_nn_agent(n,m,vs_self,vs_one,neural,uniform_player): # self play NN
    batch_size = 2 ** 10
    head_decay = 1.0 - 2 ** -1

    value, policy, head = neural_create_model(neural.size)
    opt = SignSGD([
        {'params': value.parameters(), 'lr': 2 ** -6},
        {'params': policy.parameters()}
        ],{'lr': 2 ** -8})
    valuea, policya, heada = AveragedModel(value), AveragedModel(policy), AveragedModel(head)
    def neural_player(is_update_head=False,is_update_value=False,is_update_policy=False,epsilon=2 ** -2): 
        return neural.handler(partial(model_evaluate,value,policy,head,is_update_head,is_update_value,is_update_policy,epsilon))

    def run(is_avg=False):
        nonlocal head,heada
        opt.zero_grad(True)
        head.decay(head_decay)
        # vs_self(batch_size,neural_player(True,True,True,2 ** -2))
        r = vs_one(batch_size,neural_player(True,True,True,2 ** -2),uniform_player)
        # r = vs_one(batch_size,neural_player(False,False,False,0),uniform_player)
        logging.info(f"The reward vs the uniform is {r.mean()}")
        opt.step()

        if is_avg: valuea.update_parameters(value); policya.update_parameters(policy); heada.update_parameters(head)

    def train(n):
        if 0 < n:
            logging.info('Training the NN agent.')
            for a in range(n): run()
    def avg(m):
        if 0 < m:
            logging.info('Averaging the NN agent.')
            for a in range(m): run(True)
    logging.info("** TRAINING START **")
    t1 = time.perf_counter()
    train(n); avg(m)
    with open(f"dump/nn_agent_{n+m}.nnreg",'wb') as f: torch.save((value,policy,head),f)
    with open(f"dump/nn_agent_{n+m}.nnavg",'wb') as f: torch.save((valuea.module,policya.module,heada.module),f)
    logging.info("** TRAINING DONE **")
    t2 = time.perf_counter()
    logging.info(f"TIME ELAPSED: {t2-t1:0.4f}")

if __name__ == '__main__':
    import numpy as np
    import pyximport
    pyximport.install(language_level=3,setup_args={"include_dirs":np.get_include()})
    from create_args import main
    args = main()['train']
    n,m=30,0

    log_path = 'dump/training.log'
    logging.basicConfig(
        filename=log_path,
        level=logging.DEBUG,
        datefmt='%m/%d/%Y %I:%M:%S %p',
        format='%(asctime)s %(message)s'
        )

    print("Running...")
    print(f"The details of training are in: {log_path}")
    for _ in range(5):
        print(timeit.timeit(lambda: create_nn_agent(n,m,**args), number=10))
    
    # for _ in range(5):
    #     # create_tabular_agent(n//2,m//2,**args)
    #     run(451,n+m,**args)
    #     run(451,n+2*m,**args)
    #     run(451,n+3*m,**args)
    #     logging.info("----")
    print("Done.")