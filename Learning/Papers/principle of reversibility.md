# Date: 9/13/2019

Conjecture: reversibility is the primary principle of learning.

## Motivation

What I will try to do here is try to build from first principles a learning algorithm, and try to convince you that it is a viable alternative to backprop. Right now I can't start work on it just yet as I am busy with other things, so I want to present a few arguments and hopefully get some feedback. I am going to start with some very simple low dimensional examples and later try to extrapolate them to neural networks with arbitrary number of parameters.

For the following two examples, please keep in mind that NNs at their core are sequences of matrix multiplies (plus some other stuff), and that scalar values are just 1x1 matrices. It is possible to have layers with just one variable.

## The 1d example with multiple targets

Let me compare reversibility to backprop.

Consider the function `f(x) = x^2`. Suppose you have 3 targets `1,000,000`, `4,000,000`, `9,000,000`.

On such a function, what would the backprop pass for the squared error `1/2 * (target - f(x)` function?
The derivative of squared error is `target - x^2`, and the derivative of square is `2*x`, so the backprop update for `x` would be `(target - x^2) * 2 * x`.

So if you started `x` out at 1, the gradient for the `1,000,000` target would (rougly) be `2,000,000`. That is a large number.

Starting at zero with backprop for this function would never update at all due to the `2 * x` term. And suppose you started at something like `2,000` and got the `9,000,000` as target. Then the update would be `(9,000,000 - 4,000,000) * 2 * 2,000 = 20,000,000,000`. 

How would you one even set the learning rate for a function like this? Taking the second derivative here would not help as the derivative of `2 * x` is just `2` which gives no extra information based on the structure. No constant learning rate would suffice as it would be completely dependent on the distribution of targets.

With reversibility, you'd just go the opposite way. So the reverse of `1,000,000`, `4,000,000`, `9,000,000` would be `1,000`, `2,000` and `3,000` respectively just by taking the square root of the targets. Suppose you started at `0` and were doing iterative reversible updates, then you'd have those values as the analogues of the gradient. Since you have 3 potential values that `x` could be, you'd have an optimization subproblem to solve, but the targets are much more sensible.

I am using this example to highlight how backpropagation does not even remotely do the sensible thing even in the 1D case for a very simple function and to illustrate that reversibility is a property that can be utilized to do credit assignment. Compared to backpropagation updates which exploits the differentiability property of mathematical models, the reversibility updates have an inbuilt invariance to the structure of object being optimized that taking the derivatives does not provide, even at higher order.

## The 3d example with a single target

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

## Proposal

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

## The algorithm

I am going to consider the full batch case here. 

For an arbitrary NN model with arbitrary number of layers, starting from the top layer:

1) Train the weights to convergence.

2) Assuming that the error has not gone to zero (which will usually be the case) and assuming the layer is not the lowest one, optimize the inputs next while keeping the weights fixed. Assuming the layer is not too small, this should always be able to get the error to zero.

3) Use those optimized inputs as targets for the lower layers.

4) Do the above iteratively going from top to bottom.

5) At the lowest layer, the inputs cannot be optimized as they aren't freely generated, but given by the dataset. Instead the residual error left after optimizing the weights is what the network could not learn. As a way a way of synchronizing the layers, compute the outputs given the dataset inputs and the optimized weights and pass them to the next layer.

6) At the next layer, optimize the weights again given the new inputs from the previous layer, compute the new outputs and pass them to the next layer.

7) Repeat that process all the way to the top. This should synchronize all the layers of the network.

## Discussion

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

## Related work

I may have reinvented target prop.

## Conclusion

Let me do that literature review first. The framework should be good, but it feels too good to be true at the moment. Though reversibility is likely to be the primary principle of learning - by Ocam's razor it is either it or some complete magic needing some magic models. It is disconcerting though that reversibility is a principle of optimization that no serious ML contender really exploits models with such a property in a major way.

Just why is that?

# Date: 9/14/2019

I wrote the above as an exercise to carve my expectations of what properties the proposed algorithm should have and then did a short literature review. Let me try the related work section again. I originally meant to post it on the ML sub, so the initial writing style reflects that, but I do not need to do that anymore. Let me turn these entries into the biography of the idea.

## Related Work

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

## Conclusion

I am quite happy to see that the work has already been underway in the direction I have anticipated even if it is not to establish reversibility as a principle of learning, but is being done under the guise of biological plausibility. I am not a fan of that in particular. Nobody really knows what the brain does so these kinds of arguments are not more than imitation of form and not substance. You cannot really extend the 'brain plausibly does it' since it is not a principle of either learning or computation, unlike reversibility from which discrepancy reduction falls out.

