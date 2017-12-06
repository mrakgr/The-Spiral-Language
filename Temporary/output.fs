Error trace on line: 6, column: 5 in file "Cuda".
inl cuda_kernels = FS.Constant.cuda_kernels string
    ^
Error trace on line: 26, column: 5 in file "Cuda".
inl cuda_toolkit_path = @PathCuda
    ^
Error trace on line: 27, column: 5 in file "Cuda".
inl visual_studio_path = @PathVS2017
    ^
Error trace on line: 28, column: 5 in file "Cuda".
inl cub_path = @PathCub
    ^
Error trace on line: 30, column: 5 in file "Cuda".
inl env_type = fs [text: "System.Environment"]
    ^
Error trace on line: 31, column: 5 in file "Cuda".
inl context_type = fs [text: "ManagedCuda.CudaContext"]
    ^
Error trace on line: 32, column: 5 in file "Cuda".
inl context = FS.Constructor context_type false
    ^
Error trace on line: 118, column: 5 in file "Cuda".
inl current_directory = FS.StaticMethod env_type .get_CurrentDirectory() string
    ^
Error trace on line: 119, column: 15 in file "Cuda".
inl modules = compile_kernel_using_nvcc_bat_router current_directory
              ^
Error trace on line: 35, column: 42 in file "Cuda".
inl compile_kernel_using_nvcc_bat_router (kernels_dir: string) =
                                         ^
Error trace on line: 36, column: 9 in file "Cuda".
    inl path_type = fs [text: "System.IO.Path"]
        ^
Error trace on line: 39, column: 9 in file "Cuda".
    inl file_type = fs [text: "System.IO.File"]
        ^
Error trace on line: 40, column: 9 in file "Cuda".
    inl stream_type = fs [text: "System.IO.Stream"]
        ^
Error trace on line: 41, column: 9 in file "Cuda".
    inl streamwriter_type = fs [text: "System.IO.StreamWriter"]
        ^
Error trace on line: 42, column: 9 in file "Cuda".
    inl process_start_info_type = fs [text: "System.Diagnostics.ProcessStartInfo"]
        ^
Error trace on line: 44, column: 9 in file "Cuda".
    inl nvcc_router_path = combine (kernels_dir,"nvcc_router.bat")
        ^
Error trace on line: 45, column: 9 in file "Cuda".
    inl procStartInfo = FS.Constructor process_start_info_type ()
        ^
Error trace on line: 51, column: 9 in file "Cuda".
    inl process_type = fs [text: "System.Diagnostics.Process"]
        ^
Error trace on line: 56, column: 13 in file "Extern".
inl (use) a b =
            ^
Error trace on line: 57, column: 13 in file "Extern".
    inl r = b a
            ^
Error trace on line: 52, column: 9 in file "Cuda".
    use process = FS.Constructor process_type ()
        ^
Error trace on line: 54, column: 9 in file "Cuda".
    inl print_to_standard_output = 
        ^
Error trace on line: 61, column: 9 in file "Cuda".
    inl concat = string_concat ""
        ^
Error trace on line: 67, column: 9 in file "Cuda".
    inl quoted_vs_path_to_vcvars = combine(visual_studio_path, @"VC\Auxiliary\Build\vcvarsx86_amd64.bat") |> quote
        ^
Error trace on line: 68, column: 9 in file "Cuda".
    inl quoted_vs_path_to_cl = combine(visual_studio_path, @"VC\Tools\MSVC\14.11.25503\bin\Hostx64\x64") |> quote
        ^
Error trace on line: 69, column: 9 in file "Cuda".
    inl quoted_cuda_toolkit_path_to_include = combine(cuda_toolkit_path,"include") |> quote
        ^
Error trace on line: 70, column: 9 in file "Cuda".
    inl quoted_vc_path_to_include = combine(visual_studio_path, @"VC\Tools\MSVC\14.11.25503\include") |> quote
        ^
Error trace on line: 71, column: 9 in file "Cuda".
    inl quoted_nvcc_path = combine(cuda_toolkit_path,@"bin\nvcc.exe") |> quote
        ^
Error trace on line: 72, column: 9 in file "Cuda".
    inl quoted_cub_path_to_include = cub_path |> quote
        ^
Error trace on line: 73, column: 9 in file "Cuda".
    inl quoted_kernels_dir = kernels_dir |> quote
        ^
Error trace on line: 74, column: 9 in file "Cuda".
    inl target_path = combine(kernels_dir,"cuda_kernels.ptx")
        ^
Error trace on line: 75, column: 9 in file "Cuda".
    inl quoted_target_path = target_path |> quote
        ^
Error trace on line: 76, column: 9 in file "Cuda".
    inl input_path = combine(kernels_dir,"cuda_kernels.cu")
        ^
Error trace on line: 77, column: 9 in file "Cuda".
    inl quoted_input_path = input_path |> quote
        ^
Error trace on line: 84, column: 13 in file "Cuda".
        inl filestream_type = fs [text: "System.IO.FileStream"]
            ^
Error trace on line: 56, column: 13 in file "Extern".
inl (use) a b =
            ^
Error trace on line: 57, column: 13 in file "Extern".
    inl r = b a
            ^
Error trace on line: 86, column: 13 in file "Cuda".
        use nvcc_router_file = FS.StaticMethod file_type .OpenWrite(nvcc_router_path) filestream_type
            ^
Error trace on line: 56, column: 13 in file "Extern".
inl (use) a b =
            ^
Error trace on line: 57, column: 13 in file "Extern".
    inl r = b a
            ^
Error trace on line: 87, column: 13 in file "Cuda".
        use nvcc_router_stream = FS.Constructor streamwriter_type nvcc_router_file
            ^
Error trace on line: 89, column: 13 in file "Cuda".
        inl write_to_batch = concat >> inl x -> FS.Method nvcc_router_stream.WriteLine x unit
            ^
Error trace on line: 92, column: 9 in file "Cuda".
        call quoted_vs_path_to_vcvars |> write_to_batch
        ^
Error trace on line: 57, column: 12 in file "Core".
inl (|>) a b = b a
           ^
Error trace on line: 59, column: 14 in file "Core".
inl (>>) a b x = b (a x)
             ^
Error trace on line: 63, column: 7 in file "Extern".
    | _ :: _ as l ->
      ^
Error trace on line: 64, column: 9 in file "Extern".
        Tuple.foldr (inl x {state with dyn stc} ->
        ^
Error trace on line: 73, column: 9 in file "Extern".
        |> inl {dyn stc} -> 
        ^
Error trace on line: 57, column: 12 in file "Core".
inl (|>) a b = b a
           ^
Error trace on line: 73, column: 16 in file "Extern".
        |> inl {dyn stc} -> 
               ^
Error trace on line: 74, column: 13 in file "Extern".
            Tuple.append stc dyn 
            ^
Error trace on line: 76, column: 13 in file "Extern".
            |> string_concat sep
            ^
Error trace on line: 57, column: 12 in file "Core".
inl (|>) a b = b a
           ^
Error trace on line: 87, column: 21 in file "Core".
inl string_concat a b = !StringConcat(a,b)
                    ^
One of the arguments to string concat is not a string.
Got: [lit ", var (string), lit "]
