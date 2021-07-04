import torch
action_state_probs = torch.rand(2,3,5)
values = torch.rand(3,5)
torch.einsum('bas,as->ba',action_state_probs,values)
(action_state_probs * values.unsqueeze(0)).sum(2)
