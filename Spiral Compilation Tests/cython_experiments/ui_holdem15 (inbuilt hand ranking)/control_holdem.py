from copy import deepcopy
import logging
import time
import torch
from torch.nn import Linear
from functools import partial
import numpy as np
from torch.optim.swa_utils import AveragedModel
from belief import SignSGD, SquareErrorTracker,model_explore,model_exploit,EncoderList,Head

# defaults = dict(game_mode=0,sb=10,bb=20,stack_size=1000,schema_stack_size=1000) # Holdem
# defaults = dict(game_mode=2,sb=10,bb=20,stack_size=1000,schema_stack_size=1000) # River
defaults = dict(game_mode=2,sb=10,bb=20,stack_size=1000,schema_stack_size=1000)

from projector import LinearProjector

def neural_create_model(size,dim_head=2 ** 4,dim_emb=2 ** 5):
    proj = LinearProjector(defaults['schema_stack_size'],defaults['schema_stack_size']*2+1)
    value = EncoderList(0,dim_head,dim_emb,size.value)
    value_head = Head(size.action,dim_head*dim_emb,defaults['schema_stack_size']*2+1)
    policy = EncoderList(0,dim_head,dim_emb,size.policy)
    policy_head = Head(size.action,dim_head*dim_emb,1)
    return proj.cuda(), value.cuda(), value_head.cuda(), policy.cuda(), policy_head.cuda()

def neural_player(neural,tracker,modules,model_fun=model_exploit,is_update_value=False,is_update_policy=False): 
    return neural.handler(partial(model_fun,tracker,*modules,is_update_value,is_update_policy))

def create_nn_agent(
        iter_train,iter_avg,iter_chk,iter_sub,iter_batch,vs_self,vs_one,neural,uniform_player,callbot_player,
        game_mode,sb,bb,stack_size,schema_stack_size,
        resume_from=None,mode='self'
        ):
    neural_applied = neural(schema_stack_size)
    assert ((iter_train + iter_avg) % iter_chk == 0)
    batch_size = 2 ** 9

    if resume_from is None: 
        modules = neural_create_model(neural_applied.size)
        i_resume = 0
    else: 
        with open(f"dump holdem/nn_agent_{resume_from}_{mode}.nnreg",'rb') as f: 
            modules = torch.load(f)
            i_resume = resume_from
    proj, value, value_head, policy, policy_head = modules
    tracker = SquareErrorTracker().cuda()
    vs_self, vs_one = vs_self(game_mode,sb,bb,stack_size).cat(proj.combine,proj.to_cat,proj.empty), vs_one(game_mode,sb,bb,stack_size).cat(proj.combine,proj.to_cat,proj.empty)
    opt = SignSGD([
        dict(params=x.parameters()) for x in modules
        ],lr=2 ** -8)
    max_t = iter_chk*iter_sub
    def avg_fn(avg_p, p, t): return avg_p + (p - avg_p) / min(max_t, t + 1)
    if 0 < iter_avg: avg_modules = [AveragedModel(x,avg_fn) for x in modules]

    def run(is_avg=False):
        pl = neural_player(neural_applied,tracker,modules,model_fun=model_explore,is_update_value=True,is_update_policy=False)
        def vs_opponent(plc):
            for _ in range(iter_sub):
                for _ in range(iter_batch):
                    vs_one(batch_size // 2,pl,plc)
                    vs_one(batch_size // 2,plc,pl)
                logging.debug(f"The l2 loss value prediction error is {tracker.mse_and_clear}")
                opt.step()
                opt.zero_grad(True)

        logging.info(f'Training vs {mode}.')
        if mode == 'exploit':
            assert iter_train == 1 and iter_avg == 0 and iter_chk == 1
            vs_opponent(neural_player(neural_applied,tracker,deepcopy(modules)))
        elif mode == 'uniform': vs_opponent(uniform_player)
        elif mode == 'callbot': vs_opponent(callbot_player)
        elif mode == 'self':
            for i in range(iter_sub):
                opt.zero_grad(True)
                for _ in range(iter_batch): vs_self(game_mode,sb,bb,stack_size)(batch_size,pl)
                opt.step()
        else: raise Exception(f"Unexpected mode {mode}")

        if is_avg: 
            for avg_x,x in zip(avg_modules,modules): avg_x.update_parameters(x)

    logging.info("** TRAINING START **")
    t1 = time.perf_counter()

    for i in range(1,iter_train+iter_avg+1):
        is_avg = iter_train < i
        run(is_avg)
        if i % iter_chk == 0: 
            with open(f"dump holdem/nn_agent_{i_resume+i}_{mode}.nnreg",'wb') as f: torch.save(modules,f)
            if is_avg:
                with open(f"dump holdem/nn_agent_{i_resume+i}_{mode}.nnavg",'wb') as f: torch.save(list(map(lambda x: x.module,avg_modules)),f)
            logging.info(f'Checkpoint {i_resume+i}')

    logging.info("** TRAINING DONE **")
    t2 = time.perf_counter()
    logging.info(f"TIME ELAPSED: {t2-t1:0.4f}")

def competitive_eval(
        players,vs_one,neural,
        game_mode,sb,bb,stack_size,schema_stack_size,
        ):
    neural_applied = neural(schema_stack_size)
    
    batch_size = 2 ** 10
    logging.info("** EVALUATION START **")
    t1 = time.perf_counter()
    d = {}
    for a in players:
        d[a,a] = 0.0
        for b in players:
            x = d.get((a,b))
            if x is None:
                with open(f"dump holdem/{a}",'rb') as f: pla = neural_player(neural_applied,None,torch.load(f))
                with open(f"dump holdem/{b}",'rb') as f: plb = neural_player(neural_applied,None,torch.load(f))
                n = 2 ** 3
                r = 0.0
                for _ in range(n):
                    r += vs_one(game_mode,sb,bb,stack_size)(batch_size,pla,plb).sum()
                    r -= vs_one(game_mode,sb,bb,stack_size)(batch_size,plb,pla).sum()
                r /= 2 * batch_size * n
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
    log_path = 'dump holdem/training.log'
    logging.basicConfig(
        filename=log_path,
        level=logging.DEBUG,
        datefmt='%m/%d/%Y %I:%M:%S %p',
        format='%(asctime)s %(message)s'
        )

    create_nn_agent(30,0,10,40,2,**args,**defaults,mode='callbot')
    # players = [f'nn_agent_{i}_self.nnavg' for i in range(10,151,10)]
    # players = ['nn_agent_120_self.nnavg','nn_agent_130_self.nnavg']
    # competitive_eval(players,**args,**defaults)