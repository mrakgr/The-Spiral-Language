import math
import torch
import torch.distributions
import torch.nn
import torch.nn.functional

from torch.autograd import Function

@torch.jit.script
def var_match_(target,out): 
    """
    Normalizes the output tensor according to the target.
    """
    e = 2 ** -30
    out *= (target.square().sum(-1) / (out.square().sum(-1) + e)).sqrt_().unsqueeze(-1)
    return out

class LinearF(Function):
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


class Linear(torch.nn.Module):
    __constants__ = ['in_features', 'out_features']
    in_features: int
    out_features: int
    weight: torch.Tensor

    def __init__(self, in_features: int, out_features: int, bias: bool = True) -> None:
        super(Linear, self).__init__()
        self.in_features = in_features
        self.out_features = out_features
        self.weight = torch.nn.Parameter(torch.Tensor(out_features, in_features))
        if bias:
            self.bias = torch.nn.Parameter(torch.Tensor(out_features))
        else:
            self.register_parameter('bias', None)
        self.reset_parameters()

    def reset_parameters(self) -> None:
        torch.nn.init.kaiming_uniform_(self.weight, a=math.sqrt(5))
        if self.bias is not None:
            fan_in, _ = torch.nn.init._calculate_fan_in_and_fan_out(self.weight)
            bound = 1 / math.sqrt(fan_in)
            torch.nn.init.uniform_(self.bias, -bound, bound)

    def forward(self, input: torch.Tensor) -> torch.Tensor:
        return LinearF.apply(input, self.weight, self.bias)

    def extra_repr(self) -> str:
        return 'in_features={}, out_features={}, bias={}'.format(
            self.in_features, self.out_features, self.bias is not None
        )

@torch.jit.script
def tanh_back(grad_y,y): 
    return var_match_(grad_y,grad_y * (1 - torch.square(y)))

class TanhF(Function):
    @staticmethod
    def forward(ctx,x):
        y = torch.tanh(x)
        ctx.save_for_backward(y)
        return y

    @staticmethod
    def backward(ctx, grad_y):
        grad_x = None
        if ctx.needs_input_grad[0]:
            y, = ctx.saved_tensors
            grad_x = tanh_back(grad_y,y)
        return grad_x

class Tanh(torch.nn.Module):
    def forward(self, input: torch.Tensor) -> torch.Tensor:
        return TanhF.apply(input)

# def small(intro,mid,out): return torch.nn.Sequential(
#     Linear(intro,mid),
#     Tanh(),
#     Linear(mid,out)
#     )

def small(intro,mid,out): 
    x = torch.nn.Linear(intro,out)
    torch.nn.init.zeros_(x.weight)
    torch.nn.init.zeros_(x.bias)
    return x