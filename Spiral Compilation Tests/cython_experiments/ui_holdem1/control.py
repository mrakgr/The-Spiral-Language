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

def create_nn_agent(iter_train,iter_avg,iter_chk,vs_self,vs_one,neural,uniform_player): # self play NN
    assert ((iter_train + iter_avg) % iter_chk == 0)
    batch_size = 2 ** 14
    favg_iter = 100
    head_decay = 1.0 - 2 ** -2

    value, policy, head = neural_create_model(neural.size)
    opt = SignSGD([
        {'params': value.parameters(), 'lr': 2 ** -6},
        {'params': policy.parameters()}
        ],{'lr': 2 ** -8})

    def make_avg(max_t):
        def avg_fn(avg_p, p, t): return avg_p + (p - avg_p) / min(max_t, t + 1)
        return AveragedModel(value,avg_fn=avg_fn), AveragedModel(policy,avg_fn=avg_fn), AveragedModel(head,avg_fn=avg_fn)

    valuea, policya, heada = make_avg(iter_chk) # The slow average
    # valuefa, policyfa, headfa = make_avg(favg_iter) # The fast average

    def neural_player(value,policy,head,is_update_head=False,is_update_value=False,is_update_policy=False,epsilon=0.0): 
        return neural.handler(partial(model_evaluate,value,policy,head,is_update_head,is_update_value,is_update_policy,epsilon))

    def run(is_avg=False):
        nonlocal head,heada
        opt.zero_grad(True)
        head.decay(head_decay)
        pl = neural_player(value,policy,head,True,True,True,2 ** -2)
        for _ in range(2 ** 3): vs_self(50)(batch_size,pl)
        # plfa = neural_player(valuefa.module,policyfa.module,headfa.module)
        # vs_one(batch_size // 2,pl,plfa)
        # vs_one(batch_size // 2,plfa,pl)
        opt.step()
        # valuefa.update_parameters(value); policyfa.update_parameters(policy); headfa.update_parameters(head)

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
    from create_args import main
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
    create_nn_agent(2_000 // 4,30_000 // 4,2_000 // 4,**args)
    print("Done.")