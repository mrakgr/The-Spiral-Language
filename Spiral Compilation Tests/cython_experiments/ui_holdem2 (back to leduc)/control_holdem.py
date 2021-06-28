from copy import deepcopy
import logging
import time
import torch
from torch.nn import Linear
from torch.nn.functional import normalize
from functools import partial
import numpy as np
from torch.optim.swa_utils import AveragedModel
from belief import SignSGD,Head,model_evaluate,InfTrip,ResInfTrip

def neural_create_model(size,size_mid=512,size_head=128):
    value = torch.nn.Sequential(
        InfTrip(size.value,size_mid),
        ResInfTrip(size_mid),
        ResInfTrip(size_mid),
        ResInfTrip(size_mid),
        ResInfTrip(size_mid),
        ResInfTrip(size_mid),
        Linear(size_mid,size.action * size_head)
        )
    value.square_l2 = torch.scalar_tensor(0.0).cuda()
    value.t = torch.scalar_tensor(0.0).cuda()
    policy = torch.nn.Sequential(
        InfTrip(size.policy,size_mid),
        ResInfTrip(size_mid),
        ResInfTrip(size_mid),
        ResInfTrip(size_mid),
        ResInfTrip(size_mid),
        ResInfTrip(size_mid),
        Linear(size_mid,size.action)
        )
    head = Head(size.action,size_head)
    return value.cuda(), policy.cuda(), head.cuda()

def create_nn_agent(mode,momo,postfix,iter_train,iter_avg,iter_chk,iter_static,vs_self,vs_one,neural,uniform_player,callbot_player): # self play NN
    assert ((iter_train + iter_avg) % iter_chk == 0)
    batch_size = 2 ** 10
    head_decay = 0.5

    # value, policy, head = neural_create_model(neural.size)
    with open("dump holdem/init.nnreg",'rb') as f: value, policy, head = torch.load(f)
    opt = SignSGD([
        dict(params=value.parameters(),lr=2 ** -8),
        dict(params=policy.parameters(),lr=2 ** -10),
        ],momentum=momo)

    def make_avg(max_t):
        def avg_fn(avg_p, p, t): return avg_p + (p - avg_p) / min(max_t, t + 1)
        return AveragedModel(value,avg_fn=avg_fn), AveragedModel(policy,avg_fn=avg_fn), AveragedModel(head,avg_fn=avg_fn)

    valuea, policya, heada = make_avg(iter_chk*iter_static)

    def neural_player(value,policy,head,is_update_head=False,is_update_value=False,is_update_policy=False,epsilon=0.0): 
        return neural.handler(partial(model_evaluate,value,policy,head,is_update_head,is_update_value,is_update_policy,epsilon))

    def run(is_avg=False):
        nonlocal head,heada
        pl = neural_player(value,policy,head,True,True,True,2 ** -2)
        def vs_opponent(plc):
            head.decay(head_decay)
            for i in range(iter_static):
                opt.zero_grad(True)
                r1 = vs_one(10)(batch_size // 2,pl,plc)
                r2 = vs_one(10)(batch_size // 2,plc,pl)
                # logging.info(f"The mean is {(r1.mean()-r2.mean()) / 2}")
                # logging.debug(f"The l2 loss value prediction error is {torch.sqrt(value.square_l2 / value.t)}")
                # value.square_l2.fill_(0.0)
                # value.t.fill_(0.0)
                opt.step()

        logging.info(f'Training vs {mode}.')
        if mode == 'static_self': vs_opponent(neural_player(deepcopy(value),deepcopy(policy),deepcopy(head)))
        elif mode == 'uniform': vs_opponent(uniform_player)
        elif mode == 'callbot': vs_opponent(callbot_player)
        elif mode == 'self':
            head.decay(head_decay)
            for i in range(iter_static):
                opt.zero_grad(True)
                vs_self(10)(batch_size,pl)
                opt.step()
        elif mode == 'average':
            assert (iter_train == 0)
            vs_opponent(neural_player(valuea.module,policya.module,heada.module))
        else: raise Exception(f"Unexpected mode {mode}")

        if is_avg: valuea.update_parameters(value); policya.update_parameters(policy); heada.update_parameters(head)

    logging.info("** TRAINING START **")
    t1 = time.perf_counter()

    for i in range(1,iter_train+iter_avg+1):
        is_avg = iter_train < i
        run(is_avg)
        if i % iter_chk == 0: 
            with open(f"dump holdem/nn_agent_{i}_{mode}_{postfix}.nnreg",'wb') as f: torch.save((value,policy,head),f)
            if is_avg:
                with open(f"dump holdem/nn_agent_{i}_{mode}_{postfix}.nnavg",'wb') as f: torch.save((valuea.module,policya.module,heada.module),f)
            logging.info(f'Checkpoint {i}')

    logging.info("** TRAINING DONE **")
    t2 = time.perf_counter()
    logging.info(f"TIME ELAPSED: {t2-t1:0.4f}")

def competitive_eval(players,vs_self,vs_one,neural,uniform_player,callbot_player):
    batch_size = 2 ** 14
    def neural_player(value,policy,head,is_update_head=False,is_update_value=False,is_update_policy=False,epsilon=0.0): 
        return neural.handler(partial(model_evaluate,value,policy,head,is_update_head,is_update_value,is_update_policy,epsilon))
    logging.info("** EVALUATION START **")
    t1 = time.perf_counter()
    d = {}
    for a in players:
        d[a,a] = 0.0
        for b in players:
            x = d.get((a,b))
            if x is None:
                with open(f"dump holdem/{a}",'rb') as f: pla = neural_player(*torch.load(f))
                with open(f"dump holdem/{b}",'rb') as f: plb = neural_player(*torch.load(f))
                r1 = vs_one(10)(batch_size // 2,pla,plb)
                r2 = vs_one(10)(batch_size // 2,plb,pla)
                r = (r1.sum()-r2.sum()) / batch_size
                logging.info(f"The mean for {a} vs {b} is {r}")
                d[a,b] = r; d[b,a] = -r
    logging.info("Done with the evaluation. Printing in tabular format.")
    for a in players:
        for b in players:
            logging.info(f"{a} vs {b}: {d[a,b]}")

    logging.info("** EVALUATION DONE **")
    t2 = time.perf_counter()
    logging.info(f"TIME ELAPSED: {t2-t1:0.4f}")

if __name__ == '__main__':
    import numpy as np
    import pyximport
    pyximport.install(language_level=3,setup_args={"include_dirs":np.get_include()})
    from create_args_holdem import main
    args = main()['train']
    def train():
        log_path = 'dump holdem/training.log'
        logging.basicConfig(
            filename=log_path,
            level=logging.DEBUG,
            datefmt='%m/%d/%Y %I:%M:%S %p',
            format='%(asctime)s %(message)s'
            )

        # ['static_self','self','average','callbot','uniform'] # modes
        
        create_nn_agent('static_self',0.0,'no_momo',1,0,1,2000,**args)

    def eval():
        log_path = 'dump holdem/eval.log'
        logging.basicConfig(
            filename=log_path,
            level=logging.DEBUG,
            datefmt='%m/%d/%Y %I:%M:%S %p',
            format='%(asctime)s %(message)s'
            )
        players = [
            f'nn_agent_{i}_{mode}_{momo}.nnreg' 
            for momo in ['no_momo','momo']
            for mode in ['static_self'] 
            for i in [1]
            ]
        players.append('init.nnreg')
        competitive_eval(players,**args)

    train()
    eval()