import torch
import torch.linalg
import numpy as np
q = torch.ones(16) 
q /= torch.linalg.norm(q,ord=1)
-torch.sum(q * torch.log(q))