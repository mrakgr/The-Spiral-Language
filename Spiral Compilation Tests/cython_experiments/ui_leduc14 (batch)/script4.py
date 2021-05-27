import torch
from torch.autograd import Function

class VarianceMatch(Function):
    @staticmethod
    def forward(ctx, x):
        y : torch.Tensor = x * 2
        y.requires_grad_()
        y.retain_grad() # Does not work.
        def h(grad): # y.grad is None so this gives me an exception.
            return grad * torch.sqrt(torch.square(y.grad).sum(1) / torch.square(grad).sum(1))
        x.register_hook(h)
        return y

    @staticmethod
    def backward(ctx, grad_y):
        return grad_y * 2

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