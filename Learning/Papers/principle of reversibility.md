Date: 9/13/2019

Conjecture: reversibility is the primary principle of learning.

# Motivation

What I will try to do here is try to build from first principles a learning algorithm, and try to convince you that it is a viable alternative to backprop. Right now I can't start work on it just yet as I am busy with other things, so I want to present a few arguments and hopefully get some feedback. I am going to start with some very simple low dimensional examples and later try to extrapolate them to neural networks with arbitrary number of parameters.

For the following two examples, please keep in mind that NNs at their core are sequences of matrix multiplies (plus some other stuff), and that scalar values are just 1x1 matrices. It is possible to have layers with just one variable.

# The 1d example with multiple targets

Let me compare reversibility to backprop.

Consider the function `f(x) = x^2`. Suppose you have 3 targets `1,000,000`, `4,000,000`, `9,000,000`.

On such a function, what would the backprop pass for the squared error `1/2 * (target - f(x)` function?
The derivative of squared error is `target - x^2`, and the derivative of square is `2*x`, so the backprop update for `x` would be `(target - x^2) * 2 * x`.

So if you started `x` out at 1, the gradient for the `1,000,000` target would (rougly) be `2,000,000`. That is a large number.

Starting at zero with backprop for this function would never update at all due to the `2 * x` term. And suppose you started at something like `2,000` and got the `9,000,000` as target. Then the update would be `(9,000,000 - 4,000,000) * 2 * 2,000 = 20,000,000,000`. 

How would you one even set the learning rate for a function like this? Taking the second derivative here would not help as the derivative of `2 * x` is just `2` which gives no extra information based on the structure. No constant learning rate would suffice as it would be completely dependent on the distribution of targets.

With reversibility, you'd just go the opposite way. So the reverse of `1,000,000`, `4,000,000`, `9,000,000` would be `1,000`, `2,000` and `3,000` respectively just by taking the square root of the targets. Suppose you started at `0` and were doing iterative reversible updates, then you'd have those values as the analogues of the gradient. Since you have 3 potential values that `x` could be, you'd have an optimization subproblem to solve, but the targets are much more sensible.

I am using this example to highlight how backpropagation does not even remotely do the sensible thing even in the 1D case for a very simple function and to illustrate that reversibility is a property that can be utilized to do credit assignment. Compared to backpropagation updates which exploits the differentiability property of mathematical models, the reversibility updates have an inbuilt invariance to the structure of object being optimized that taking the derivatives does not provide, even at higher order.

# The 3d example with a single target

Suppose a function `f(a,b,c) = (a*b)*c`. I am putting the parenthesis explicitly to indicate the order of operations which matter for the backprop pass. For the squared error function and some `target`, the derivative with respect to `a` would be `(target - a*b*c)*c*b`. In other words, supposing you have a target, what you would do is take the derivative of the squared error, and then on the backward pass multiply it by `c` and then by `b`.

With reversibility what you would do on the backward pass is instead divide target by `c` and then by `b`. Much like the chain rule of the derivative from which the backprop updates are derived, the rules of reversibility similarly have a local character. Given arbitrary reversible functions of `f(g(x))=target`, the reversibility target values for `x` would be `f'(g'(target))` where `f'` and `g'` are inverse function of `f` and `g` respectively.

Suppose `a=1,b=2,c=4` and `target=16`. Then `a*b*c=8`. Then the backprop update for `a` would be `(target - a*b*c)*b*c = 64`.
To calculate the reversibility update you'd first calculate `a*b*c=8`, pretend `8` is `16` and then do the backward steps. `16/4/2=2`, meaning that target update of `a` is `2`. This to me is a very sensible target for what `a` should be, and is a very sensible way of doing credit assignment.

With backprop, suppose you have `b=100,c=100` and the target is anything. I really doubt that multiplying by `100` twice on the backward pass is what you want to be doing for **any** kind of credit assignment method. Because the update for `a` at that point would be way out of proportion. Clearly the right operation from the credit assignment perspective here is division and one should try very hard to justify why exactly it should be multiplication.

If `a`,`b`,`c` were actual layers in a NN, and the domain was RL, the conclusion would be that neural networks cannot learn reward magnitudes. This is actually the case in practice.

