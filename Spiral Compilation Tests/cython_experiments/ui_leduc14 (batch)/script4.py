import torch
from torch.autograd import Function
import torch.nn
import torch.nn.functional

# Is meant to be arbitrary.
def f(x): 
    return x*2

class VarianceMatch(Function):
    @staticmethod
    def forward(ctx, x):
        y = f(x)
        ctx.save_for_backward(x,y)
        return y

    @staticmethod
    def backward(ctx, grad_y):
        x,y = ctx.saved_tensors
        y.backward(grad_y)
        x.grad *= torch.sqrt(torch.square(grad_y).sum(1) / torch.square(x.grad).sum(1))
        return torch.zeros_like(x)

i = torch.scalar_tensor(2,requires_grad=True)
x = VarianceMatch.apply(i)
x.backward(torch.scalar_tensor(1))
print(i.grad)

# class LinearFunction(torch.Function):
#     @staticmethod
#     def forward(ctx, input, weight, bias=None):
#         ctx.save_for_backward(input, weight, bias)
#         output = input.mm(weight.t())
#         if bias is not None:
#             output += bias.unsqueeze(0).expand_as(output)
#         return output

#     @staticmethod
#     def backward(ctx, grad_output):
#         input, weight, bias = ctx.saved_tensors
#         grad_input = grad_weight = grad_bias = None

#         if ctx.needs_input_grad[0]:
#             grad_input = grad_output.mm(weight)
#         if ctx.needs_input_grad[1]:
#             grad_weight = grad_output.t().mm(input)
#         if bias is not None and ctx.needs_input_grad[2]:
#             grad_bias = grad_output.sum(0)

#         return grad_input, grad_weight, grad_bias