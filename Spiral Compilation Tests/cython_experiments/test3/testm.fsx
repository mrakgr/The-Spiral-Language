let decref s : () = failwith "decrements the reference count"
let incref s : () = failwith "increments the reference count"
let cntref s : int64 = failwith "get the reference count"
let assert_reference_count obj (count : int64) : () = failwith "asserts the reference count"

let rec loop_tail s (i : int64) (nearTo : int64) =
    if i < nearTo then
        let n = s + 0
        assert_reference_count n 1
        decref(s)
        loop_tail n (i+1) nearTo
    else
        s

let test_loop_tail_false () =
    // Unlike in Python, because they are immutable the bindings do not affect the reference count.
    let s : int = 0 // Pretend int is an object here. 
    assert_reference_count s 1

    incref s
    let a = loop_tail s 0 0 // Returns s
    assert_reference_count s 2
    assert_reference_count a 2

    incref s
    let b = loop_tail s 0 0 // Returns s
    assert_reference_count s 3
    assert_reference_count a 3
    assert_reference_count b 3

    incref s
    let c = loop_tail s 0 0 // Returns s. Since all of these are the same object, their reference counts are the same.
    assert_reference_count s 4
    assert_reference_count a 4
    assert_reference_count b 4
    assert_reference_count c 4

    // Exits the function. Decrefs s,a,b,c.
    decref s
    assert_reference_count s 3
    assert_reference_count a 3
    assert_reference_count b 3
    assert_reference_count c 3

    decref a
    assert_reference_count s 2
    assert_reference_count a 2
    assert_reference_count b 2
    assert_reference_count c 2

    decref b
    assert_reference_count s 1
    assert_reference_count a 1
    assert_reference_count b 1
    assert_reference_count c 1

    decref c
    assert_reference_count s 0
    assert_reference_count a 0
    assert_reference_count b 0
    assert_reference_count c 0

let test_loop_tail_true () =
    // Unlike in Python, because they are immutable the bindings do not affect the reference count.
    let s : int = 0 // Pretend int is an object here.
    assert_reference_count s 1

    incref s
    let a = loop_tail s 0 1 // Visits the true branch once. Decrefs s and return the new object.
    assert_reference_count s 1
    assert_reference_count a 1

    incref s
    let b = loop_tail s 0 1 // Visits the true branch once. Decrefs s and return the new object.
    assert_reference_count s 1
    assert_reference_count a 1
    assert_reference_count b 1

    incref s
    let c = loop_tail s 0 1 // Visits the true branch once. Decrefs s and return the new object.
    assert_reference_count s 1
    assert_reference_count a 1
    assert_reference_count b 1
    assert_reference_count c 1

    // Exits the function. Decrefs s,a,b,c.
    decref s
    assert_reference_count s 0
    assert_reference_count a 1
    assert_reference_count b 1
    assert_reference_count c 1

    decref a
    assert_reference_count s 0
    assert_reference_count a 0
    assert_reference_count b 1
    assert_reference_count c 1

    decref b
    assert_reference_count s 0
    assert_reference_count a 0
    assert_reference_count b 0
    assert_reference_count c 1

    decref c
    assert_reference_count s 0
    assert_reference_count a 0
    assert_reference_count b 0
    assert_reference_count c 0