Unlike backprop which updates all the variables at once, with reversibility you have more options.

Going back to the previous example of `a=1,b=2,c=4`, consider that the algorithm is at the last step which is `(a*b)*c=8` with the `target_c=16`. Then supposing one wanted to update `c`, one knows that `a*b=2` based on the preceding steps. Then based on `target_c` and the preceding step, one can infer what `c` should be, namely `8` here.

This actually is not end of it, as one has to propagate the values all the way to `a`. So `target_b=target_c/c` with the updated `c=8` is `2`. `b=2` and the `target_b=2` so there is no need to make any changes. `target_a=target_b/b=1`. Then the `target_a` for `a` is `1`. As `a=1`, than requires no changes.

As further example to illustrate what happens when a certain layer cannot set the error to zero, suppose `a=1,b=2,c=4` are bounded in the range `[1,4]`.

Then given `c=4` and `target_c=16`, the algorithm could not reduce the distance between them by setting `c` closer to `target_c`. `target_b=target_c/c=4` and `b=2`. You can set `b=4` here, and then on the final step `target_a=target_b/b=1` and `a=1` so the algorithm has converged.

# Proposal

At this point by imagining what would happen when scalar variables were replaced by big matrices and invertible non-linearities such as tanh and sigmoid were inserted in the previous example, you can see what I want to suggest is the canonical credit assignment scheme.

What I haven't mentioned just yet is how one would reverse `a*b` when one of the variables is `0`. At a bigger scale when `a` and `b` are matrices, for non-trivial square matrices there are infinitely many values for which they might be non-invertible, and many matrices are not even square. From experience, I can say that even for square matrices non-invertibly is a frequent occurrence so this is something that must be addressed.

To this I can offer three points.

1) Rather than wave our hands, it would be better to treat non-reversibility like a C compiler would treat undefined behavior - as an opportunity for optimization. In `x * W = y`, having `W` be non-square for example is not the end of the world when it comes to reversing the function. In the domains under consideration you would usually have `x` which is one of the inputs used in the production of `y`, so if you set `y` to `y'` you can assume that `x'` will have some relation to `x` rather than being completely arbitrary. You can get `x'` in `x' * w = y'` by optimizing `x'` for both the distance to `x` and `y'`. I'd guess that if SGD + backprop were tools of choice, it would suffice to just set `x'` to `x` as the starting point of the optimization process rather than have the distance between `x` and `x'` be an explicit goal.

2) You do not actually really care what `x'` is. Apart from satisfying the optimization goal, you do not care what the specific `x'` is, but what would be good property to have is to make sure that the optimization process that reverses `y'` into `x'` maximizes entropy between the different `x'`s in a batch (at that particular layer.) I admit that at this point this is only a heuristic. It should be better than not maximizing entropy, but might be worse than doing something very specific.

3) While maximizing the entropy between `x'`s, what would also be good is if the lower layers do not have to do too much work to adapt to them. It would best if the lower layers do not have to be retrained from scratch every time the update is done.

Those 3 criteria narrow down what the optimization process should be doing.

Furthermore, in the hidden layers it is not as simple as inverting the matrix anyway.

Since `x * W = y` due to linearity properties that means that `x'` could be `100 * x` and `y'` could be `100 * y` and `100 * x' * W = 100 * y'`. If `x=0.5` it could be that you might trying to pass a target of `50` through the `tanh` activation whose range is between [-1,1]. You actually need the optimization process to linearize the targets, so the lower layers get something that is well defined in all cases.

Typically, NNs are a matrix multiply followed by an activation, but in this framework it would make more sense to think of them as activation followed by matrix multiply.

# The algorithm

I am going to consider the full batch case here. 

For an arbitrary NN model with arbitrary number of layers, starting from the top layer:

1) Train the weights to convergence.

2) Assuming that the error has not gone to zero (which will usually be the case) and assuming the layer is not the lowest one, optimize the inputs next while keeping the weights fixed. Assuming the layer is not too small, this should always be able to get the error to zero.

3) Use those optimized inputs as targets for the lower layers.

