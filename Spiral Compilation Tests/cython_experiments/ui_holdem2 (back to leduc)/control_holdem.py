from copy import deepcopy
import logging
import time
import torch
import torch.nn
from functools import partial
import numpy as np
from torch.optim.swa_utils import AveragedModel
from belief import SignSGD,Head,model_evaluate

def neural_create_model(size,size_mid=256,size_head=128):
    def Zero(a,b):
        x = torch.nn.Linear(a,b)
        with torch.no_grad(): x.weight.fill_(0.0); x.bias.fill_(0.0)
        return x
    value = torch.nn.Sequential(
        torch.nn.Linear(size.value,size_mid),
        torch.nn.ReLU(inplace=True),

        torch.nn.LayerNorm(size_mid,elementwise_affine=False),
        torch.nn.Linear(size_mid,size_mid),
        torch.nn.ReLU(inplace=True),

        torch.nn.LayerNorm(size_mid,elementwise_affine=False),
        torch.nn.Linear(size_mid,size.action * size_head)
        )
    value.square_l2 = torch.scalar_tensor(0.0).cuda()
    value.t = 0
    policy = torch.nn.Sequential(
        torch.nn.Linear(size.policy,size_mid),
        torch.nn.ReLU(inplace=True),

        torch.nn.LayerNorm(size_mid,elementwise_affine=False),
        torch.nn.Linear(size_mid,size_mid),
        torch.nn.ReLU(inplace=True),
        
        torch.nn.LayerNorm(size_mid,elementwise_affine=False),
        Zero(size_mid,size.action)
        )
    head = Head(size.action,size_head)
    return value.cuda(), policy.cuda(), head.cuda()

def create_nn_agent(iter_train,iter_avg,iter_chk,iter_static,vs_self,vs_one,neural,uniform_player): # self play NN
    assert ((iter_train + iter_avg) % iter_chk == 0)
    batch_size = 2 ** 10
    head_decay = 1.0

    value, policy, head = neural_create_model(neural.size)
    opt = SignSGD([
        {'params': value.parameters(), 'lr': 2 ** -10},
        {'params': policy.parameters()}
        ],{'lr': 2 ** -12})

    def make_avg(max_t):
        def avg_fn(avg_p, p, t): return avg_p + (p - avg_p) / min(max_t, t + 1)
        return AveragedModel(value,avg_fn=avg_fn), AveragedModel(policy,avg_fn=avg_fn), AveragedModel(head,avg_fn=avg_fn)

    valuea, policya, heada = make_avg(iter_chk)

    def neural_player(value,policy,head,is_update_head=False,is_update_value=False,is_update_policy=False,epsilon=0.0): 
        return neural.handler(partial(model_evaluate,value,policy,head,is_update_head,is_update_value,is_update_policy,epsilon))

    def run(is_avg=False):
        nonlocal head,heada
        pl = neural_player(value,policy,head,True,True,False,2 ** -2)
        # plc = neural_player(deepcopy(value),deepcopy(policy),deepcopy(head))
        plc = uniform_player
        logging.info('Training vs static.')
        head.decay(head_decay)
        for _ in range(iter_static):
            opt.zero_grad(True)
            r1 = vs_one(10)(batch_size * 8,pl,plc)
            r2 = vs_one(10)(batch_size * 8,plc,pl)
            logging.debug(f"The l2 loss of the value grads is {torch.sqrt(value.square_l2 / value.t)}")
            # logging.info(f"The mean is {(r1.mean()-r2.mean()) / 2}")
            opt.step()
            value.square_l2.fill_(0.0)
            value.t = 0

        if is_avg: valuea.update_parameters(value); policya.update_parameters(policy); heada.update_parameters(head)

    logging.info("** TRAINING START **")
    t1 = time.perf_counter()

    for i in range(1,iter_train+iter_avg+1):
        is_avg = iter_train < i
        run(is_avg)
        if i % iter_chk == 0: 
            with open(f"dump/nn_agent_{i}.nnreg",'wb') as f: torch.save((value,policy,head),f)
            if is_avg:
                with open(f"dump/nn_agent_{i}.nnavg",'wb') as f: torch.save((valuea.module,policya.module,heada.module),f)
            logging.info(f'Checkpoint {i}')

    logging.info("** TRAINING DONE **")
    t2 = time.perf_counter()
    logging.info(f"TIME ELAPSED: {t2-t1:0.4f}")

if __name__ == '__main__':
    import numpy as np
    import pyximport
    pyximport.install(language_level=3,setup_args={"include_dirs":np.get_include()})
    from create_args_holdem import main
    args = main()['train']

    log_path = 'dump/training.log'
    logging.basicConfig(
        filename=log_path,
        level=logging.DEBUG,
        datefmt='%m/%d/%Y %I:%M:%S %p',
        format='%(asctime)s %(message)s'
        )

    print("Running...")
    print(f"The details of training are in: {log_path}")
    create_nn_agent(10,0,1,40,**args)
    print("Done.")