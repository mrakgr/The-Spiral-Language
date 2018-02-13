module Learning.Modules

open Spiral.Types
open Spiral.Lib

let resize_array =
    (
    "ResizeArray",[extern_],"The resizable array module.",
    """
open Extern
inl create {d with elem_type} = 
    inl ty = fs [text: "ResizeArray"; types: elem_type]
    inl x = 
        match d with 
        | {size} -> FS.Constructor ty (to int32 size)
        | _ -> FS.Constructor ty ()

    inl filter f = FS.Method x ."RemoveAll <| System.Predicate" (closure_of f (elem_type => bool)) int32 |> ignore
    inl sort f =
        inl comparison_type = fs [text: "System.Comparison"; types: elem_type]
        inl f = closure_of f (elem_type => elem_type => int32)
        inl c = FS.Constructor comparison_type f
        FS.Method x .Sort c ()

    inl index i = macro.fs elem_type [arg: x; text: ".["; arg: to int32 i; text: "]"]
    inl set i v = macro.fs () [arg: x; text: ".["; arg: to int32 i; text: "] <- "; arg: v]
    inl clear () = FS.Method x .Clear() ()
    inl count () = FS.Method x .get_Count() int32
    inl add y = FS.Method x .Add y ()

    inl iter f = FS.Method x ."ForEach <| System.Action<_>" (closure_of f (elem_type => ())) ()

    function
    | .sort -> sort 
    | .filter -> filter 
    | .set -> set
    | .clear -> clear ()
    | .count -> count ()
    | .add -> add
    | .iter -> iter
    | .elem_type -> elem_type
    | i -> index i
{ 
create
} |> stack
    """
    ) |> module_

let allocator = 
    (
    "Allocator",[resize_array;loops;option;extern_;console],"The section based GPU memory allocator module.",
    """
inl {Cuda} ->
    open Cuda
    open Extern
    inl smartptr_create (ptr: uint64) =
        inl cell = ref ptr
        function
        | .Dispose -> cell := 0u64
        | .Try -> cell()
        | () -> join 
            inl x = cell ()
            assert (x <> 0u64) "A Cuda memory cell that has been disposed has been tried to be accessed."
            x
        |> stack

    inl mult = 256u64
    inl round_up_to_multiple size = size - size % mult + mult

    inl allocate_global =
        to uint64 >> round_up_to_multiple >> dyn
        >> inl size -> { size ptr = FS.Method context .AllocateMemory (SizeT size) CUdeviceptr_type |> to_uint |> smartptr_create }

    inl compare a b = if a < b then -1i32 elif a = b then 0i32 else 1i32
    inl sort_ptrs x = x.sort (inl {ptr=a} {ptr=b} -> compare (a()) (b()))

    met free_cells_refresh {section with pool free_cells used_cells} = 
        used_cells.filter (inl {ptr} -> ptr.Try = 0u64)
        sort_ptrs used_cells
        free_cells.clear
        inl near_to = used_cells.count
        inl add {ptr size} = free_cells.add {ptr = smartptr_create (ptr()); size}

        inl distance state state' = 
            inl p1 = state.ptr() + state.size
            inl p2 = state.ptr()
            p2 - p1
            
        Loops.for {from=0i32; near_to by=1i32; state={pool with size = 0u64}; body=inl {{state with ptr} i} ->
            inl state' = free_cells i
            inl size = distance state state'
            if size > 0u64 then add { ptr size }
            state'
            }
        |> inl state -> // This is for the final free cell at the end.
            inl size = distance pool state
            add {state with size}

    met allocate {section with free_cells} (!(to uint64 >> dyn) size') =
        inl loop next =
            inl {ptr size} = free_cells 0i32
            if size' <= size then
                free_cells.set 0i32 {ptr=smartptr_create (ptr.Try+size'); size=size-size'}
                {ptr size=size'}
            else next()

        inl {ptr} =
            loop <| inl _ ->
                sort_ptrs free_cells
                loop <| inl _ -> 
                    free_cells_refresh section
                    sort_ptrs free_cells
                    loop <| inl _ ->
                        failwith free_cells.elem_type "Out of memory in the designated section."
        ptr

    inl size ret ->
        inl pool = allocate_global size
        inl elem_type = type pool
        inl free_cells, used_cells = ResizeArray.create {elem_type}, ResizeArray.create {elem_type}
        inl section = {pool free_cells used_cells}
        free_cells_refresh section
        inl r = ret function
            | .elem_type -> type elem_type.ptr
            | .refresh -> free_cells_refresh section
            | x -> allocate section x

        inl ptr = pool.ptr
        FS.Method context .FreeMemory (ptr() |> CUdeviceptr) unit
        ptr.Dispose
        r
    """) |> module_

let region =
    (
    "Region",[resize_array],"The region based resource tracker.",
    """

inl create' create =
    inl counter_ref_create ptr =
        inl count = ref 0
        function
        | .inc -> count := count() + 1
        | .dec -> 
            count := count() - 1
            if count() = 0 then ptr.Dispose
        | x -> ptr x
        |> stack

    inl elem_type = type counter_ref_create (var create.elem_type)
    macro.fs () [text: "// is region"]
    inl region = ResizeArray.create {elem_type}

    met assign (r: elem_type) = r.inc; region.add r
    met allocate (!(to uint64 >> dyn) x) = 
        inl r = create x |> counter_ref_create
        assign r
        r
        
    met clear _ =
        region.iter (inl r -> r.dec)
        region.clear

    function
    | .assign -> assign
    | .elem_type -> elem_type
    | .clear -> clear()
    | i -> allocate i

inl create x ret = 
    inl region = create' x
    inl r = ret region
    region.clear
    r

{create create'}
    """) |> module_