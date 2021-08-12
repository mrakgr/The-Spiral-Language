from copy import deepcopy
import logging
import time
import torch
from torch.nn import Linear
from functools import partial
import numpy as np
from torch.optim.swa_utils import AveragedModel
from belief import SignSGD, SquareErrorTracker,model_explore,model_exploit,EncoderList,Head

defaults = dict(game_mode=2,sb=10,bb=20,max_stack_size=1000)

from projector import LinearProjector

def neural_create_model(size,dim_head=2 ** 4,dim_emb=2 ** 5):
    proj = LinearProjector(defaults['max_stack_size'],defaults['max_stack_size']*2+1)
    value = EncoderList(5,dim_head,dim_emb,size.value)
    value_head = Head(size.action,dim_head*dim_emb,defaults['max_stack_size']*2+1)
    policy = EncoderList(5,dim_head,dim_emb,size.policy)
    policy_head = Head(size.action,dim_head*dim_emb,1)
    return proj.cuda(), value.cuda(), value_head.cuda(), policy.cuda(), policy_head.cuda()

def neural_player(neural,tracker,modules,model_fun=model_exploit,is_update_value=False,is_update_policy=False): 
    return neural.handler(partial(model_fun,tracker,*modules,is_update_value,is_update_policy))

def create_nn_agent(
        iter_train,iter_avg,iter_chk,iter_sub,iter_batch,vs_self,vs_one,neural,player,
        game_mode,sb,bb,max_stack_size,
        resume_from=None, num_copies=10
        ):
    assert ((iter_train + iter_avg) % iter_chk == 0)
    batch_size = 2 ** 9

    if resume_from is None: 
        modules = neural_create_model(neural.size)
        i_resume = 0
    else: 
        with open(f"dump holdem/nn_agent_{resume_from}.nnreg",'rb') as f: 
            modules = torch.load(f)
            i_resume = resume_from
    proj, value, value_head, policy, policy_head = modules
    tracker = SquareErrorTracker().cuda()
    vs_self, vs_one = vs_self(game_mode,sb,bb,max_stack_size).cat(proj.combine,proj.to_cat,proj.empty), vs_one(game_mode,sb,bb,max_stack_size).cat(proj.combine,proj.to_cat,proj.empty)
    opt_value = SignSGD([dict(params=x.parameters()) for x in [value,value_head]],lr=2 ** -8)
    opt_policy = SignSGD([dict(params=x.parameters()) for x in [policy,policy_head]],lr=2 ** -8)
    max_t = iter_chk*iter_sub
    def avg_fn(avg_p, p, t): return avg_p + (p - avg_p) / min(max_t, t + 1)
    if 0 < iter_avg: avg_modules = [AveragedModel(x,avg_fn) for x in modules]

    def copy_modules(): return neural_player(neural,None,(deepcopy(x).requires_grad_(False) for x in modules))
    oldies = [player.callbot, player.aggrodonk, neural_player(neural,None,torch.load(open("dump holdem/weak tag.nnreg",'rb')))]

    def run(is_avg=False):
        for i_sub in range(iter_sub):
            pla = neural_player(neural,tracker,modules,model_explore,True,False)
            for plb in oldies:
                for i_batch in range(iter_batch): vs_one(batch_size,pla,plb); vs_one(batch_size,plb,pla)
            opt_value.step(); opt_value.zero_grad(True)

            # pla = neural_player(neural,tracker,modules,model_explore,True,True)
            # for plb in oldies:
            #     for i_batch in range(iter_batch): vs_one(batch_size,pla,plb); vs_one(batch_size,plb,pla)
            # for opt in (opt_policy,opt_value): opt.step(); opt.zero_grad(True)

            logging.debug(f"Value prediction MSE: {tracker.mse_and_clear}")

            if is_avg: 
                for avg_x,x in zip(avg_modules,modules): avg_x.update_parameters(x)

        # oldies.append(copy_modules())
        # if num_copies <= len(oldies): oldies.pop(0)

    logging.info("** TRAINING START **")
    t1 = time.perf_counter()

    for i in range(1,iter_train+iter_avg+1):
        is_avg = iter_train < i
        run(is_avg)
        if i % iter_chk == 0: 
            with open(f"dump holdem/nn_agent_{i_resume+i}.nnreg",'wb') as f: torch.save(modules,f)
            if is_avg:
                with open(f"dump holdem/nn_agent_{i_resume+i}.nnavg",'wb') as f: torch.save(list(map(lambda x: x.module,avg_modules)),f)
            logging.info(f'Checkpoint {i_resume+i}')

    logging.info("** TRAINING DONE **")
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

    create_nn_agent(30,0,1,40,10,**args,**defaults,resume_from=0)