4) Do the above iteratively going from top to bottom.

5) At the lowest layer, the inputs cannot be optimized as they aren't freely generated, but given by the dataset. Instead the residual error left after optimizing the weights is what the network could not learn. As a way a way of synchronizing the layers, compute the outputs given the dataset inputs and the optimized weights and pass them to the next layer.

6) At the next layer, optimize the weights again given the new inputs from the previous layer, compute the new outputs and pass them to the next layer.

7) Repeat that process all the way to the top. This should synchronize all the layers of the network.

# Discussion

    Advantages :
    1) Modularity
    2) More precise credit assignment
    3) Being able to learn reward magnitudes in domains like RL

    Disadvantages :
    1) Not clear how to move to mini-batch mode from full batch.
    2) Overfitting 
    3) Computational complexity higher by a constant factor than regular backprop with SGD.

The advantages of the algorithm are definitely strong. The layers do not have to be NN layers, but any model that is reversible. Discrete or Bayesian or non-differentiable, it will work as long as targets can be produced. And as the first two examples have shown, the credit assignment when done this way should be much more precise than backpropagation.

Even though backprop is the workhorse of modern deep nets, can you really expect that an algorithm that cannot deal with a single variable would be able to scale to the human level as some groups are alluding too? Of course not. From what I can tell based on the 1d example, the backprop update magnitudes are not much more than directed noise. This is not a small thing in a model that might be million dimensional - on that scale, just knowing the right direction to go in should compound over the millions of variables to make it significantly more effective than any algorithm with no effective credit assignment mechanisms such as evolutionary ones.

But that is that.

When doing RL, one of the reasons why the current deep RL algorithms are so brittle is because there is lack of synchronization between layers. In SL, the static inputs and the targets serve to synchronize them, but when the system is consuming what it produces, there definitely needs to be a mechanism to act as a foundation for that.

RL is a different beast than SL. I've known about the issue of learning reward magnitudes. There are various hacks out there such as PopArt, but those cannot adapt to magnitudes not seen in the datasets. Any realistic agent should be able to handle rewards in a very wide range without issue, but with backprop you then run into the issue of the reward magnitudes causing extreme variance in gradients and distributing that through the whole network.

Fundamentally, it makes sense that a learning system should be like a sponge. If you pour water on a sponge, it first soaks up from the top and then spreads orderly as it gets saturated. Similarly, it makes sense that when doing RL the network should absorb the reward magnitudes in the topmost layer much like a sponge. The intermediate layers should be learning good features, so the network should definitely drop that information from the targets past the last layer. By necessity, that information will be in the weights of that layer. In that case, you cannot drop that information if you are multiplying by those same weights. The division is the right operation instead.

The modularity has a benefit in RL that should one want to, one will be able to use accelerated linear RL methods like LSTD and Zap. A year ago I haven't been able to make this work personally with deep nets. I have looked, but I haven't found any papers that have managed to either. Here I expect they would give a marked benefit in convergence time.

As for disadvantages, they are things I do not know how to deal with yet.

For doing minibatch learning, I suppose one option is to use a metalearning method like Reptile though it would be a hack. Strictly speaking, the right answer to the issues needing to use full batch learning would be dataset compression. This is definitely right, but at this point this is an unknown area to me so I won't say anything more on this.

Overfitting I think would be a huge issue in RL if not for SL with this method. If what I am proposing is right, then it really might be worth it to look into Bayesian methods. I never paid them much mind as I saw them as unscalable, but the principle of reversibility should act as a glue for more local models, so I have a reason to actual pay attention to them now. I think it would be too much to hope for a online Bayesian update for linear models.

Lastly, because of the sheer number of optimization steps compared to standard backprop + SGD, what I am proposing here will definitely have higher computational complexity that the regular thing. It should be possible to improve on this with research.

# Related work

I may have reinvented target prop.

# Conclusion

Let me do that literature review first. The framework should be good, but it feels too good to be true at the moment. Though reversibility is likely to be the primary principle of learning - by Ocam's razor it is either it or some complete magic needing some magic models. It is disconcerting though that reversibility is a principle of optimization that no serious ML contender really exploits models with such a property in a major way.

