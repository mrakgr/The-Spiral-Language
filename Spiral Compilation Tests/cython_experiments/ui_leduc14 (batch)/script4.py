import torch
import torch.nn
import torch.functional
from torch.autograd import Function

@torch.jit.script
def var_match_(target,out): 
    """
    Normalizes the output tensor according to the target.
    """
    e = 2 ** -30
    out *= (target.square().sum(-1) / (out.square().sum(-1) + e)).sqrt_().unsqueeze(-1)
    return out

class Linear(Function):
    @staticmethod
    def forward(ctx, input, weight, bias=None):
        ctx.save_for_backward(input, weight, bias)
        if bias is not None:
            output = torch.addmm(bias, input, weight.t())
        else: 
            output = input.mm(weight.t())
        return output

    @staticmethod
    def backward(ctx, grad_output):
        input, weight, bias = ctx.saved_tensors
        grad_input = grad_weight = grad_bias = None

        if ctx.needs_input_grad[0]:
            grad_input = var_match_(grad_output,grad_output.mm(weight))
        if ctx.needs_input_grad[1]:
            grad_weight = grad_output.t().mm(input)
        if bias is not None and ctx.needs_input_grad[2]:
            grad_bias = grad_output.sum(0)

        return grad_input, grad_weight, grad_bias

@torch.jit.script
def tanh_back(grad_y,y): 
    return var_match_(grad_y,grad_y * (1 - torch.square(y)))

class Tanh(Function):
    @staticmethod
    def forward(ctx,x):
        y = torch.tanh(x)
        ctx.save_for_backward(y)
        return y

    @staticmethod
    def backward(ctx, grad_y):
        y, = ctx.saved_tensors
        grad_x = None
        if ctx.needs_input_grad[0]:
            grad_x = tanh_back(grad_y,y)
        return grad_x

weight = torch.randn((3,3),requires_grad=True)
bias = torch.rand(3,requires_grad=True)
input = torch.rand((1,3),requires_grad=True)

y = Tanh.apply(Linear.apply(input,weight,bias))
y.backward(torch.tensor([[1,2,3]]))

print(torch.tensor([[1,2,3]]).square().sum())
print(input.grad.square().sum())