The LRA paper does not do all that I suggest though. For my reasoning to go fully go through, both the weights and the inputs have to be iteratively trained to convergence. The LRA algorithm does the top down part of propagating credit, but does not do the bottom up part of synchronizing bases which will be an issue in RL.

So now that LRA proved that mini-batches work, the next step is to take advantage of the glue that is discrepancy reduction and find a way to make everything Bayesian. Strictly speaking, the very notion of convergence does not make sense in a learning setting. It is fine if one is just doing model fitting on toy tasks, but the notion that one has the leeway of messing with learning rates in a real life setting is absurd. In supervised learning hyperparameter tuning is merely a drain on time, but in a RL setting that is a danger to the agent's life.

There are few challenges to meet in order to make use of linear Bayesian models for RL:

1) For starters, find an online method of updating Bayesian linear models. Failing that, find a way of doing dataset compression.

2) Credit propagation across time that RL does will make things even more complicated, but maybe there is a Bayesian analogue of LSTD. I saw Bayesian regression being used in Ian Osband's thesis, so there might be something there.

3) Since just the linear part of a layer will be Bayesian, I still have to reverse the inputs through the nonlinearity. Should I just sample the weights and optimize or is there something smarter that I can do? I'd like to remove hard-to-reason, brittle frequentist style of optimization from the picture entirely if possible so something smarter would be great.

## Current status

Those 3 points do not seem easy at all. At this time I am trying to improve my foundational mathematical knowledge, so for the time being I will continue with the math lectures that I am watching rather than try to force the ideas. I'll keep the thread in mind and pick it up later as I gain further insights. It might be months or even longer from now.

# Date: 9/18/2019

There is a natural hierarchy of learning going from best to worst. Full Bayesian > factored Bayesian > batch frequentist > online frequentist. Backprop + SGD fall into the last pile. In return for instability and having to tune hypeparameters, it actually gives a scalable, working algorithm rather than just an ideal.

I really want to use discrepancy reduction to make use of factored Bayesian methods, but I do not think Bayesians have a direct way to do more than one linear layer in an analytical way. There are approximate Bayesian methods that can do this, but I am not sure of their benefits compared to just frequentist methods. I am thinking of expectation propagation methods in Infer.NET for example.

So I am going to just master the regular backprop updates. As a matter of fact, the regular weight update where inputs are multiplied by the gradients is in fact quite similar to Hebbian learning which the brain does. The current rules of backprop are sensible and have proven themselves in the SL arena.

I can anticipate that most likely I will be made to use frequentist methods in the end so let me plan ahead with that reasoning in mind.

Backprop needs to be made to work for RL.

And as a matter of fact, all the pieces are in place for this to happen.

There are three reasons why deep RL is deeply unstable and requires all sorts of hacks to work.

1) The shifting bases.
2) The loose credit assignment.
3) Lack of viable exploration methods.

Discrepancy reduction can take care of the first two, and I've already gone into the philosophy behind it. Rather than the whole network being iteratively optimized, move to a layer by layer bath optimization, aligning the representations top to bottom and then synchronize the layers bottom up after that because the network won't be able to fit the optimized inputs exactly.

There is something I would like to add to what I have written above.

While thinking about the issue from a Bayesian perspective, it occurred to me that Bayesians methods do not have a framework for optimizing the inputs directly. Instead what could be done (in theory) is to update the posteriors two layers in tandem and then recalculate the inputs in the middle based on that as opposed to having the first layer guess what they should be. This could be done for backprop as well.

It is an interesting thought experiment that made me wonder whether the graph should be divided into two layers rather just one. It might be worth trying out. But regardless, by optimizing two layers in tandem the opportunity to do entropy maximization is lost.

This is actually an issue in the head of RL network. Whether it be, AC or Q learning, all RL nets get only a single scalar value from the top, which is then multiplied by the weights to get the gradients for the inputs. Strictly speaking that just drags the inputs up and down in a relatively linear manner as the layer is just a single vector.

Right now it is 2019 and methods like batch norm and KFAC which improve optimization profile of networks is well known. Recentering, rescaling, whitening are all things which have a marked benefit on tasks being done. I've even seen arguments that the brain generates noise as a part of its processing.

My suggestion then would be to after optimizing the inputs into targets for the previous layer would be to collect their statistics and then whiten them. I'd anticipate that this would be helpful everywhere, but especially so in the last layer which needs a good distribution of features to learn properly that might get disrupted due to vagaries of optimization and random initialization.