Just why is that?

Date: 9/14/2019

I wrote the above as an exercise to carve my expectations of what properties the proposed algorithm should have and then did a short literature review. Let me try the related work section again. I originally meant to post it on the ML sub, so the initial writing style reflects that, but I do not need to do that anymore. Let me turn these entries into the biography of the idea.

# Related Work

https://arxiv.org/abs/1412.7525
Difference Target Propagation

As expected, what I am trying to do bears striking resemblance to target prop. That having said, the authors here aim for biological plausibility, rather than doing inference from 1d examples to derive the algorithm. From my framework, I'd say that the assumption that autoencoder could be training to invert a function using backprop + SGD is a big one to make.

If their learning process could in fact do what they propose then what they are doing would be sound, but the burden of proof is on them.

As it turns out, the follow up papers on this demonstrate that target prop is unstable as the number of layers goes up.

https://arxiv.org/abs/1803.01834
Conducting Credit Assignment by Aligning Local Representations

I really like this paper as it goes a step closer to what I proposed. In here they demonstrate that optimizing the inputs to serve as targets for the lower layers works in an iterative fashion. I find it highly encouraging that this results in high stability and good performance with deep nets exceeding that of competing methods and even backprop, even if it is only on Mnist and a more complex variant of it. This answers the question why the framework I proposed was not utilized previously - by all appearances Discrepancy Reduction is a very recent discovery. DTP is from 2015, but LRA is just from last year. I can now write off the possibility that somebody else tried it and found it not to work.

LRA does what I anticipated in that the lower layers converge at some point and only the upper ones keep adapting. This sponge like pattern of learning is just what one would expect to see.

https://wvvw.aaai.org/ojs/index.php/AAAI/article/view/4389
Biologically Motivated Algorithms for Propagating Local Target Representations

Here is a more recent paper on the theme. I like this one less as by this point it seems the authors are doing architectural mutation by hand in order to fit to Mnist. I find it debatable whether hacky rules they are proposing will scale beyond Mnist, because ultimately quite a lot of things work on Mnist that then turn out to work nowhere else.

# Conclusion

I am quite happy to see that the work has already been underway in the direction I have anticipated even if it is not to establish reversibility as a principle of learning, but is being done under the guise of biological plausibility. I am not a fan of that in particular. Nobody really knows what the brain does so these kinds of arguments are not more than imitation of form and not substance. You cannot really extend the 'brain plausibly does it' since it is not a principle of either learning or computation, unlike reversibility from which discrepancy reduction falls out.

The LRA paper does not do all that I suggest though. For my reasoning to go fully go through, both the weights and the inputs have to be iteratively trained to convergence. The LRA algorithm does the top down part of propagating credit, but does not do the bottom up part of synchronizing bases which will be an issue in RL.

So now that LRA proved that mini-batches work, the next step is to take advantage of the glue that is discrepancy reduction and find a way to make everything Bayesian. Strictly speaking, the very notion of convergence does not make sense in a learning setting. It is fine if one is just doing model fitting on toy tasks, but the notion that one has the leeway of messing with learning rates in a real life setting is absurd. In supervised learning hyperparameter tuning is merely a drain on time, but in a RL setting that is a danger to the agent's life.

There are few challenges to meet in order to make use of linear Bayesian models for RL:

1) For starters, find an online method of updating Bayesian linear models. Failing that, find a way of doing dataset compression.

2) Credit propagation across time that RL does will make things even more complicated, but maybe there is a Bayesian analogue of LSTD. I saw Bayesian regression being used in Ian Osband's thesis, so there might be something there.

3) Since just the linear part of a layer will be Bayesian, I still have to reverse the inputs through the nonlinearity. Should I just sample the weights and optimize or is there something smarter that I can do? I'd like to remove hard-to-reason, brittle frequentist style of optimization from the picture entirely if possible so something smarter would be great.

# Current status

Those 3 points do not seem easy at all. At this time I am trying to improve my foundational mathematical knowledge, so for the time being I will continue with the math lectures that I am watching rather than try to force the ideas. I'll keep the thread in mind and pick it up later as I gain further insights. It might be months or even longer from now.