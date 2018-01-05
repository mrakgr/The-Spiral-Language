Error trace on line: 612, column: 17 in file "Learning".
            inb b,b_bck = b a
                ^
Error trace on line: 613, column: 13 in file "Learning".
            ret (b, inl _ -> b_bck(); a_bck())
            ^
Error trace on line: 701, column: 21 in file "Learning".
                inb {primal adjoint}, bck = apply (view input, view label)
                    ^
Error trace on line: 702, column: 21 in file "Learning".
                inl primal = primal.value
                    ^
Error trace on line: 703, column: 17 in file "Learning".
                string_format "On minibatch {0}. Error = {1}" (show span, primal) |> writeline
                ^
Error trace on line: 126, column: 7 in file "HostTensor".
    | .range (!map_dims dim) tns ->
      ^
Error trace on line: 137, column: 7 in file "HostTensor".
    | .all tns ->
      ^
Error trace on line: 163, column: 7 in file "HostTensor".
    | tns -> show.all tns // TODO: Put in a cutoff here later.
      ^
Error trace on line: 137, column: 12 in file "HostTensor".
    | .all tns ->
           ^
Error trace on line: 139, column: 13 in file "HostTensor".
        inl strb_type = fs [text: "System.Text.StringBuilder"]
            ^
Error trace on line: 140, column: 13 in file "HostTensor".
        inl s = FS.Constructor strb_type ()
            ^
Error trace on line: 144, column: 13 in file "HostTensor".
        inl blank = dyn ""
            ^
Error trace on line: 161, column: 9 in file "HostTensor".
        loop {tns; ind=0; prefix=blank} |> ignore
        ^
Error trace on line: 145, column: 22 in file "HostTensor".
        inl rec loop {tns ind} = 
                     ^
Error trace on line: 146, column: 13 in file "HostTensor".
            match tns.dim with
            ^
Error trace on line: 191, column: 68 in file "Learning".
        inl create_like tns = create {elem_type=tns.elem_type; dim=tns.dim}
                                                                   ^
Cannot find a member named dim inside the module.
