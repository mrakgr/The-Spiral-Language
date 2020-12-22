<!-- TOC -->

- [Motivation](#motivation)
- [Regret Matching](#regret-matching)
    - [F# Version](#f-version)
    - [Spiral Version](#spiral-version)
    - [Pharo Version](#pharo-version)
- [Performance Comparison](#performance-comparison)
- [Code Analysis](#code-analysis)
- [Conclussion](#conclussion)
- [Spiral Version (Compiled)](#spiral-version-compiled)

<!-- /TOC -->

# Motivation

Date: 3/10/2019

I've been working on Spiral for over two years now, but I've never really managed to get a chance to do a performance comparison on something non-convoluted with other languages. Over a year ago, I benchmarked it against F# on [parser combinators](https://github.com/mrakgr/The-Spiral-Language/tree/821732b9e0199d72634fc0f2eecbdce81ac3838a#4-continuation-passing-style-monadic-computation-and-parsing), but I would consider that convoluted.

In an ironic twist of fate I've never actually found a place where performance was important to me in my days of programming in Spiral. I needed the sheer expressiveness of its staging to do generic GPU kernels so I could make a ML library, but the actual performance of the glue code in the ML library was of no interest to me. The main goal was information propagation rather than code performance and Spiral was wonderful in that aspect. The advent of the GPU really blew a hole in most programming language models which is why Spiral had to come into being.

At the moment, I am studying [counterfactual regret minimization](http://modelai.gettysburg.edu/2013/cfr/cfr.pdf) and have been pitting F# and Pharo in my mind as languages. Since the regret matching algorithm is non-trivial, but not too complex either, it occurred to me that I should throw Spiral into the mix as well and do a write up on this.

# Regret Matching

Back in 2017, [Libratus](https://en.wikipedia.org/wiki/Libratus) which used CFR was used to crush the poker pros at heads up NL Holdem.

Regret matching is a tabular RL algorithm that is the predecessor to it. 

The way it works is that the player will pick an action and then compare it to all the actions it could have potentially taken at every step. Then using that information update its policy.

```
let sample_and_update player = 
    /// Normalized sum of regret is the action/policy distribution.
    /// Actions being in a distribution means that every possible action has a probability that weights it.
    /// Sampling rather than being uniform is weighted by those probabilities.
    let action_distribution = normalize player.regret_sum
    /// `strategy_sum` is the sum of action distributions and is not actually used during play.
    /// `add_sum` is just a mutable vector addition function.
    add_sum player.strategy_sum action_distribution
    /// Sampling from the action distribution selects an action.
    sample action_distribution

/// This is the function that updates the sum of regrets which is related to the policy.
let update_regret one (action_one, action_two) =
    /// Computes the utility for player `one` given the actions taken by player `one` and `two`.
    let self_utility = utility(action_one, action_two)
    /// Iterates over all the actions and mutably adds them to the sum.
    add_regret one.regret_sum (fun a -> utility (a, action_two) - self_utility)

/// When the players are the same, this does self-play.
let vs (one : Agent, two : Agent as players) = 
    let action_one = sample_and_update one
    let action_two = sample_and_update two
    update_regret one (action_one, action_two)
    update_regret two (action_two, action_one)

let train (one : Agent, two : Agent as players) iterations = for i=1 to iterations do vs players
```

The first 3 functions here form the core of the regret matching algorithm. The rest of the what will be shown are the helpers.

The agent itself only has two fields which are float arrays.

```
type Agent = 
    {
    strategy_sum: float[]
    regret_sum: float[]
    }
```

Hopefully the comments make what the algorithm does clear. Here is the full F# version with the helpers included. It is a relatively straightforward translation from the paper.

It is a good 90 lines, which is why I picked this problem for a performance comparison. Please feel free to just skim these and go to the [performance comparison](#performance-comparison) if you'd like.

## F# Version

```
let rng = System.Random()

type Setting = {num_fields: int; num_soldiers: int}
type Agent = 
    {
    strategy_sum: float[]
    regret_sum: float[]
    }

let utility (action_one, action_two) =
    Array.map2 compare action_one action_two
    |> Array.sum |> float

/// Initializes the actions for the General Blotto Vs Boba Fett example from the paper.
let init (d: Setting) =
    let ar = ResizeArray()
    let temp = Array.zeroCreate d.num_fields
    let rec loop field soldiers_left =
        if field < d.num_fields then
            for soldier=0 to soldiers_left do
                temp.[field] <- soldier
                loop (field+1) (soldiers_left-soldier)
        elif soldiers_left = 0 then ar.Add(Array.copy temp)
    loop 0 d.num_soldiers
    ar.ToArray()

let actions = init {num_fields=3; num_soldiers=5} // `{num_fields=3; num_soldiers=5}` would be 21 different possible actions.
   
let normalize array =
    let temp = Array.map (max 0.0) array
    let normalizingSum = Array.sum temp

    if normalizingSum > 0.0 then Array.map (fun x -> x / normalizingSum) temp
    else Array.replicate temp.Length (1.0 / float actions.Length)

let add_sum (sum: float[]) x = Array.iteri (fun i x -> sum.[i] <- sum.[i] + x) x
let add_regret (sum: float[]) f = Array.iteri (fun i x -> sum.[i] <- sum.[i] + f x) actions

let sample (dist: float[]) =
    let r = rng.NextDouble()
    let rec loop a cumulativeProbability =
        if a < actions.Length then 
            let cumulativeProbability = cumulativeProbability + dist.[a]
            if r <= cumulativeProbability then actions.[a]
            else loop (a+1) cumulativeProbability
        else 
            failwith "impossible"
    loop 0 0.0

let sample_and_update player = 
    /// Normalized sum of regret is the action/policy distribution.
    /// Actions being in a distribution means that every possible action has a probability that weights it.
    /// Sampling rather than being uniform is weighted by those probabilities.
    let action_distribution = normalize player.regret_sum
    /// `strategy_sum` is the sum of action distributions and is not actually used during play.
    /// `add_sum` is just a mutable vector addition function.
    add_sum player.strategy_sum action_distribution
    /// Sampling from the action distribution selects an action.
    sample action_distribution

/// This is the function that updates the sum of regrets which is related to the policy.
let update_regret one (action_one, action_two) =
    /// Computes the utility for player `one` given the actions taken by player `one` and `two`.
    let self_utility = utility(action_one, action_two)
    /// Iterates over all the actions and mutably adds them to the sum.
    add_regret one.regret_sum (fun a -> utility (a, action_two) - self_utility)

/// When the players are the same, this does self-play.
let vs (one : Agent, two : Agent as players) = 
    let action_one = sample_and_update one
    let action_two = sample_and_update two
    update_regret one (action_one, action_two)
    update_regret two (action_two, action_one)

let train (one : Agent, two : Agent as players) iterations = for i=1 to iterations do vs players

let player = 
    { 
    regret_sum = Array.replicate actions.Length 0.0
    strategy_sum = Array.replicate actions.Length 0.0
    }

let timer = System.Diagnostics.Stopwatch.StartNew()
train (player,player) 10000000
printfn "%A" timer.Elapsed

let print player =
    Array.iter2 (printfn "%A = %f") actions (normalize player.strategy_sum)
    printfn "---"

print player
```

## Spiral Version

```
inl rng = Random()

inl utility (action_one, action_two) =
    Array.map2 (inl a b -> if a > b then 1 elif a < b then -1 else 0) action_one action_two
    |> Array.sum |> inl convert -> Type type: 0.0 convert:

inl init d =
    inl temp = Array.replicate d.num_fields 0
    inl ar = ResizeArray type: temp
    inl rec loop field soldiers_left = join
        if field < d.num_fields then
            Loop.for from: 0 to: soldiers_left
                body: inl i:soldier ->
                    temp at: field put: soldier
                    loop (field+1) (soldiers_left-soldier)
        elif soldiers_left = 0 then ar Add: Array.copy temp
        : ()
    
    loop 0 d.num_soldiers
    ar.ToArray

inl actions = init {num_fields=3; num_soldiers=5}
   
inl normalize array = join
    inl temp = Array.map (max (dyn 0.0)) array
    inl normalizingSum = Array.sum temp

    if normalizingSum > 0.0 then Array.map (inl x -> x / normalizingSum) temp
    else Array.replicate temp.length (1.0 / Type type: 0.0 convert: actions.length)

inl add_sum sum x = Array.iteri (inl i x -> sum at: i add: x) x
inl add_regret sum f = Array.iteri (inl i x -> sum at: i add: f x) actions

inl sample dist =
    inl r = rng.NextDouble
    inl rec loop a cumulativeProbability = join
        if a < actions.length then 
            inl cumulativeProbability = cumulativeProbability + dist at: a
            if r <= cumulativeProbability then actions at: a
            else loop (a+1) cumulativeProbability
        else 
            failwith type: actions.elem_type msg: "impossible"
        : actions.elem_type
    loop (dyn 0) (dyn 0.0)

inl sample_and_update player = 
    inl action_distribution = normalize player.regret_sum
    add_sum player.strategy_sum action_distribution
    sample action_distribution

inl update_regret one (action_one, action_two) =
    inl self_utility = utility(action_one, action_two)
    add_regret one.regret_sum (inl a -> utility (a, action_two) - self_utility)

inl vs (one, two as players) =
    inl action_one = sample_and_update one
    inl action_two = sample_and_update two
    update_regret one (action_one, action_two)
    update_regret two (action_two, action_one)

inl train (one, two as players) to = Loop.for (from:1 to:) (body: inl i: -> vs players)

inl player = 
    { 
    regret_sum = Array.replicate actions.length 0.0
    strategy_sum = Array.replicate actions.length 0.0
    }

TimeIt
    message: "loop"
    body: inl _ -> train (player,player) 10000000

inl print player =
    Array.iter2 (inl a b -> Console.writeline b) actions (normalize player.strategy_sum)
    Console.writeline "---"

print player
```

The Spiral is fairly similar to the F# version. The language itself is based on F# in terms of syntax with some recent additions like keyword arguments which are inspired by Smalltalk.

## Pharo Version

The Pharo version is not a script, but spread out across files, so I am going to have to paste a bunch of methods and classes by hand for the sake of illustration. Here is [the link](https://github.com/mrakgr/Pharo-Examples/tree/792db114901f8cffaf85a40a48e4ffb3fca12686) to the repo where all the code can be found in its original form.

Here is the `Agent` class.

```
Object subclass: #Agent
	instanceVariableNames: 'regret strategy actions'
	classVariableNames: ''
	package: 'CFR-Extensions'
```

The methods for it.

```
actions
	^ actions

actions: aCollection
	actions := aCollection.
	regret := self createArray.
	strategy := self createArray.

createArray
	^ NormalizedArray new: self actions size withAll: 0.0

increaseRegret: block
	1 to: regret size do: [ :i |
		regret at: i incrementBy: (block value: (self actions at: i))
		]

increaseStrategy: strategyNew
	1 to: strategy size do: [ :i |
		strategy at: i incrementBy: (strategyNew at: i)
		]

regret
	^ regret normalized

strategy
	^ strategy normalized

updateAndSample
	| actionDistribution |
	actionDistribution := self regret.
	self increaseStrategy: actionDistribution.
	^self actions sample: actionDistribution.

updateRegret: myAction and: otherAction
	| selfUtility |
	selfUtility := myAction vs: otherAction.
	self increaseRegret: [ :a | (a vs: otherAction) - selfUtility ]

vs: otherAgent
	| actionSelf actionOther |
	actionSelf := self updateAndSample.
	actionOther := otherAgent updateAndSample.
	self updateRegret: actionSelf and: actionOther.
	otherAgent updateRegret: actionOther and: actionSelf.

vsFixed: actionDistribution
	| actionSelf actionOther |
	actionSelf := self updateAndSample.
	actionOther := self actions sample: actionDistribution.
	self updateRegret: actionSelf and: actionOther.

vsSelf
	self vs: self.
```

Here is the `NormalizedArray` class.

```
Array variableSubclass: #NormalizedArray
	instanceVariableNames: ''
	classVariableNames: ''
	package: 'CFR-Extensions'
```

And the methods for it.

```
normalized
	| temp normalizingSum |
	temp := self collect: [ :each | each max: 0.0 ].
	normalizingSum := temp sum.
	^ normalizingSum strictlyPositive
		ifTrue: [ temp collect: [ :each | each / normalizingSum ] ]
		ifFalse: [ temp class new: temp size withAll: 1.0 / self size ]

printElementsOn: aStream
	aStream nextPut: $(.
	self normalized
		do: [:element | aStream print: element showingDecimalPlaces: 3; nextPut: $%] 
		separatedBy: [aStream space].
	aStream nextPut: $)
```

I had to extend `SequenceableCollection` with some helpers.

```
sample: aDistribution
	^self sample: aDistribution with: SharedRandom globalGenerator next.

sample: aDistribution with: probability
	"Samples from the collection given a distribution and a target probability."
	| probabilityIndex |
	probabilityIndex := 0.0.
	1 to: self size do: [ :i |
		probabilityIndex := probabilityIndex + (aDistribution at: i).
		probability <= probabilityIndex ifTrue: [^self at: i].
		].
	self error.
```

Here is action initialization. Since the other examples take advantage of lexical scoping which Pharo does not feature, this was the only part I really found annoying to rewrite. This is the `BlottoActionInit` class.

```
Object subclass: #BlottoActionInit
	instanceVariableNames: 'temp actions'
	classVariableNames: ''
	package: 'CFR-BlottoVsBoba'
```

Its methods. Note that the loop goes top to down in Pharo unlike in the F# and the Spiral version.

```
loop: field and: soldiersLeft
	field >= 1
		ifTrue: [ 
			0 to: soldiersLeft do: [ :i |
				temp at: field put: i.
				self loop: field - 1 and: soldiersLeft - i.
				]
			] 
		ifFalse: [ 
			soldiersLeft = 0
				ifTrue: [ 
					actions add: temp copy.
					]
			 ]

numFields: f numSoldiers: s
	temp := BlottoAction new: f.
	actions := OrderedCollection new.
	self loop: f and: s.
	^actions asArray.
```

They are used by the `BlottoAction` class which is an `Array` inheritor.

```
Array variableSubclass: #BlottoAction
	instanceVariableNames: ''
	classVariableNames: ''
	package: 'CFR-BlottoVsBoba'
```

Its instance methods.

```
vs: otherAction
	^(self with: otherAction collect: [ :a :b | (a - b) sign ]) sum. 
```

Its class methods.

```
numFields: f numSoldiers: s
	^BlottoActionInit new numFields: f numSoldiers: s
```

# Performance Comparison

Going into this I was not sure exactly what I would get. For all I knew it was possible that F# would inline the higher order functions just as Spiral does and the two would get the same performance. This code while not trivial is not monadic auto-differentiation in GPU kernels, so it is plausible that Spiral might not do much better than F# on this example.

Also, I expected F# to be faster than Pharo, but I was not sure by how much exactly.

I've gotten burned by microbenchmarks in the past and realized that I had to use specialized benchmarking library to get a proper comparison, but here since this is an optimization process rather than a function called on repeat, I will just let it run for 10 million iterations and be done with it. I would not warm up the JIT for the sake of benchmarking a ML library, so neither will I do it for this.

Results over three runs:

```
Spiral - [00:00:14.5650705; 00:00:14.6026277; 00:00:14.5350645]
F# - [00:00:50.2958043; 00:00:50.0817172; 00:00:50.5535692]
Pharo - [00:02:46.007; 00:02:33.502; 00:02:40.679]
```

So there is a roughly 3x difference in performance between each of the languages.

Despite the 10x gap between Spiral and Pharo, I would not consider it a particularly slow language. It is certainly fast enough to be usable. It is certainly faster than intepreting over union types in F# and Spiral which is what it would take to get the same level of dynamism in those two languages. I've read that Pharo thanks to its JIT could be expected to be 100x faster than Python or Ruby which are known as slow languages, and this test demonstrates that there might be something to that notion.

The code written in Pharo while being slower does have the benefit of being the most generic of the 3 versions.

# Code Analysis

What makes this code challenging for the compilers? 

```
inl utility (action_one, action_two) =
    Array.map2 (inl a b -> if a > b then 1 elif a < b then -1 else 0) action_one action_two
    |> Array.sum |> inl convert -> Type type: 0.0 convert:
```

```
let utility (action_one, action_two) =
    Array.map2 compare action_one action_two
    |> Array.sum |> float
```

```
vs: otherAction
	^(self with: otherAction collect: [ :a :b | (a - b) sign ]) sum. 
```

It would be all the iteration over the collections which allocates new collections. If the `compare` and the block passed into `with:collect:` are heap allocated the and in the case of Pharo if it needs to go through runtime typechecking the performance will suffer.

This code could be speed up significantly by doing more inplace updates. For example...

```
let utility (action_one, action_two) = Array.fold2 (fun s a b -> s + compare a b) 0 action_one action_two |> float
```

...`utility` could be implemented like this so as to avoid allocating an intermediate array over which to sum over. Similar spots could be found in other places. It would not change the rankings between the languages though and that is the point of this performance comparison. It is to see how three different languages handle a program with a moderate level of abstraction.

The Spiral approach to getting performance is to take highly abstract code and specialize it.

```
Macro comment: "utility start"
inl _ = utility (actions 0, actions 1)
Macro comment: "utility end"
```

The above fragment would get specialized into the following chunk of quite verbose code. These functions might seem complicated, but they are just two loops compiles as functions in tail position. It is easier to compile like this when targeting F#, but for a different language (like in the Cuda backend), Spiral would compile this as an actual loop.

```
...
/// compare
and method_6 ((var_40 : int64), (var_35 : (int64 [])), (var_34 : (int64 []))) : int64 =
    let ((var_41 : int64)) = var_34.[int32 var_40]
    let ((var_42 : int64)) = var_35.[int32 var_40]
    let ((var_43 : bool)) = var_41 > var_42
    if var_43 then
        1L
    else
        let ((var_44 : bool)) = var_41 < var_42
        if var_44 then
            -1L
        else
            0L
            
/// Array.map2 specialized to compare
and method_2 ((var_48 : (int64 [])), (var_35 : (int64 [])), (var_34 : (int64 [])), (var_36 : int64), (var_49 : int64)) : unit =
    let ((var_50 : bool)) = var_49 < var_36
    if var_50 then
        let ((var_51 : int64)) = var_49 + 1L
        let ((var_52 : int64)) = method_6 (var_49, var_35, var_34)
        let () = var_48.[int32 var_49] <- var_52
        method_2 (var_48, var_35, var_34, var_36, var_51)
    else
        ()

/// Array.sum
and method_3 ((var_48 : (int64 [])), (var_55 : int64), (var_56 : int64), (var_54 : int64)) : int64 =
    let ((var_57 : bool)) = var_56 < var_55
    if var_57 then
        let ((var_58 : int64)) = var_56 + 1L
        let ((var_59 : int64)) = var_48.[int32 var_56]
        let ((var_60 : int64)) = var_54 + var_59
        method_3 (var_48, var_55, var_58, var_60)
    else
        var_54

let () = () // utility start
let ((var_34 : (int64 []))) = var_33.[int32 0L]
let ((var_35 : (int64 []))) = var_33.[int32 1L]
let ((var_36 : int64)) = var_35.LongLength
let ((var_37 : int64)) = var_34.LongLength
let ((var_38 : bool)) = var_37 = var_36
let ((var_39 : bool)) = var_38 = false
let () =
    if var_39 then
        failwith "The two arrays must have the same length."
    else
        ()
let ((var_48 : (int64 []))) = Array.zeroCreate (System.Convert.ToInt32 var_36)
let ((var_49 : int64)) = 0L
let () = method_2 (var_48, var_35, var_34, var_36, var_49)
let ((var_54 : int64)) = 0L
let ((var_55 : int64)) = var_48.LongLength
let ((var_56 : int64)) = 0L
let ((var_63 : int64)) = method_3 (var_48, var_55, var_56, var_54)
let ((var_64 : float)) = float var_63
let () = () // utility end
```

There is a myth floating around in programming circles that types make things faster. This is true only up to a point - types only make things faster when they are primitive. Abstract types such as `a -> b` do not help the compiler that much. Minus the tail recursion, the above is similar to what one would write in C. A good compiler would transform it into an imperative loop under the hood.

# Conclussion

A reasonable guess as to why F# would be faster than Pharo then would be that even though it uses abstract types, they restrict the program and make it easier for the JIT to narrow it down further. Ultimately dynamic language JITs have to take advantage of the same kinds of optimizations as static languages to get their performance and widening the space of valid programs will introduce inefficiencies. 

A deeper analysis comparing the bytecode produced by F# and Pharo should be done to verify how correct such a guess really is.

# Spiral Version (Compiled)

Spiral is different than F# and Pharo both in that as a part of its typing it directly traces the execution through the whole program ahead of time and uses various compiler hints to ward off divergence. This allows it to do such deep specialization.

To get really good performance with modern compilers ultimately requires being able to reason about the optimizers underneath. The less opaque the language, the easier such task becomes. There is value in not having to do such reasoning like in F# and Pharo, but there is also value in doing it as well like in Spiral.

For completeness's sake, here is the output that Spiral's compiler produces as F# code. It is hard to read and verbose, so it is here just as an illustration of why the C language style is fast. Specialization could be thought as style shifting from high abstraction to low. Thanks to the magic of staging, doing it by hand is no longer needed.

The following is 350 LOC long. 

```
let rec method_0 ((var_4 : (int64 [])), (var_5 : int64)) : unit =
    let ((var_6 : bool)) = var_5 < 3L
    if var_6 then
        let ((var_7 : int64)) = var_5 + 1L
        let ((var_8 : int64)) = method_6 (var_5)
        let () = var_4.[int32 var_5] <- var_8
        method_0 (var_4, var_7)
    else
        ()
and method_1 ((var_9 : ResizeArray<(int64 [])>), (var_4 : (int64 []))) : unit =
    let ((var_10 : int64)) = 0L
    method_7 (var_9, var_4, var_10)
and method_2 ((var_37 : (float [])), (var_34 : int64), (var_38 : int64)) : unit =
    let ((var_39 : bool)) = var_38 < var_34
    if var_39 then
        let ((var_40 : int64)) = var_38 + 1L
        let ((var_41 : float)) = method_8 (var_38)
        let () = var_37.[int32 var_38] <- var_41
        method_2 (var_37, var_34, var_40)
    else
        ()
and method_3 ((var_37 : (float [])), (var_44 : (float [])), (var_33 : ((int64 []) [])), (var_1 : System.Random), (var_47 : int64)) : unit =
    let ((var_48 : bool)) = var_47 <= 10000000L
    if var_48 then
        let ((var_49 : int64)) = var_47 + 1L
        let ((var_94 : (float []))) = method_4 (var_33, var_37)
        let ((var_95 : int64)) = var_94.LongLength
        let ((var_96 : int64)) = 0L
        let () = method_9 (var_44, var_94, var_95, var_96)
        let ((var_102 : float)) = var_1.NextDouble()
        let ((var_103 : int64)) = 0L
        let ((var_104 : float)) = 0.000000
        let ((var_119 : (int64 []))) = method_10 (var_103, var_33, var_104, var_94, var_102)
        let ((var_120 : (float []))) = method_4 (var_33, var_37)
        let ((var_121 : int64)) = var_120.LongLength
        let ((var_122 : int64)) = 0L
        let () = method_9 (var_44, var_120, var_121, var_122)
        let ((var_123 : float)) = var_1.NextDouble()
        let ((var_124 : int64)) = 0L
        let ((var_125 : float)) = 0.000000
        let ((var_126 : (int64 []))) = method_10 (var_124, var_33, var_125, var_120, var_123)
        let ((var_127 : int64)) = var_126.LongLength
        let ((var_128 : int64)) = var_119.LongLength
        let ((var_129 : bool)) = var_128 = var_127
        let ((var_130 : bool)) = var_129 = false
        let () =
            if var_130 then
                failwith "The two arrays must have the same length."
            else
                ()
        let ((var_139 : (int64 []))) = Array.zeroCreate (System.Convert.ToInt32 var_127)
        let ((var_140 : int64)) = 0L
        let () = method_11 (var_139, var_126, var_119, var_127, var_140)
        let ((var_145 : int64)) = 0L
        let ((var_146 : int64)) = var_139.LongLength
        let ((var_147 : int64)) = 0L
        let ((var_154 : int64)) = method_12 (var_139, var_146, var_147, var_145)
        let ((var_155 : float)) = float var_154
        let ((var_156 : int64)) = var_33.LongLength
        let ((var_157 : int64)) = 0L
        let () = method_13 (var_126, var_155, var_37, var_33, var_156, var_157)
        let ((var_178 : bool)) = var_127 = var_128
        let ((var_179 : bool)) = var_178 = false
        let () =
            if var_179 then
                failwith "The two arrays must have the same length."
            else
                ()
        let ((var_182 : (int64 []))) = Array.zeroCreate (System.Convert.ToInt32 var_128)
        let ((var_183 : int64)) = 0L
        let () = method_11 (var_182, var_119, var_126, var_128, var_183)
        let ((var_185 : int64)) = 0L
        let ((var_186 : int64)) = var_182.LongLength
        let ((var_187 : int64)) = 0L
        let ((var_188 : int64)) = method_12 (var_182, var_186, var_187, var_185)
        let ((var_189 : float)) = float var_188
        let ((var_190 : int64)) = 0L
        let () = method_13 (var_119, var_189, var_37, var_33, var_156, var_190)
        method_3 (var_37, var_44, var_33, var_1, var_49)
    else
        ()
and method_4 ((var_33 : ((int64 []) [])), (var_37 : (float []))) : (float []) =
    let ((var_50 : float)) = 0.000000
    let ((var_51 : int64)) = var_37.LongLength
    let ((var_57 : (float []))) = Array.zeroCreate (System.Convert.ToInt32 var_51)
    let ((var_58 : int64)) = 0L
    let () = method_14 (var_57, var_37, var_50, var_51, var_58)
    let ((var_63 : float)) = 0.000000
    let ((var_64 : int64)) = var_57.LongLength
    let ((var_65 : int64)) = 0L
    let ((var_72 : float)) = method_15 (var_57, var_64, var_65, var_63)
    let ((var_73 : bool)) = var_72 > 0.000000
    if var_73 then
        let ((var_78 : (float []))) = Array.zeroCreate (System.Convert.ToInt32 var_64)
        let ((var_79 : int64)) = 0L
        let () = method_16 (var_78, var_57, var_72, var_64, var_79)
        var_78
    else
        let ((var_83 : int64)) = var_33.LongLength
        let ((var_84 : float)) = float var_83
        let ((var_85 : float)) = 1.000000 / var_84
        let ((var_88 : (float []))) = Array.zeroCreate (System.Convert.ToInt32 var_64)
        let ((var_89 : int64)) = 0L
        let () = method_17 (var_88, var_85, var_64, var_89)
        var_88
and method_5 ((var_194 : (float [])), (var_33 : ((int64 []) [])), (var_195 : int64), (var_198 : int64)) : unit =
    let ((var_199 : bool)) = var_198 < var_195
    if var_199 then
        let ((var_200 : int64)) = var_198 + 1L
        let ((var_201 : (int64 []))) = var_33.[int32 var_198]
        let ((var_202 : float)) = var_194.[int32 var_198]
        let () = System.Console.WriteLine(var_202)
        method_5 (var_194, var_33, var_195, var_200)
    else
        ()
and method_6 ((var_2 : int64)) : int64 =
    0L
and method_7 ((var_9 : ResizeArray<(int64 [])>), (var_4 : (int64 [])), (var_10 : int64)) : unit =
    let ((var_11 : bool)) = var_10 <= 5L
    if var_11 then
        let ((var_12 : int64)) = var_10 + 1L
        let () = var_4.[int32 0L] <- var_10
        let ((var_13 : int64)) = 5L - var_10
        let () = method_18 (var_9, var_4, var_13)
        method_7 (var_9, var_4, var_12)
    else
        ()
and method_8 ((var_35 : int64)) : float =
    0.000000
and method_9 ((var_44 : (float [])), (var_94 : (float [])), (var_95 : int64), (var_96 : int64)) : unit =
    let ((var_97 : bool)) = var_96 < var_95
    if var_97 then
        let ((var_98 : int64)) = var_96 + 1L
        let ((var_99 : float)) = var_94.[int32 var_96]
        let ((var_100 : float)) = var_44.[int32 var_96]
        let ((var_101 : float)) = var_100 + var_99
        let () = var_44.[int32 var_96] <- var_101
        method_9 (var_44, var_94, var_95, var_98)
    else
        ()
and method_10 ((var_103 : int64), (var_33 : ((int64 []) [])), (var_104 : float), (var_94 : (float [])), (var_102 : float)) : (int64 []) =
    let ((var_105 : int64)) = var_33.LongLength
    let ((var_106 : bool)) = var_103 < var_105
    if var_106 then
        let ((var_107 : float)) = var_94.[int32 var_103]
        let ((var_108 : float)) = var_104 + var_107
        let ((var_109 : bool)) = var_102 <= var_108
        if var_109 then
            var_33.[int32 var_103]
        else
            let ((var_111 : int64)) = var_103 + 1L
            method_10 (var_111, var_33, var_108, var_94, var_102)
    else
        failwith "impossible"
and method_11 ((var_139 : (int64 [])), (var_126 : (int64 [])), (var_119 : (int64 [])), (var_127 : int64), (var_140 : int64)) : unit =
    let ((var_141 : bool)) = var_140 < var_127
    if var_141 then
        let ((var_142 : int64)) = var_140 + 1L
        let ((var_143 : int64)) = method_19 (var_140, var_126, var_119)
        let () = var_139.[int32 var_140] <- var_143
        method_11 (var_139, var_126, var_119, var_127, var_142)
    else
        ()
and method_12 ((var_139 : (int64 [])), (var_146 : int64), (var_147 : int64), (var_145 : int64)) : int64 =
    let ((var_148 : bool)) = var_147 < var_146
    if var_148 then
        let ((var_149 : int64)) = var_147 + 1L
        let ((var_150 : int64)) = var_139.[int32 var_147]
        let ((var_151 : int64)) = var_145 + var_150
        method_12 (var_139, var_146, var_149, var_151)
    else
        var_145
and method_13 ((var_126 : (int64 [])), (var_155 : float), (var_37 : (float [])), (var_33 : ((int64 []) [])), (var_156 : int64), (var_157 : int64)) : unit =
    let ((var_158 : bool)) = var_157 < var_156
    if var_158 then
        let ((var_159 : int64)) = var_157 + 1L
        let ((var_160 : (int64 []))) = var_33.[int32 var_157]
        let ((var_161 : int64)) = var_126.LongLength
        let ((var_162 : int64)) = var_160.LongLength
        let ((var_163 : bool)) = var_162 = var_161
        let ((var_164 : bool)) = var_163 = false
        let () =
            if var_164 then
                failwith "The two arrays must have the same length."
            else
                ()
        let ((var_167 : (int64 []))) = Array.zeroCreate (System.Convert.ToInt32 var_161)
        let ((var_168 : int64)) = 0L
        let () = method_11 (var_167, var_126, var_160, var_161, var_168)
        let ((var_170 : int64)) = 0L
        let ((var_171 : int64)) = var_167.LongLength
        let ((var_172 : int64)) = 0L
        let ((var_173 : int64)) = method_12 (var_167, var_171, var_172, var_170)
        let ((var_174 : float)) = float var_173
        let ((var_175 : float)) = var_174 - var_155
        let ((var_176 : float)) = var_37.[int32 var_157]
        let ((var_177 : float)) = var_176 + var_175
        let () = var_37.[int32 var_157] <- var_177
        method_13 (var_126, var_155, var_37, var_33, var_156, var_159)
    else
        ()
and method_14 ((var_57 : (float [])), (var_37 : (float [])), (var_50 : float), (var_51 : int64), (var_58 : int64)) : unit =
    let ((var_59 : bool)) = var_58 < var_51
    if var_59 then
        let ((var_60 : int64)) = var_58 + 1L
        let ((var_61 : float)) = method_20 (var_58, var_37, var_50)
        let () = var_57.[int32 var_58] <- var_61
        method_14 (var_57, var_37, var_50, var_51, var_60)
    else
        ()
and method_15 ((var_57 : (float [])), (var_64 : int64), (var_65 : int64), (var_63 : float)) : float =
    let ((var_66 : bool)) = var_65 < var_64
    if var_66 then
        let ((var_67 : int64)) = var_65 + 1L
        let ((var_68 : float)) = var_57.[int32 var_65]
        let ((var_69 : float)) = var_63 + var_68
        method_15 (var_57, var_64, var_67, var_69)
    else
        var_63
and method_16 ((var_78 : (float [])), (var_57 : (float [])), (var_72 : float), (var_64 : int64), (var_79 : int64)) : unit =
    let ((var_80 : bool)) = var_79 < var_64
    if var_80 then
        let ((var_81 : int64)) = var_79 + 1L
        let ((var_82 : float)) = method_21 (var_79, var_57, var_72)
        let () = var_78.[int32 var_79] <- var_82
        method_16 (var_78, var_57, var_72, var_64, var_81)
    else
        ()
and method_17 ((var_88 : (float [])), (var_85 : float), (var_64 : int64), (var_89 : int64)) : unit =
    let ((var_90 : bool)) = var_89 < var_64
    if var_90 then
        let ((var_91 : int64)) = var_89 + 1L
        let ((var_92 : float)) = method_22 (var_89, var_85)
        let () = var_88.[int32 var_89] <- var_92
        method_17 (var_88, var_85, var_64, var_91)
    else
        ()
and method_18 ((var_9 : ResizeArray<(int64 [])>), (var_4 : (int64 [])), (var_13 : int64)) : unit =
    let ((var_14 : int64)) = 0L
    method_23 (var_9, var_4, var_13, var_14)
and method_19 ((var_131 : int64), (var_126 : (int64 [])), (var_119 : (int64 []))) : int64 =
    let ((var_132 : int64)) = var_119.[int32 var_131]
    let ((var_133 : int64)) = var_126.[int32 var_131]
    let ((var_134 : bool)) = var_132 > var_133
    if var_134 then
        1L
    else
        let ((var_135 : bool)) = var_132 < var_133
        if var_135 then
            -1L
        else
            0L
and method_20 ((var_52 : int64), (var_37 : (float [])), (var_50 : float)) : float =
    let ((var_53 : float)) = var_37.[int32 var_52]
    let ((var_54 : bool)) = var_50 > var_53
    if var_54 then
        var_50
    else
        var_53
and method_21 ((var_74 : int64), (var_57 : (float [])), (var_72 : float)) : float =
    let ((var_75 : float)) = var_57.[int32 var_74]
    var_75 / var_72
and method_22 ((var_86 : int64), (var_85 : float)) : float =
    var_85
and method_23 ((var_9 : ResizeArray<(int64 [])>), (var_4 : (int64 [])), (var_13 : int64), (var_14 : int64)) : unit =
    let ((var_15 : bool)) = var_14 <= var_13
    if var_15 then
        let ((var_16 : int64)) = var_14 + 1L
        let () = var_4.[int32 1L] <- var_14
        let ((var_17 : int64)) = var_13 - var_14
        let () = method_24 (var_9, var_4, var_17)
        method_23 (var_9, var_4, var_13, var_16)
    else
        ()
and method_24 ((var_9 : ResizeArray<(int64 [])>), (var_4 : (int64 [])), (var_17 : int64)) : unit =
    let ((var_18 : int64)) = 0L
    method_25 (var_9, var_4, var_17, var_18)
and method_25 ((var_9 : ResizeArray<(int64 [])>), (var_4 : (int64 [])), (var_17 : int64), (var_18 : int64)) : unit =
    let ((var_19 : bool)) = var_18 <= var_17
    if var_19 then
        let ((var_20 : int64)) = var_18 + 1L
        let () = var_4.[int32 2L] <- var_18
        let ((var_21 : int64)) = var_17 - var_18
        let () = method_26 (var_9, var_4, var_21)
        method_25 (var_9, var_4, var_17, var_20)
    else
        ()
and method_26 ((var_9 : ResizeArray<(int64 [])>), (var_4 : (int64 [])), (var_21 : int64)) : unit =
    let ((var_22 : bool)) = var_21 = 0L
    if var_22 then
        let ((var_23 : int64)) = var_4.LongLength
        let ((var_27 : (int64 []))) = Array.zeroCreate (System.Convert.ToInt32 var_23)
        let ((var_28 : int64)) = 0L
        let () = method_27 (var_27, var_4, var_23, var_28)
        var_9.Add(var_27)
    else
        ()
and method_27 ((var_27 : (int64 [])), (var_4 : (int64 [])), (var_23 : int64), (var_28 : int64)) : unit =
    let ((var_29 : bool)) = var_28 < var_23
    if var_29 then
        let ((var_30 : int64)) = var_28 + 1L
        let ((var_31 : int64)) = method_28 (var_28, var_4)
        let () = var_27.[int32 var_28] <- var_31
        method_27 (var_27, var_4, var_23, var_30)
    else
        ()
and method_28 ((var_24 : int64), (var_4 : (int64 []))) : int64 =
    var_4.[int32 var_24]
let ((var_1 : System.Random)) = System.Random()
let ((var_4 : (int64 []))) = Array.zeroCreate (System.Convert.ToInt32 3L)
let ((var_5 : int64)) = 0L
let () = method_0 (var_4, var_5)
let () = () // unit stack layout type
let ((var_9 : ResizeArray<(int64 [])>)) = ResizeArray<(int64 [])>()
let () = method_1 (var_9, var_4)
let ((var_33 : ((int64 []) []))) = var_9.ToArray()
let ((var_34 : int64)) = var_33.LongLength
let ((var_37 : (float []))) = Array.zeroCreate (System.Convert.ToInt32 var_34)
let ((var_38 : int64)) = 0L
let () = method_2 (var_37, var_34, var_38)
let ((var_44 : (float []))) = Array.zeroCreate (System.Convert.ToInt32 var_34)
let ((var_45 : int64)) = 0L
let () = method_2 (var_44, var_34, var_45)
let () = System.Console.WriteLine("Starting timing for: loop")
let ((var_46 : System.Diagnostics.Stopwatch)) = System.Diagnostics.Stopwatch()
let () = var_46.Start()
let ((var_47 : int64)) = 1L
let () = method_3 (var_37, var_44, var_33, var_1, var_47)
let () = var_46.Stop()
let ((var_192 : System.TimeSpan)) = var_46.get_Elapsed()
let ((var_193 : string)) = System.String.Format("The time was {0} for: {1}",var_192,"loop")
let () = System.Console.WriteLine(var_193)
let ((var_194 : (float []))) = method_4 (var_33, var_44)
let ((var_195 : int64)) = var_194.LongLength
let ((var_196 : bool)) = var_34 = var_195
let ((var_197 : bool)) = var_196 = false
let () =
    if var_197 then
        failwith "The two arrays must have the same length."
    else
        ()
let ((var_198 : int64)) = 0L
let () = method_5 (var_194, var_33, var_195, var_198)
let () = System.Console.WriteLine("---")
```