It is not obvious to me how to make use of factored higher order optimization such as KFAC with discrepancy reduction, but regardless whitening of the targets would ensure that all of the lessons of it are internalized. Whitening the targets will ensure that the network is well conditioned to respond to deviations rather than just meeting the goals in an arbitrary fashion. Unless the weight init is extremely adversarial like being initialized to zero everywhere, whitening of targets will ensure that the network's activation statistics are indistinguishable from noise.

## A plan for RL

Reinforcement learning is not like supervised learning, so it makes sense that the training process would be more elaborate without necessarily having access to completely static targets at the top everywhere. It speaks volumes about the nature of the problem that in biological creatures, sleep is a constant fixture. Being put into a helpless, low energy state for a third of the day or more is a huge risk in the natural world and yet nature could not find a way to eliminate it.

Keeping in mind the hint from biology that purely online learning should be impossible, let me just say that updating just the head while the network is running should be fine. By keeping the lower layers steady during runtime, the basis for the head should be stable which should allow the usage of stable higher order frequentist methods such as LSTD (and its online variant Zap.)

When enough information has been collected at runtime, the network will be taken into its 'sleep' state, updated top down using the method I proposed and synchronized bottom up. That least part means that the head will have to be retrained, just like the other layers.

But since the head is so important, while the lower layers will eventually learn what they have to do and will be able to get away with less training as time progresses, the head will have to take exceptional care that there is no information loss. So while the head can be expected to be small relative to other layers, that is where the most severe efforts will be focused.

### The exploration method

In the absence of Bayesian options, it might be worth looking into the idea I had nearly a year ago. At the time of writing, I was happy with the idea itself, but discouraged with my previous failures, I knew deep down that the credit assignment issues surrounding backprop in the domain of RL would not be ameliorated by it, so I threw in the towel.

That does not mean I did not believe in the method itself. What I think is that with the right credit assignment scheme, it should be quite usable.

The following is a reprint of the PL sub monthly review of Jan 2019 where I first proposed it. Let me put it here so I do not have to dig deep for it in the future.

#### PL sub monthly review of Jan 2019

Last time I ended the month with a foray into curvature based weight sampling. I had a lot of great reason for why that could work great, but it turned out there is no regularization benefit from it in supervised learning nor any exploration benefit in reinforcement learning. As far as I can tell weight sampling is useless - it works a tad worse than regular SGD and that's it. I had a bad feeling when I first tested it on Mnist, and it turned into a heavy blow for me when I finished all the tests.

