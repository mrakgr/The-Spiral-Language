type RandVar = unit // placeholder
type Trace =
    | Var of RandVar
    | If of tr: Traces * fl: Traces
and Traces = Trace ResizeArray