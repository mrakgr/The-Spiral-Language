let rec method4 (v0 : int32, v1 : float, v2 : float32, v3 : float) : struct (int32 * int32 * float * float32 * float) =
    struct (1, v0, v1, v2, v3)
and closure2 (v0 : int32, v1 : float, v2 : float32, v3 : float) (v4 : string) : struct (int32 * int32 * float * float32 * float) =
    method4(v0, v1, v2, v3)
and method3 (v0 : int32, v1 : float, v2 : float32, v3 : float) : (string -> struct (int32 * int32 * float * float32 * float)) =
    closure2(v0, v1, v2, v3)
and closure1 (v0 : int32) struct (v1 : float, v2 : float32, v3 : float) : (string -> struct (int32 * int32 * float * float32 * float)) =
    method3(v0, v1, v2, v3)
and method2 (v0 : int32) : (struct (float * float32 * float) -> (string -> struct (int32 * int32 * float * float32 * float))) =
    closure1(v0)
and closure0 () (v0 : int32) : (struct (float * float32 * float) -> (string -> struct (int32 * int32 * float * float32 * float))) =
    method2(v0)
and method1 () : (int32 -> (struct (float * float32 * float) -> (string -> struct (int32 * int32 * float * float32 * float)))) =
    closure0()
and method0 () : (string -> struct (int32 * int32 * float * float32 * float)) =
    let v0 : (int32 -> (struct (float * float32 * float) -> (string -> struct (int32 * int32 * float * float32 * float)))) = method1()
    let v1 : (struct (float * float32 * float) -> (string -> struct (int32 * int32 * float * float32 * float))) = v0 2
    v1 struct (2.2, 3f, 4.5)
let v0 : (string -> struct (int32 * int32 * float * float32 * float)) = method0()
v0 "qwe"