At that point, I was out of ideas and actually decided to give up on deep RL and study [probabilistic programming](https://www.reddit.com/r/MachineLearning/comments/a5t7wu/d_stuart_russel_probabilistic_programming_and_ai/) along with Bayesian inference. I had no choice, when all the paths seem closed all you can really do is sit down and try studying a different subject. The pain of failed experiments and the trauma of having to wander in the darkness did turn me Bayesian. I understand that deep learning styled techniques simply do not have the power to get all the way to AGI, to get true generalization optimization capable on the level of doing program search is necessary and deep learning is at most capable of doing pattern matching.

Nonetheless, even though I was at dead end I understood that what is currently possible with deep learning is barely a fraction of its true capabilities - gradient based optimization is not going to go away. It will always be an integral part of a learning system and such needs to be mastered.

With the knowledge of how Bayesian inference does uncertainty estimates, when the [randomized prior functions paper](https://arxiv.org/abs/1806.03335) was introduced to me I could immediately see the possibilities of it. Looking through the citations for it, I found the [anchored ensembling paper](https://arxiv.org/abs/1810.05546) and putting it together with the work already done by [Ian Osband](http://iosband.github.io/research.html) I have all the pieces necessary to make the next generation RL algorithm - one that is capable of doing deep exploration.

Technically, Ian already has examples of such algorithms in a deep learning setting, but in my estimate algorithms like randomized prior functions and [random distillation](https://arxiv.org/abs/1810.12894) have really low evolutionary potential. [Ian's thesis](https://searchworks.stanford.edu/view/11891201) is required reading for anybody interested in RL and his work on posterior sampling for RL (PSRL) and randomized least squares value iteration (RLSVI) is first rate, but going into a deep setting the algorithms should take advantage of uncertainty directly otherwise they won't be able to handle non-episodic environments gracefully. In the [bootstrapped DQN paper](https://arxiv.org/abs/1602.04621) he actually tries ensembling and then skips them over in favor bootstrapping and then follows the gradient into randomized prior functions, but as a consequence he misses a evolutionary branch that could lead to a much better algorithm.

Make no mistake, at the present time all the deep RL algorithms are completely broken. Though the field is complete hype, it will not take too much to overturn the state of affairs and most importantly if I want to actually derive any value from it the responsibility for making the crack lies upon me.

For the sake of mastering deep exploration in model-free RL, I will propose a new algorithm that does explicit uncertainty propagation using anchored ensembling. At this point (12/27/2018) it is yet untested; I only planned it out in the last week and I need to implement it and the tests for it so everything past this point will be conjecture. If they turn out correct though, I will have something that will work exponentially better than the current actor-critic that I am using and that will be enough to stop me from ordering take-out from the nearby dumpster. I've wasted a lot of time over the past [8 months](https://www.reddit.com/r/reinforcementlearning/comments/8cn7m5/d_how_to_do_optimistic_initialization_for_deep_rl/) on failed experiments; I am really lucky that resolving exploration is the single most important thing that could be done at this juncture and it does not look like it will be too hard.

---

First let me start out by describing ensembling. Let me draw a little picture in ASCII.

    input -> network1 -----> cost function
    input -> network2 -----> cost function
    input -> network3 -----> cost function
    input -> network4 -----> cost function

All the `input`s are assumed to be the same here. Typically ensembling is done by [independent training](https://arxiv.org/abs/1511.06314).

    input -> network1 -----> mean -----> cost function
    input -> network2 --------^ 
    input -> network3 --------|
    input -> network4 --------|

You could add them all up and take the mean before passing them into the cost function, but that would lose the diversity benefits of training separate networks. However, there is an alternative that could retain those benefits. That is to optimize the variance directly. Rather than doing a reduction to the mean, it is also possible to reduce to the variance.

                            (mean -> cost function) (variance -> local contraction) 
                              ^                       ^
    input -> network1 --------|-----------------------|
    input -> network2 --------|-----------------------|
    input -> network3 --------|-----------------------|
    input -> network4 --------|-----------------------|

I am not sure if passing the mean into the cost function and then optimizing the variance separately is completely equivalent to training each network independently, but at least it should be almost equivalent and can be expected to retain the diversity benefits of ensembling. Diversity is actually a significant advantage that ensembling has over weight sampling. I suspect that the reason weight sampling worked so poorly for me is because it was just drawing from around the same mode.

At first glance it does not seem like this is much of a change from the original, but by having to access to explicit uncertainty values it becomes possible to go from doing inference to doing nested inference which opens the door to a whole new range of algorithms. The square root of the `variance`, its `scale` is a direct uncertainty measure of the variable being estimated and can be used as intrinsic motivation in a RL system such as for example, by passing it directly to the actor.

It is possible to do better than that though. Rather than doing such local contractions of uncertainty which would be better suited for supervised learning, in reinforcement learning one could imagine that taking the difference of `scale` at the present timestep and the next and using that as intrinsic reward would have much less variance.

With that let me introduce Temporal Difference with Uncertainty Propagation (TD+).

    value = (value - (reward + discount_value * value'))^2
    scale = (scale - discount_scale * scale')^2

It is much the same as regular TD learning except now it explicitly propagates uncertainty. The discounts for the two need not be the same. In fact in non-episodic settings the only way for uncertainty to get reduced to zero is by using discount factors. I think that relatively small ones like 0.9 and 0.95 should be suitable for `scale`s whereas lot larger factors for the `value`s would be preferable. TD learning will lead to smooth propagation of uncertainty and could even be combined with concepts like eligibility traces. Local contraction of variance like in supervised learning corresponds to an implicit `discount_scale` of 0.

In episodic tasks a `discount_scale` of 1 would work as the terminal state would have uncertainty of 0 that would get propagated.

---

That takes care of intrinsic rewards, but in an actor-critic system there is one more issue to take care of. It goes back to how it is not possible to just add up the values if the benefits of diversity in an ensemble are intended to be retained. Rather it is necessary to find a way to reduce uncertainty explicitly as well.

One could use the uncertainty propagation scheme introduced earlier, but in my view that piece does not fit here. Rather the correct thing to do for the actor would be to take the `mean` and the `scale` and use them to sample from a Gaussian distribution. Those would be the inputs to the softmax that policy gradient methods use. On backward pass this can be backproped through using the reparameterization trick.

The Gaussian sampling method I am proposing here for the sake of doing ensemble reduction has an interesting property. In a supervised learning setting it would be possible to replace the local contraction of variance with it. What that would result in that after minimizing the epistemic (model) uncertainty, the ensemble would switch to modeling the aleatoric (data noise) uncertainty instead.

So that might make it possible to learn stochastic policies without having to use the softmax even with discrete actions, but the main aim of this here is to instead of dumbly driving the uncertainty for the actions to zero regardless of whether they are used or not, to let the network take care of uncertainty in a more natural manner. It would be better not to use local cost functions for variance minimization unless they are absolutely necessary. The motivation is similar to why one would avoid having to do explicit mutation unless necessary in regular programming.

There is [some indication](https://youtu.be/HAaixlzDDQQ) that modeling aleatoric uncertainty as in [distributional RL](https://arxiv.org/abs/1710.10044) is beneficial on its own for performance.

---

This is the Plan for the next month. I'll have report for how the TD+ algorithm works when the next monthly thread comes around. I understand that I stick out in these threads for not talking about PL, but I hope that if I can get this work it will let me finally move on to the engineering side of things. Even if it does work as well as I want it to, it will take several breakthroughs of the same magnitude to get to the AGI level. As important as finding those cracks is, it is more important that I find a better place to live than a cardboard box under the bridge.

I am really lucky that my current target which is poker is a very artificial problem, much like Chess and Go. It is greatly suited for computers and not much for humans. This means that I do not need things like hierarchical learning as much as I would need to otherwise. Good exploration is the one thing that is absolutely vital in order to make learning robust and break the dependency on random seeds. I cannot do without it. It was the first thing I tried looking into when I started 8 months ago, but I could not find anything that meet my criteria. TD+ definitely does apart from the small part of it being currently untested.

If I could get this to work, I will have surmounted my position of weakness and will be able to show my true power. I will be able to make machines that can crush the weak!

Merry Christmas and a happy New Year everyone.

## Conclusion

The above method of using the agreement between multiple networks as a measure of uncertainty would probably be need to be modified and simplified to work with LSTD in the value network, but the principles should be sound. Without a doubt, purely frequentist notions of exploration such as the above should be fine. And reversibility-inspired discrepancy reduction algorithms are the truth of credit assignment.

Even if all of this works exactly as planned, there is of course no way that this will be enough to create truly intelligent agents. But still, having the optimization processes working properly in RL is just a matter of good design. Before mastery can be attained, first deep RL needs to be upgraded to a working state on toy tasks. That would be the first major step towards having the neural networks live up to their promise.

Right now, I personally am convinced of what I preach. So at this point I've already started planning of how I am going to implement all of this. When I am done with my current studies, that is what I am going to do. It is going to be great.

# Date: 9/20/2019

Note: I just remembered that the Cholesky factorization inserts random rotations into the whitening matrix. That might make synchronization difficult. There are different matrix factorization schemes that can be used to do whitening, and [ZCA](https://arxiv.org/abs/1512.00809) preserves rotational ordering. That having said, Cholesky + updating the weights directly might work with some engineering. Just using KFAC is worth considering as well.

If possible, I'd want to make use of Cholesky decomposition for doing whitening as it is faster than other procedures.

Also, for a while I've known that there is a deep connection between KFAC and PRONG, but I've yet to see the proof that they are equivalent written out. Here it is.

## Proof that KFAC is equivalent to PRONG

Suppose `b` is a 1d whitening matrix, `a` is the weight matrix and `c` is the two combined. What is the update for different values of `b`? Considering that the update rule for `a` is `a' = a + gradient * b` then...

```
c = a * b, grad = 1, a' = a + grad * b
a = 1, b = 1, c = 1 -> a' = 2, b = 1, c' = 2
a = 0.5, b = 2, c = 1 -> a' = 2.5, b = 2, c' = 5
a = 0.25, b = 4, c = 1 -> a' = 4.25, b = 4, c' = 17
```

Now suppose `a` and `b` are not separate as in PRONG, but we have `a * b` and `b` like in KFAC. Then updating the weight matrix does not produce correct results using the `c' = c + gradient * b` rule.

```
c = a * b
c = 1 -> b = 1 -> c' = 2
c = 1 -> b = 2 -> c' = 3 // Should be 5.
c = 1 -> b = 4 -> c' = 5 // Should be 17.
```

As shown above the right relationship implies that right quantity for multiplying the gradient is the square of `b`. `a * b` after the update would be `(a + gradient * b) * b = a * b + gradient * b * b`. Meaning `b * b` is what should be used here to add to the gradient just as the first example implies.

The proof involving multidimensional matrices rather than scalars is similar.
