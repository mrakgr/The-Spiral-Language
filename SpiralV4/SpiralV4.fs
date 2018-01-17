/// The old library brought here for debuging purposes. At the time of writting, a lot of the Cuda stuff in the new library is dodgy
/// and I can't get it to converge on Mnist so 

[<AutoOpen>]
module SpiralV4.Main

// Open up the namespaces.
open ManagedCuda
open ManagedCuda.BasicTypes
open ManagedCuda.VectorTypes
open ManagedCuda.CudaBlas
open ManagedCuda.CudaRand
open ManagedCuda.NVRTC
open ManagedCuda.CudaDNN

open System
open System.Diagnostics
open System.IO
open System.Collections.Generic
open System.Runtime.InteropServices

// Initialize the context. Analogous to a CPU process. Cuda tries to offload as much as possible during context creation so there aren't
// any unexpected delays later.
let cuda_context = new CudaContext(false)
let numSm = cuda_context.GetDeviceInfo().MultiProcessorCount // The number of streaming multiprocessors on the device.

// Set the Cuda libraries handles to the above stream.
let cublas = CudaBlas(PointerMode.Host,AtomicsMode.Allowed) // Better performance for some solver functions with atomics allowed. The Spiral library does not use them though.
let cudnn = new CudaDNNContext()
let cudaRandom = new CudaRand.CudaRandDevice(GeneratorType.PseudoDefault)

type unit_to_unit_delegate = delegate of unit -> unit
let add_callback_to_stream (str : CudaStream) (callback : unit -> unit) =
    let callb (str : CUstream) (res : CUResult) (p : nativeint) =
        let t : unit_to_unit_delegate = Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer(p)
        t.Invoke()

    let aux = new unit_to_unit_delegate (callback)
    let ptr_to_aux = Marshal.GetFunctionPointerForDelegate aux

    let cuda_callback = CUstreamCallback(callb)
    str.AddCallback(cuda_callback,ptr_to_aux,CUStreamAddCallbackFlags.None)

//     Some formal rules for memory allocation
//    - On first allocation the memory is initialized to zero
//    - On the forward pass the primals of the objects in the ObjectPool are set to zero inside the functions during usage
//    - On the forward pass the adjoints of the objects in the ObjectPool are set to zero inside the ObjectPool
//    - During the optimization phase, the optimizers are responsible for setting the adjoints of the weight nodes to zero.

// Helper functions
let inline dispose (v: #IDisposable) = v.Dispose()

/// Copies a host array to device.
let inline to_dev (host_ar: 't []) =
    let d_a = new CudaDeviceVariable<'t>(SizeT host_ar.Length)
    d_a.CopyToDevice(host_ar)
    d_a

/// Copies a device array to host.
let inline to_host (dev_ar: CudaDeviceVariable<'t>) =
    let h_a = Array.zeroCreate<'t> (int dev_ar.Size)
    dev_ar.CopyToHost(h_a)
    cuda_context.Synchronize()
    h_a

/// Copies the device array to host. Extends the CudaDeviceVariable class.
type CudaDeviceVariable<'t when 't: struct and 't: (new: unit -> 't) and 't:> System.ValueType> with
    member inline this.Gather() =
        to_host this

/// The float scalar type
type Df = 
    {
    P : Lazy<float32> ref // primal
    A : float32 ref // adjoint
    }

    /// Shorthand for t.P.Value.Value
    member t.PrimalValue = t.P.Value.Value

    static member inline create P =
        {P=ref (lazy P);A=ref 0.0f}

type DeadFlagType =
| Undefined
| Dead
| Alive

type AutoDiffType =
    | PrimalOnly of CudaDeviceVariable<float32> // Does no AD
    | PrimalAndAdjoint of CudaDeviceVariable<float32> * CudaDeviceVariable<float32> // Does first order AD

    static member CreatePrimalOnly(size: int) =
        new CudaDeviceVariable<float32>(SizeT size)
        |> fun x -> x.Memset(0u); x // Zeroes the variable (saves me from having to zero out the adjoint on the first run)
        |> PrimalOnly

    static member CreatePA(size: int) =
        // Zeroes the variables (saves me from having to zero out the adjoint on the first run)
        let a = new CudaDeviceVariable<float32>(SizeT size) |> fun x -> x.Memset(0u); x
        let b = new CudaDeviceVariable<float32>(SizeT size) |> fun x -> x.Memset(0u); x
        PrimalAndAdjoint(a,b)

    static member private resize (size: int) (v: CudaDeviceVariable<float32>) = 
        if size <= int v.Size then v
        else
            v.Dispose()
            new CudaDeviceVariable<float32>(SizeT size)

    member t.ResizePrimalOnly(size: int) =
        match t with
        | PrimalOnly v -> PrimalOnly(AutoDiffType.resize size v)
        | PrimalAndAdjoint(a,b) -> PrimalAndAdjoint(AutoDiffType.resize size a, AutoDiffType.resize size b) // Does not resize downwards.

    member t.ResizePrimalAndAdjoint(size: int) =
        match t with
        | PrimalOnly v -> PrimalAndAdjoint(AutoDiffType.resize size v, new CudaDeviceVariable<float32>(SizeT size))
        | PrimalAndAdjoint(a,b) -> PrimalAndAdjoint(AutoDiffType.resize size a, AutoDiffType.resize size b)

    member t.Resize(size: int) =
        match t with
        | PrimalOnly v -> PrimalOnly(AutoDiffType.resize size v)
        | PrimalAndAdjoint(a,b) -> PrimalAndAdjoint(AutoDiffType.resize size a, AutoDiffType.resize size b)
        
    member t.P =
        match t with
        | PrimalOnly v -> v
        | PrimalAndAdjoint(a,b) -> a

    member t.A =
        match t with
        | PrimalOnly v -> failwith "No adjoint!"
        | PrimalAndAdjoint(a,b) -> b

    member t.PA = t.P, t.A

    member t.CopyToPrimal(host_ar: float32[]) =
        let x = t.P
        if int x.Size <> host_ar.Length then failwithf "int x.Size(%i) <> host_ar.Length(%i)" (int x.Size) (host_ar.Length)
        x.CopyToDevice(host_ar)

    member t.HasAdjoint =
        match t with
        | PrimalOnly v -> false
        | _ -> true

    interface IDisposable with
        member t.Dispose() =
            match t with
            | PrimalOnly v -> v.Dispose()
            | PrimalAndAdjoint(a,b) -> a.Dispose(); b.Dispose()

let defaultLayout = cudnnTensorFormat.NCHW
let defaultType = cudnnDataType.Float
let defaultMaxPoolingNanOption = cudnnNanPropagation.PropagateNan
let defaultReluNanOption = cudnnNanPropagation.PropagateNan

type TensorDescriptor with
    /// Extended method that works according to the bound defaultLayout and defaultType variables.
    member inline t.SetTensor4dDescriptor(n,c,h,w) = t.SetTensor4dDescriptor(defaultLayout,defaultType,n,c,h,w)

type FilterDescriptor with
    /// Extended method that works according to the bound defaultType variable.
    member inline t.SetFilter4dDescriptor(n,c,h,w) = t.SetFilter4dDescriptor(defaultType,defaultLayout,n,c,h,w)

type ConvolutionParameters = {
    pad_h : int
    pad_w : int
    stride_h : int
    stride_w : int
    upscale_h : int
    upscale_w : int
    mode : cudnnConvolutionMode
    }

type PoolingParameters =
    {
    mode : cudnnPoolingMode
    windowHeight : int
    windowWidth : int
    verticalPadding : int
    horizontalPadding : int
    verticalStride : int
    horizontalStride : int
    }

type PoolingDescriptor with
    member inline t.SetPooling2dDescriptor (p : PoolingParameters) =
        t.SetPooling2dDescriptor(p.mode,defaultMaxPoolingNanOption,p.windowHeight,p.windowWidth,p.verticalPadding,p.horizontalPadding,p.verticalStride,p.horizontalStride)

    member inline t.GetPooling2dForwardOutputDim s =
        let mutable n,c,h,w = 0,0,0,0
        t.GetPooling2dForwardOutputDim(s,&n,&c,&h,&w)
        n,c,h,w

let defaultConvPar = 
    {
    pad_h = 0
    pad_w = 0
    stride_h = 1
    stride_w = 1
    upscale_h = 1
    upscale_w = 1
    mode = cudnnConvolutionMode.Convolution
    }

type ConvolutionDescriptor with
    member inline t.SetConvolution2dDescriptor (p : ConvolutionParameters) =
        t.SetConvolution2dDescriptor(p.pad_h,p.pad_w,p.stride_h,p.stride_w,p.upscale_h,p.upscale_w,p.mode, defaultType)
    member inline t.GetConvolution2dForwardOutputDim (s,f) =
        let mutable n,c,h,w = 0,0,0,0
        t.GetConvolution2dForwardOutputDim(s,f,&n,&c,&h,&w)
        n,c,h,w

type Workspace() = 
    let mutable workspace: CudaDeviceVariable<byte> = CudaDeviceVariable.Null

    /// Resizes the workspace if it is less than size and returns it. The size is in 'a.
    member t.ResizeIf<'a when 'a: (new: unit -> 'a) and 'a: struct and 'a :> ValueType>(size: int) =
        let toGeneric(workspace: CudaDeviceVariable<byte>) = new CudaDeviceVariable<'a>(workspace.DevicePointer,false,SizeT (size * sizeof<'a>))
        if size <= int workspace.Size then toGeneric workspace
        else
            workspace.Dispose()
            workspace <- new CudaDeviceVariable<byte>(SizeT (size * sizeof<'a>))
            toGeneric workspace

    /// Resizes the workspace if it is less than size and returns it as a d2M.
    member t.ResizeIfd2M((r,c as rc): int*int) =
        let x = t.ResizeIf(r*c)
        {
        rc = rc
        diff = PrimalOnly x
        is_dead = Undefined
        }

    interface IDisposable with
        member t.Dispose() = workspace.Dispose()

/// The wrapper type for the d2M and d4M. It is really unbelievable how much it simplified the code for the combinators.
/// Discriminated unions are bad for storing data, but they are excellent for making code generic by emulating calling by name
/// and also for doing access control. This type is for the later.
and DM =
    | D2M of d2M
    | D4M of d4M

    interface IDisposable with
        member t.Dispose() =
            match t with
            | D2M(x) -> x |> dispose
            | D4M(x) -> x |> dispose

and d2M =
    {
    mutable rc : int * int
    mutable diff: AutoDiffType
    mutable is_dead : DeadFlagType // flag to skip backprop
    }

    static member private size_rc (row,col) = row*col

    /// Add the rows and column of the 2d matrix.
    member t.AddDims = t.rc |> fun (r,c) -> r+c
    
    static member create' (size : (int * int), is_constant) =
        let diff = 
            let s = d2M.size_rc size
            match is_constant with
            | true -> AutoDiffType.CreatePrimalOnly s
            | false -> AutoDiffType.CreatePA s
        {rc = size; diff=diff; is_dead=Undefined}

    static member create' (size : (int * int), host_data : float32[], is_constant) =
        let t = d2M.create' (size, is_constant)
        t.diff.CopyToPrimal(host_data)
        t

    // Constructors for the singular d2M records.
    static member inline create (ar : int * int) = d2M.create'(ar, false)
    static member inline create (row : int, col : int) = d2M.create'((row, col), false)
    static member inline create (row : int, col : int, ar_data : float32[]) = d2M.create'((row,col),ar_data, false)
    static member inline create (size : int * int, ar_data : float32[]) = d2M.create'(size,ar_data, false)
    static member inline createConstant (size : int * int) = d2M.create'(size, true)
    static member inline createConstant (row : int, col : int, ar_data : float32[]) = d2M.create'((row,col),ar_data, true)
    static member inline createConstant (size : int * int, ar_data : float32[]) = d2M.create'(size,ar_data, true)

    /// Number of rows
    member t.Rows = t.rc |> fst
    /// Number of columns
    member t.Columns = t.rc |> snd  
    /// Returns whether the function has an adjoint
    member t.HasAdjoint = t.diff.HasAdjoint
  
    /// Returns the size of matrix
    member t.Size = d2M.size_rc t.rc

    /// Returns matrix of the same dimensions at the current one without copying the values.
    member t.GhostCopy is_constant = d2M.create'(t.rc,is_constant)

    /// Returns matrix of the same inner dimension as the current one without copying the values.
    member t.GhostCopyBias is_constant = d2M.create'((t.Rows,1),is_constant)

    /// Get Adjoint Pointer
    member t.GAP = t.diff.A.DevicePointer

    /// Get Primal Pointer
    member t.GPP = t.diff.P.DevicePointer

    /// Get Adjoint Variable
    member t.GAV = t.diff.A

    /// Get Primal Variable
    member t.GPV = t.diff.P

    /// Get row and column
    member t.RC = t.rc
    
    /// Get the deadness flag
    member t.IsDead = t.is_dead

    /// Update the deadness flag
    member t.DeadIs v = t.is_dead <- v

    /// CUDNN has a bug where it is ridicously slow if the dimensions are not set up right.
    /// So this function is to get nchw of the matrix for the tensor_add function.
    member t.NCHW =
        (t.Columns,1,t.Rows,1)
        // (t.Columns,t.Rows,1,1) is 10x slower than the above
        // There are other fast configurations, but it is unfortunate that I picked the
        // Wrong one for SpiralV3. Now that I know duck typing, writing generic code will be
        // much easier.

    /// Returns the nchw (for the buggy tensor_add function)
    /// The stupid cuDNN function will throw an exception if I put in the parameters for the fast version.
    member t.NCHWBiasAdd = (t.Columns,t.Rows,1,1)

    /// Throws an exception if the sizes are not all equal
    static member GuardSizes(x:d2M, o: d2M) =
        if x.rc <> o.rc then failwithf "x.rc(%A) <> o.rc(%A)" x.rc o.rc

    /// Throws an exception if the sizes are not all equal
    static member GuardSizes(x:d2M, y:d2M, o: d2M) =
        if x.rc <> y.rc then failwithf "x.rc(%A) <> y.rc(%A)" x.rc y.rc
        if y.rc <> o.rc then failwithf "y.rc(%A) <> o.rc(%A)" y.rc o.rc

    /// Throws an exception if the sizes are not all equal
    static member GuardSizes(x:d2M, y:d2M, z: d2M, o: d2M) =
        if x.rc <> y.rc then failwithf "x.rc(%A) <> y.rc(%A)" x.rc y.rc
        if y.rc <> z.rc then failwithf "y.rc(%A) <> z.rc(%A)" y.rc z.rc
        if z.rc <> o.rc then failwithf "z.rc(%A) <> o.rc(%A)" z.rc o.rc

    /// Resizes the object. Does not free memory when resizing downwards.
    member t.ReplaceIf (ar : int * int, is_constant) =
        t.rc <- ar
        let new_size = d2M.size_rc ar
        match is_constant with
        | true -> t.diff <- t.diff.ResizePrimalOnly new_size
        | false -> t.diff <- t.diff.ResizePrimalAndAdjoint new_size

    /// Gets an object the same size as self from the object pool
    member inline t.GetFromObjectPool(obj_pool: ObjectPool, is_constant, is_inference_only, str: CudaStream) =
        obj_pool.Getd2M(is_constant,t.rc,is_inference_only,str)

    /// Copies the object by using the memory from the object pool.
    member inline t.CopyUsingObjectPool(obj_pool: ObjectPool, is_constant, is_inference_only, str: CudaStream) =
        let x = obj_pool.Getd2M(is_constant,t.rc,is_inference_only,str)
        x.GPV.AsyncCopyToDevice(t.GPV,str.Stream)
        x

    /// Sets the adjoint to a value.
    member inline t.SetAdjoint(x: float32, str: CudaStream) = 
        let v = BitConverter.ToUInt32(BitConverter.GetBytes(x),0)
        t.diff.A.MemsetAsync(v,str.Stream)

    /// Set the matrix to a value.
    member inline t.SetPrimal (x: float32, str: CudaStream) = 
        let v = BitConverter.ToUInt32(BitConverter.GetBytes(x),0)
        t.diff.P.MemsetAsync(v,str.Stream)

    /// For temporary immediate use only.
    member t.ConvertdMLikeFromWorkspace(w: Workspace) =
        let v = w.ResizeIf<float32> t.Size
        {rc = t.rc; diff = PrimalOnly v; is_dead = Undefined}

    /// Cast to DM.
    member t.CastToDM = D2M t

    /// Returns the contents of the primal in a 1D array to host.
    member t.GatherPrimal =
        t.GPV.Gather()

    /// Returns the contents of the primal in a 2D array to host.
    member t.ToFloat32Array2D =
        let x = t.GatherPrimal
        Array2D.init t.Rows t.Columns <| fun r c -> x.[c*t.Rows+r]

    interface IDisposable with
        member t.Dispose() = t.diff |> dispose

and d4M =
    {
    mutable nchw : int * int * int * int
    mutable diff : AutoDiffType
    mutable is_dead : DeadFlagType // flag to skip backprop
    }

    /// Adds the image,channel, width and height dimensions of the 4d tensor.
    member t.AddDims = t.nchw |> fun (n,c,h,w) -> n+c+h+w

    static member private size_nchw (n:int,c,h,w) = n*c*h*w

    static member create' (size : (int * int * int * int), is_constant) =
        let diff = 
            let s = d4M.size_nchw size
            match is_constant with
            | true -> AutoDiffType.CreatePrimalOnly s
            | false -> AutoDiffType.CreatePA s
        {nchw = size; diff=diff ; is_dead=Undefined}

    static member create' (size : int * int * int * int, host_data : float32[], is_constant) =
        let t = d4M.create' (size, is_constant)
        t.diff.CopyToPrimal(host_data)
        t

    // Constructors for the singular d4M records.
    static member inline create (ar: int * int * int * int) = d4M.create'(ar, false)
    static member inline create (ar: (int * int * int * int), data: float32[]) = d4M.create'(ar, data, false)
    static member inline createConstant (ar : int * int * int * int) = d4M.create'(ar, true)
    static member inline createConstant (ar: (int * int * int * int), data: float32[]) = d4M.create'(ar, data, true)

    /// Number of rows (concatenates along the c,h,w dimensions)
    member t.Rows = t.nchw |> fun (_,c,h,w) -> c*h*w
    /// Number of columns (return the outer n dimension)
    member t.Columns = t.nchw |> fun (n,_,_,_) -> n
    /// Returns whether the function has an adjoint
    member t.HasAdjoint = t.diff.HasAdjoint

    /// Returns the size of matrix
    member t.Size = d4M.size_nchw t.nchw

    /// Returns matrix of the same dimensions at the current one without copying the values.
    member t.GhostCopy is_constant = d4M.create'(t.nchw,is_constant)
        
    /// Returns matrix of the same inner dimensions as the current one without copying the values.
    member t.GhostCopyBias is_constant = 
        t.nchw |> fun (_,c,h,w) ->
            d4M.create'((1,c,h,w),is_constant)

    /// Get Adjoint Pointer
    member t.GAP = t.diff.A.DevicePointer

    /// Get Primal Pointer
    member t.GPP = t.diff.P.DevicePointer

    /// Get Adjoint Variable
    member t.GAV = t.diff.A

    /// Get Primal Variable
    member t.GPV = t.diff.P

    /// Returns the tensor's dimensions projected 
    /// to a 2D space according to the following formula:
    /// row = c*h*w
    /// column = n
    member t.RC = t.Rows, t.Columns
    
    /// Get the deadness flag
    member t.IsDead = t.is_dead

    /// Update the deadness flag
    member t.DeadIs v = t.is_dead <- v

    /// Returns the nchw
    member t.NCHW = t.nchw

    /// Returns the nchw (for the buggy tensor_add function)
    member t.NCHWBiasAdd = t.nchw

    /// Throws an exception if the sizes are not all equal
    static member inline GuardSizes(x:d4M, o: d4M) =
        if x.nchw <> o.nchw then failwithf "x.rc(%A) <> o.rc(%A)" x.nchw o.nchw

    /// Throws an exception if the sizes are not all equal
    static member inline GuardSizes(x:d4M, y:d4M, o: d4M) =
        if x.nchw <> y.nchw then failwithf "x.rc(%A) <> y.rc(%A)" x.nchw y.nchw
        if y.nchw <> o.nchw then failwithf "y.rc(%A) <> o.rc(%A)" y.nchw o.nchw

    /// Throws an exception if the sizes are not all equal
    static member inline GuardSizes(x:d4M, y:d4M, z: d4M, o: d4M) =
        if x.nchw <> y.nchw then failwithf "x.rc(%A) <> y.rc(%A)" x.nchw y.nchw
        if y.nchw <> z.nchw then failwithf "y.rc(%A) <> z.rc(%A)" y.nchw z.nchw
        if z.nchw <> o.nchw then failwithf "z.rc(%A) <> o.rc(%A)" z.nchw o.nchw

    /// Resizes the object. Does not free memory when resizing downwards.
    member t.ReplaceIf (ar : (int * int * int * int), is_constant) =
        t.nchw <- ar
        let new_size = d4M.size_nchw ar
        match is_constant with
        | true -> t.diff <- t.diff.ResizePrimalOnly new_size
        | false -> t.diff <- t.diff.ResizePrimalAndAdjoint new_size

    /// Gets an object the same size as it from the object pool
    member inline t.GetFromObjectPool(obj_pool: ObjectPool, is_constant, is_inference_only, str: CudaStream) =
        obj_pool.Getd4M(is_constant,t.nchw,is_inference_only,str)

    /// Copies the object by using the memory from the object pool.
    member inline t.CopyUsingObjectPool(obj_pool: ObjectPool, is_constant, is_inference_only, str: CudaStream) =
        let x = obj_pool.Getd4M(is_constant,t.nchw,is_inference_only,str)
        x.GPV.AsyncCopyToDevice(t.GPV,str.Stream)
        x

    /// Sets the adjoint to a value.
    member inline t.SetAdjoint(x: float32, str: CudaStream) = 
        let v = BitConverter.ToUInt32(BitConverter.GetBytes(x),0)
        t.diff.A.MemsetAsync(v,str.Stream)

    /// Set the matrix to a value.
    member inline t.SetPrimal (x: float32, str: CudaStream) = 
        let v = BitConverter.ToUInt32(BitConverter.GetBytes(x),0)
        t.diff.P.MemsetAsync(v,str.Stream)

    /// For temporary immediate use only.
    member t.ConvertdMLikeFromWorkspace(w: Workspace) =
        let v = w.ResizeIf<float32> t.Size
        {nchw = t.nchw; diff = PrimalOnly v; is_dead = Undefined}

    /// Cast to DM.
    member t.CastToDM = D4M t

    interface IDisposable with
        member t.Dispose() = t.diff |> dispose

/// The new object pool. Zeroes out the adjoints concurrently on the forward phase.
and ObjectPool() =
    let d2MPool = ResizeArray()
    let d2Mp = ref 0
    let d4MPool = ResizeArray()
    let d4Mp = ref 0

    let tensorDescriptorPool = Dictionary(HashIdentity.Structural)
    let filterDescriptorPool = Dictionary(HashIdentity.Structural)
    let convolutionDescriptorPool = Dictionary(HashIdentity.Structural)
    let poolingDescriptorPool = Dictionary(HashIdentity.Structural)
    let activationDescriptorPool = Dictionary(HashIdentity.Structural)
    let BNDescriptorPool = Dictionary(HashIdentity.Structural)

    static member inline private GetFromPool (pool : ResizeArray<_>) (pointer_to_pool : int ref) (creation_function) =
        if pool.Count > !pointer_to_pool then
            let t = pool.[!pointer_to_pool]
            pointer_to_pool := !pointer_to_pool+1
            t
        else
            let t = creation_function()
            pool.Add(t)
            pointer_to_pool := !pointer_to_pool+1
            t

    static member inline private GetFromDict (pool : Dictionary<_,_>) k creation_function set_function =
        match pool.TryGetValue k with
        | true, v -> v
        | false, _ ->
            let t = creation_function()
            set_function t k
            pool.Add(k, t)
            t

    member t.Getd2M (is_constant, (rc : (int*int)), is_inference_only, str: CudaStream): d2M =
        let t' = ObjectPool.GetFromPool d2MPool d2Mp (fun _ -> d2M.create'(rc,is_constant))
        t'.ReplaceIf(rc,is_constant)
        t'.is_dead <- Undefined
        if is_inference_only = false && t'.HasAdjoint then t'.diff.A.MemsetAsync(0u,str.Stream)
        t'

    member t.Getd4M (is_constant, (nchw : (int*int*int*int)), is_inference_only, str: CudaStream): d4M =
        let t' = ObjectPool.GetFromPool d4MPool d4Mp (fun _ -> d4M.create'(nchw,is_constant))

        t'.ReplaceIf(nchw,is_constant)
        t'.is_dead <- Undefined
        if is_inference_only = false && t'.HasAdjoint then t'.diff.A.MemsetAsync(0u,str.Stream)
        t'

    member t.GetTensorDescriptor (nchw : int*int*int*int) = 
        ObjectPool.GetFromDict tensorDescriptorPool nchw (fun _ -> new TensorDescriptor()) (fun (t: TensorDescriptor) x -> x |> t.SetTensor4dDescriptor)
    member t.GetFilterDescriptor (nchw : int*int*int*int) = 
        ObjectPool.GetFromDict filterDescriptorPool nchw (fun _ -> new FilterDescriptor()) (fun (t: FilterDescriptor) x -> x |> t.SetFilter4dDescriptor)
    member t.GetConvolutionDescriptor (convPars : ConvolutionParameters) = 
        ObjectPool.GetFromDict convolutionDescriptorPool convPars (fun _ -> new ConvolutionDescriptor()) (fun (t: ConvolutionDescriptor) x -> x |> t.SetConvolution2dDescriptor)
    member t.GetPoolingDescriptor (p : PoolingParameters) = 
        ObjectPool.GetFromDict poolingDescriptorPool p (fun _ -> new PoolingDescriptor()) (fun (t: PoolingDescriptor) x -> x |> t.SetPooling2dDescriptor)
    member t.GetActivationDescriptor (mode : cudnnActivationMode, nanopt : cudnnNanPropagation, reluCeiling as p) = 
        ObjectPool.GetFromDict activationDescriptorPool p (fun _ -> new ActivationDescriptor()) (fun (t: ActivationDescriptor) x -> x |> t.SetActivationDescriptor)
    member t.GetBNDescriptor ((nchw : int*int*int*int, mode : cudnnBatchNormMode, srcDesc : TensorDescriptor) as p) = 
        ObjectPool.GetFromDict BNDescriptorPool p 
            (fun _ -> new TensorDescriptor()) 
            (fun (t: TensorDescriptor) (nchw, mode, srcDesc) -> cudnn.DeriveBNTensorDescriptor(t,srcDesc,mode))

    // Resets the pointer in the object pool
    member t.Reset() =
        d2Mp := 0
        d4Mp := 0

    interface IDisposable with
        member __.Dispose() =
            let inline dis' ex pool = 
                // The disposer helper. Uses an extractor for the dictionary values.
                // This succintly demonstrates how to get around the lack of higher kinded types in F#.
                let pool = ex pool
                for x in pool do dispose x
            let inline dis x = dis' id x
            dis d2MPool
            dis d4MPool

            let inline dis x = 
                dis' (fun v -> (^a: (member Values: ^b) v)) x
            dis tensorDescriptorPool // ...It would have been faster to just copy paste .Value everywhere.
            dis filterDescriptorPool
            dis convolutionDescriptorPool
            dis poolingDescriptorPool
            dis activationDescriptorPool
            dis BNDescriptorPool

let T = Operation.Transpose
let nT = Operation.NonTranspose

let inline extract_primal x = (^a : (member GPP: CUdeviceptr) x)
let inline extract_adjoint x = (^a : (member GAP: CUdeviceptr) x)
let inline extract_primal' x = (^a: (member GPV: CudaDeviceVariable<float32>) x)
let inline extract_adjoint' x = (^a: (member GAV: CudaDeviceVariable<float32>) x)
let inline rc x = (^a: (member RC: int * int) x)

let inline GuardSizes2(x,y) =
    (^a: (static member GuardSizes: ^a * ^a -> unit) (x,y))
let inline GuardSizes3(x,y,z) =
    (^a: (static member GuardSizes: ^a * ^a * ^a -> unit) (x,y,z))
let inline GuardSizes4(x,y,z,o) =
    (^a: (static member GuardSizes: ^a * ^a * ^a * ^a -> unit) (x,y,z,o))
let inline Size x =
    (^a : (member Size: int) x)

let inline P x: (^a -> CUdeviceptr) * ^a = (extract_primal, x)
let inline A x: (^a -> CUdeviceptr) * ^a = (extract_adjoint, x)
let inline P' x: (^a -> CudaDeviceVariable<float32>) * ^a = (extract_primal', x)
let inline A' x: (^a -> CudaDeviceVariable<float32>) * ^a = (extract_adjoint', x)

let inline rows x = (^a : (member Rows: int) x)
let inline cols x = (^a : (member Columns: int) x)
let inline size x = (^a : (member Size: int) x)

let inline setPrimal x (v,str) = (^a : (member SetPrimal: float32 * CudaStream -> unit) x, v, str)
let inline setAdjoint x (v,str) = (^a : (member SetAdjoint: float32 * CudaStream -> unit) x, v, str)

let inline isDead x = (^a : (member IsDead: DeadFlagType) x)
let inline deadIs x v = (^a : (member DeadIs: DeadFlagType -> unit) x, v)

let inline hasAdjoint x = (^a : (member HasAdjoint: bool) x)

let inline nchw x =
    (^a: (member NCHW: int * int * int * int) x)

/// Helper for the buggy tensor_add function.
let inline nchwBiasAdd x =
    (^a: (member NCHWBiasAdd: int * int * int * int) x)

let inline convertdMLikeFromWorkspace (x: ^a) (w: Workspace) =
    (^a: (member ConvertdMLikeFromWorkspace: Workspace -> ^a) x, w)

let inline addDims x =
    (^a: (member AddDims: int) x)

let inline divup a b = (a-1)/b+1 // Integer division with rounding up. (a+b-1)/b is another variant on this.

let visual_studio_path = //"C:/Program Files (x86)/Microsoft Visual Studio 14.0" usually.
    let x = Environment.GetEnvironmentVariable("VS140COMNTOOLS")
    if x <> null then IO.Directory.GetParent(x).Parent.Parent.FullName
    else failwith "VS140COMNTOOLS environment variable not found. Make sure VS2015 is installed."

let cuda_toolkit_path = 
    let x = System.Environment.GetEnvironmentVariable("CUDA_PATH_V8_0")
    if x <> null then x
    else failwith "CUDA_PATH_V8_0 environment variable not found. Make sure Cuda 8.0 SDK is installed."

let cub_path = // The path for the Cuda Unbound library.
    let x = System.Environment.GetEnvironmentVariable("CUB_PATH")
    if x <> null then x
    else 
        failwith 
            """If you are getting this exception then that means that CUB_PATH environment variable is not defined.

Go to: https://nvlabs.github.io/cub/index.html#sec6
...and download the latest version of the library, extract it somewhere like, 
eg. : C:\cub-1.6.3
and add that directory to the global enviroment by creating the CUB_PATH variable with a pointer to it."""

let kernels_dir = IO.Path.Combine(__SOURCE_DIRECTORY__,"Cuda Kernels")
IO.Directory.CreateDirectory(kernels_dir) |> ignore // Creates the Cuda Kernels directory if it does not exist. WriteAllBytes would otherwise throw an exception.

let compile_kernel_nvrtc (kernel_code: string) (kernel_name: string) = 
    let kernel_path = IO.Path.Combine(kernels_dir,kernel_name)
    let k = new ManagedCuda.NVRTC.CudaRuntimeCompiler(kernel_code,kernel_name)
    try k.Compile(
            [|
            "-arch=compute_30"
            "--std=c++11" // Surprisingly, NVRTC does support C++11 which means lambdas. Unfortunately, it does not support Thrust, so no tuples.
                          // ...So it is still pretty useless all things considered compared to NVCC.
            |])
    with 
    | :? NVRTCException as x -> 
        printfn "%s" (k.GetLogAsString())
        reraise()
    let ptx = k.GetPTX()
    IO.File.WriteAllBytes(kernel_path,ptx)
    cuda_context.LoadKernelPTX(ptx,kernel_name)

let inline compile_kernel_using_nvcc_bat_router (kernel_code: string) (kernel_name: string) =
    let nvcc_router_path = Path.Combine(kernels_dir,"nvcc_router.bat")
    use p = 
        let procStartInfo = 
            ProcessStartInfo(
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                FileName = nvcc_router_path)

        let outputHandler f (_sender:obj) (args:DataReceivedEventArgs) = f args.Data
        let p = new Process(StartInfo = procStartInfo)
        let print_to_standard_output = outputHandler <| fun x -> printfn "%s" x
        //p.OutputDataReceived.AddHandler(DataReceivedEventHandler (print_to_standard_output))
        p.ErrorDataReceived.AddHandler(DataReceivedEventHandler (print_to_standard_output))
        p

    /// Puts quotes around the string.
    let quote x = sprintf "\"%s\"" x
    let call x = sprintf "call %s" x
    let quoted_vs_path_to_vcvars = Path.Combine(visual_studio_path, @"VC\bin\x86_amd64\vcvarsx86_amd64.bat") |> quote
    let quoted_vs_path_to_cl = Path.Combine(visual_studio_path, @"VC\bin\x86_amd64") |> quote
    let quoted_cuda_toolkit_path_to_include = Path.Combine(cuda_toolkit_path,"include") |> quote
    let quoted_cub_path_to_include = cub_path |> quote
    let quoted_kernels_dir = kernels_dir |> quote
    let target_path = Path.Combine(kernels_dir,kernel_name+".ptx")
    let quoted_target_path = target_path |> quote
    let input_path = Path.Combine(kernels_dir,"_temp.cu")
    let quoted_input_path = input_path |> quote
    
    if File.Exists input_path then File.Delete input_path
    File.WriteAllText(input_path,kernel_code)

    let _ = 
        if File.Exists nvcc_router_path then File.Delete nvcc_router_path
        use nvcc_router_file = File.OpenWrite(nvcc_router_path)
        use nvcc_router_stream = new StreamWriter(nvcc_router_file)

        nvcc_router_stream.WriteLine(call quoted_vs_path_to_vcvars)
        nvcc_router_stream.WriteLine(
            sprintf 
                """nvcc -gencode=arch=compute_30,code=\"sm_30,compute_30\" --use-local-env --cl-version 2015 -ccbin %s  -I%s -I%s --keep-dir %s -maxrregcount=0  --machine 64 -ptx -cudart static  -o %s %s"""
                quoted_vs_path_to_cl quoted_cuda_toolkit_path_to_include quoted_cub_path_to_include quoted_kernels_dir quoted_target_path quoted_input_path)

    if p.Start() = false then failwith "NVCC failed to run."
    p.BeginOutputReadLine()
    p.BeginErrorReadLine()
    p.WaitForExit()

    if p.ExitCode <> 0 then failwithf "NVCC failed compilation with code %i" p.ExitCode

    cuda_context.LoadKernelPTX(target_path,kernel_name)

let load_kernel compile_kernel (kernel_code: string) (kernel_name: string) = 
    let kernel_path = IO.Path.Combine(kernels_dir,kernel_name)
        
    if IO.File.Exists(kernel_path) 
    then
        cuda_context.LoadKernelPTX(kernel_path,kernel_name) // For all the modules, it takes roughly 0.35s to compile them. Loading them from drive takes less than a millisecond.
    else
        compile_kernel kernel_code kernel_name

let inline load_kernel_nvrtc kernel_code kernel_name = load_kernel compile_kernel_nvrtc kernel_code kernel_name
let inline load_kernel_nvcc kernel_code kernel_name = load_kernel compile_kernel_using_nvcc_bat_router kernel_code kernel_name

let inline map_launcher(str: CudaStream, kernel: CudaKernel, total_size: int, [<ParamArray>] args: obj[]) =
    let block_size = 256
    let gridSize = min (2*numSm*(1024/block_size)) (divup total_size block_size)
    kernel.GridDimensions <- dim3(gridSize)
    kernel.BlockDimensions <- dim3(block_size)
    kernel.RunAsync(str.Stream, args)

/// o <- f(x)
type DeviceUnaryTransformModule(op: string, unique_name : string) = 
    let kernel_name = "Map1Kernel"+unique_name
    let kernel_code = 
        [|"
        //Kernel code:
        extern \"C\" {
            typedef float floatType;
            __device__ inline floatType op(floatType x)
            {
                return ";op;"
            }
        
            // Device code
            __global__ void ";kernel_name;"(const floatType* A, floatType* O, const int N)
            {
                int i = blockDim.x * blockIdx.x + threadIdx.x;
                const int stride = blockDim.x * gridDim.x;
                while (i < N)
                {
                    O[i] = op(A[i]);
                    i += stride;
                }
            }
        }

        " |] |> String.concat ""

    member val Kernel = load_kernel_nvrtc kernel_code kernel_name
    member inline t.A
            (str: CudaStream,
                (ext_x: ^a -> CUdeviceptr, x: ^a),
                (ext_o: ^a -> CUdeviceptr, o: ^a)) =
        GuardSizes2(x,o)
        let n = Size x
        map_launcher(str, t.Kernel, n, [|ext_x x; ext_o o; n|])

/// o <- f(x,y)
type DeviceBinaryTransformModule(op: string, unique_name) = 
    let kernel_name = "Map2Kernel" + unique_name
    let kernel_code = 
        [|"
        //Kernel code:
        extern \"C\" {
            typedef float floatType;
            __device__ inline floatType op(floatType x, floatType y)
            {
                return ";op;"
            }
        
            // Device code
            __global__ void ";kernel_name;"(const floatType* A, const floatType* B, floatType* O, const int N)
            {
                int i = blockDim.x * blockIdx.x + threadIdx.x;
                const int stride = blockDim.x * gridDim.x;
                while (i < N)
                {
                    O[i] = op(A[i],B[i]);
                    i += stride;
                }
            }
        }

        " |] |> String.concat ""
    
    member val Kernel = load_kernel_nvrtc kernel_code kernel_name
    member inline t.A
            (str: CudaStream,
                (ext_x: ^a -> CUdeviceptr, x: ^a),
                (ext_y: ^a -> CUdeviceptr, y: ^a),
                (ext_o: ^a -> CUdeviceptr, o: ^a)) =
        GuardSizes3(x,y,o)
        let n = Size x
        map_launcher(str, t.Kernel, n, [|ext_x x; ext_y y; ext_o o; n|])

/// o <- f(x,y,z)
type DeviceTrinaryTransformModule(op: string, unique_name) = 
    let kernel_name = "Map3Kernel" + unique_name
    let kernel_code = 
        [|"
        //Kernel code:
        extern \"C\" {
            typedef float floatType;
            __device__ inline floatType op(floatType x, floatType y, floatType z)
            {
                return ";op;"
            }
        
            // Device code
            __global__ void ";kernel_name;"(const floatType* A, const floatType* B, const floatType* C, floatType* O, const int N)
            {
                int i = blockDim.x * blockIdx.x + threadIdx.x;
                const int stride = blockDim.x * gridDim.x;
                while (i < N)
                {
                    O[i] = op(A[i],B[i],C[i]);
                    i += stride;
                }
            }
        }

        " |] |> String.concat ""

    member val Kernel = load_kernel_nvrtc kernel_code kernel_name
    member inline t.A
            (str: CudaStream,
                (ext_x: ^a -> CUdeviceptr, x: ^a),
                (ext_y: ^a -> CUdeviceptr, y: ^a),
                (ext_z: ^a -> CUdeviceptr, z: ^a),
                (ext_o: ^a -> CUdeviceptr, o: ^a)) =
        GuardSizes4(x,y,z,o)
        let n = Size x
        map_launcher(str, t.Kernel, n, [|ext_x x; ext_y y; ext_z z; ext_o o; n|])

let inline map_sum_launcher(str: CudaStream, kernel: CudaKernel, total_size: int, o: CudaDeviceVariable<float32>, [<ParamArray>] args: obj[]) =
    let block_size = 256
    let gridSize = min (2*numSm*(1024/block_size)) (divup total_size block_size)
    kernel.GridDimensions <- dim3(gridSize)
    kernel.BlockDimensions <- dim3(block_size)

    kernel.RunAsync(str.Stream, args)
    lazy o.[SizeT 0]

/// o <- sum(f(x))
type DeviceUnaryMapSumModule(op: string, unique_name) = 
    let kernel_name = "Map1SumKernel" + unique_name
    let kernel_code = 
        [|"
        //Kernel code:
        extern \"C\" {
            typedef float floatType;
            __device__ inline floatType op(floatType x)
            {
                return ";op;"
            }
        
            __device__ inline floatType warpDownReduce(floatType value){
                #pragma unroll
	            for (int i = 16; i>0; i = i / 2) value += __shfl_down(value, i);
	            return value;
            }

            // Device code
            __global__ void ";kernel_name;"(const floatType* A, floatType* O, const int N)
            {
	            int i = blockDim.x * blockIdx.x + threadIdx.x;
	            const int stride = blockDim.x * gridDim.x;
	            __shared__ floatType temp[32];
                if (threadIdx.x < 32) {
                    temp[threadIdx.x] = 0.0f; 
                    if (blockIdx.x == 0) O[0] = 0.0f;
                    }
                
                floatType acc = 0.0f;
	            while (i < N)
	            {
		            acc += op(A[i]);
		            i += stride;
	            }
	            __syncthreads(); 
                floatType out_partial = warpDownReduce(acc);
	            if (threadIdx.x % 32 == 0) temp[threadIdx.x / 32] = out_partial;
	            __syncthreads();
	            if (threadIdx.x < 32) out_partial = warpDownReduce(temp[threadIdx.x]);
	            if (threadIdx.x == 0) atomicAdd(O, out_partial);
            }
        }

        " |] |> String.concat ""

    member val Kernel = load_kernel_nvrtc kernel_code kernel_name
    member val O = new CudaDeviceVariable<float32>(SizeT 1)
    member inline t.A
            (str: CudaStream,
                (ext_x: ^a -> CUdeviceptr, x: ^a)) =
        let n = Size x
        map_sum_launcher(str, t.Kernel, n, t.O, [|ext_x x; t.O.DevicePointer; n|])

/// o <- sum(f(x,y))
type DeviceBinaryMapSumModule(op: string, unique_name) = 
    let kernel_name = "Map2SumKernel" + unique_name
    let kernel_code = 
        [|"
        //Kernel code:
        extern \"C\" {
            typedef float floatType;
            __device__ inline floatType op(floatType x, floatType y)
            {
                return ";op;"
            }
        
            __device__ inline floatType warpDownReduce(floatType value){
                #pragma unroll
	            for (int i = 16; i>0; i = i / 2) value += __shfl_down(value, i);
	            return value;
            }

            // Device code
            __global__ void ";kernel_name;"(const floatType* A, const floatType* B, floatType* O, const int N)
            {
	            int i = blockDim.x * blockIdx.x + threadIdx.x;
	            const int stride = blockDim.x * gridDim.x;
	            __shared__ floatType temp[32]; 
                if (threadIdx.x < 32) {
                    temp[threadIdx.x] = 0.0f; 
                    if (blockIdx.x == 0) O[0] = 0.0f;
                    }    
                floatType acc = 0.0f;
	            while (i < N)
	            {
		            acc += op(A[i],B[i]);
		            i += stride;
	            }
	            __syncthreads(); 
                floatType out_partial = warpDownReduce(acc);
	            if (threadIdx.x % 32 == 0) temp[threadIdx.x / 32] = out_partial;
	            __syncthreads();
	            if (threadIdx.x < 32) out_partial = warpDownReduce(temp[threadIdx.x]);
	            if (threadIdx.x == 0) atomicAdd(O, out_partial);
            }
        }

        " |] |> String.concat ""

    member val Kernel = load_kernel_nvrtc kernel_code kernel_name
    member val O = new CudaDeviceVariable<float32>(SizeT 1)
    member inline t.A
            (str: CudaStream,
                (ext_x: ^a -> CUdeviceptr, x: ^a),
                (ext_y: ^a -> CUdeviceptr, y: ^a)) =
        GuardSizes2(x,y)
        let n = Size x
        map_sum_launcher(str, t.Kernel, n, t.O, [|ext_x x; ext_y y; t.O.DevicePointer; n|])

/// o <- f(coef_x,x)
type DeviceUnaryCoefTransformModule(op: string, unique_name) = 
    let block_size = 256

    let kernel_name = "Map1CoefKernel" + unique_name
    let kernel_code = 
        [|"
        //Kernel code:
        extern \"C\" {
            typedef float floatType;
            __device__ inline floatType op(floatType coef_x, floatType x)
            {
                return ";op;"
            }
        
            // Device code
            __global__ void ";kernel_name;"(const floatType coef_A, const floatType* A, floatType* O, const int N)
            {
                int i = blockDim.x * blockIdx.x + threadIdx.x;
                const int stride = blockDim.x * gridDim.x;
                while (i < N)
                {
                    O[i] = op(coef_A,A[i]);
                    i += stride;
                }
            }
        }

        " |] |> String.concat ""

    member val Kernel = load_kernel_nvrtc kernel_code kernel_name
    member inline t.A
            (str: CudaStream,
                coef_x: float32, (ext_x: ^a -> CUdeviceptr, x: ^a), 
                                (ext_o: ^a -> CUdeviceptr, o: ^a)) =
        GuardSizes2(x,o)
        let n = Size x
        map_launcher(str, t.Kernel, n, [|coef_x; ext_x x; ext_o o; n|])


/// o <- f(coef_x,x,coef_y,y)
type DeviceBinaryCoefTransformModule(op: string, unique_name) = 
    let block_size = 256

    let kernel_name = "Map2CoefKernel" + unique_name
    let kernel_code = 
        [|"
        //Kernel code:
        extern \"C\" {
            typedef float floatType;

            __device__ inline floatType op(floatType coef_x, floatType x, floatType coef_y, floatType y)
            {
                return ";op;"
            }
        
            // Device code
            __global__ void ";kernel_name;"(const floatType coef_A, const floatType* A, const floatType coef_B, const floatType* B, floatType* O, const int N)
            {
                int i = blockDim.x * blockIdx.x + threadIdx.x;
                const int stride = blockDim.x * gridDim.x;
                while (i < N)
                {
                    O[i] = op(coef_A,A[i],coef_B,B[i]);
                    i += stride;
                }
            }
        }

        " |] |> String.concat ""

    member val Kernel = load_kernel_nvrtc kernel_code kernel_name
    member inline t.A
            (str: CudaStream,
                coef_x: float32, (ext_x: ^a -> CUdeviceptr, x: ^a), 
                coef_y: float32, (ext_y: ^a -> CUdeviceptr, y: ^a), 
                                (ext_o: ^a -> CUdeviceptr, o: ^a)) =
        GuardSizes3(x,y,o)
        let n = Size x
        map_launcher(str, t.Kernel, n, [|coef_x; ext_x x; coef_y; ext_y y; ext_o o; n|])


/// o <- f(coef_x,x,coef_y,y,coef_z,z)
type DeviceTrinaryCoefTransformModule(op: string, unique_name) = 
    let block_size = 256

    let kernel_name = "Map3CoefKernel" + unique_name
    let kernel_code = 
        [|"
        //Kernel code:
        extern \"C\" {
            typedef float floatType;
            __device__ inline floatType op(floatType coef_x, floatType x, floatType coef_y, floatType y, floatType coef_z, floatType z)
            {
                return ";op;"
            }
        
            // Device code
            __global__ void ";kernel_name;"(const floatType coef_A, const floatType* A, const floatType coef_B, const floatType* B, const floatType coef_C, const floatType* C, floatType* O, const int N)
            {
                int i = blockDim.x * blockIdx.x + threadIdx.x;
                const int stride = blockDim.x * gridDim.x;
                while (i < N)
                {
                    O[i] = op(coef_A,A[i],coef_B,B[i],coef_C,C[i]);
                    i += stride;
                }
            }
        }

        " |] |> String.concat ""

    member val Kernel = load_kernel_nvrtc kernel_code kernel_name
    member inline t.A
            (str: CudaStream,
                coef_x: float32, (ext_x: ^a -> CUdeviceptr, x: ^a), 
                coef_y: float32, (ext_y: ^a -> CUdeviceptr, y: ^a), 
                coef_z: float32, (ext_z: ^a -> CUdeviceptr, z: ^a), 
                                (ext_o: ^a -> CUdeviceptr, o: ^a)) =
        GuardSizes4(x,y,z,o)
        let n = Size x
        map_launcher(str, t.Kernel, n, [|coef_x; ext_x x; coef_y; ext_y y; coef_z; ext_z z; ext_o o; n|])

/// Launcher for the max column kernels with the block size specified.
let inline max_column_launcher (block_size: int option) (str: CudaStream, kernel: CudaKernel, num_rows: int, num_columns: int, args: obj[]) =
    let block_size = 
        match block_size with
        | Some v -> min v num_rows |> max 32
        | None -> min 128 num_rows |> max 32

    kernel.GridDimensions <- dim3(num_columns)
    kernel.BlockDimensions <- dim3(block_size)
    kernel.RunAsync(str.Stream, args)

/// o <- max_col(x)
/// Sets all except one of the max of a column to zero.
/// TODO: Replace this one with the new kernel. It has a faulty block reduce operation.
type DeviceMaxColumnActivationModule() = 
    let kernel_name = "MaxColumnActivationKernel"
    let kernel_code = 
        [|"
        //Kernel code:
        extern \"C\" {
            typedef float floatType;
            #define INIT __int_as_float(0xff800000) // The constant init for the reduce operations. This is float negative infinity.
            // The max reduce version.
            __device__ inline floatType warpReduce(floatType value){
                #pragma unroll
	            for (int i=1; i<32; i*=2) {
                    floatType tmp = __shfl_xor(value, i);
                    value = (tmp > value) ? tmp : value;
                    }
	            return value;
            }
              
            __device__ inline floatType blockReduce(floatType value){
	            __shared__ floatType temp[32];
                if (threadIdx.x < 32) temp[threadIdx.x] = INIT; // Just in case there are less than 32 warps.
                floatType out_partial = warpReduce(value);
                __syncthreads();
	            if (threadIdx.x % 32 == 0) temp[threadIdx.x / 32] = out_partial;
                __syncthreads();
	            if (threadIdx.x < 32) return warpReduce(temp[threadIdx.x]);
            }

            // Device code
            __global__ void ";kernel_name;"(const floatType* A, floatType* O, const int num_rows, const int num_cols)
            {
                int row = threadIdx.x;
                //const int col = blockIdx.x;
                int col_idx = blockIdx.x*num_rows; 
                floatType max = INIT; // This is the negative infinity for floats.
                int index = -1;
                while (row < num_rows)
                {
                    if (A[row+col_idx] > max) {
                        max = A[row+col_idx];
                        index = row;
                        }
                    row += blockDim.x;
                }
                
                __shared__ floatType max_index;
                if (max == blockReduce(max)) max_index = index;
                __syncthreads();
                index = max_index; // These last four lines are to make absolutely sure that only one max is selected in case there is more than one.
                row = threadIdx.x;
                while (row < num_rows)
                {
                    O[row+col_idx] = (row == index) ? max : 0.0f;
                    row += blockDim.x;
                }
            }
        }

        "|] |> String.concat ""

    member val Kernel = load_kernel_nvrtc kernel_code kernel_name
    member inline t.A
            (str: CudaStream,
                (ext_x: ^a -> CUdeviceptr, x: ^a),
                (ext_o: ^a -> CUdeviceptr, o: ^a)) = 
        GuardSizes2(x,o)
        let r,c = rc x
        max_column_launcher None (str, t.Kernel, r, c, [|ext_x x; ext_o o; r; c|])

// The gradient clipping module.
let gradclipModule = lazy DeviceUnaryCoefTransformModule("(x < -coef_x) ? -coef_x : (x > coef_x ? coef_x : x);", "GradClip") // Unique names like GradClip are necessary for load and saving to drive. Be very careful of collisions.

// coef_x = scale
// coef_y = location
// y does not get used.
let randMapModule = lazy DeviceBinaryCoefTransformModule("coef_x*(x-0.5f)+coef_y;","RandMapper")

/// Fills primal of a matrix by sampling from a random uniform distribution in <-1.0f,1.0f]
let inline fillRandomUniformMatrix (str: CudaStream) (x: ^a) (scaling_factor: float32) (location: float32) =
    cudaRandom.SetStream str.Stream

    cudaRandom.GenerateUniform(extract_primal' x)

    let x = extract_primal, x
    // 2.0f*scaling_factor ensures that it is rescaled around zero if the scaling_factor is 1.0f.
    randMapModule.Value.A(str, 2.0f*scaling_factor,x,location,x,x)

// y <- alpha * x + y
let inline saxpy 
        (str: CudaStream) 
        (alpha:float32) (ext_x, x: ^a) (ext_y, y: ^a) =
    GuardSizes2(x,y)
    cublas.Stream <- str.Stream
    cublas.Axpy(alpha,ext_x x,1,ext_y y,1)

/// General matrix-matrix addition. Inplace version.
let inline geam 
        (str: CudaStream) transa transb 
        (alpha: float32) (ext_a: ^a -> CudaDeviceVariable<float32>, A: ^a) 
        (beta: float32)  (ext_b: ^a -> CudaDeviceVariable<float32>, B: ^a) 
                         (ext_c: ^a -> CudaDeviceVariable<float32>, C: ^a) =
    let a_row = if transa = nT then rows A else cols A
    let a_col = if transa = nT then cols A else rows A
    let b_row = if transb = nT then rows B else cols B
    let b_col = if transb = nT then cols B else rows B
        
    if a_row <> b_row then failwithf "a_row <> b_row in geam! %i <> %i" a_row b_row
    if a_col <> b_col then failwithf "a_col <> b_col in geam! %i <> %i" a_col b_col

    if a_row <> rows C then failwithf "a_row <> C_num_rows in geam! %i <> %i" a_col (rows C)
    if a_col <> cols C then failwithf "a_col <> C_num_cols in geam! %i <> %i" a_col (cols C)

    let lda = if transa = nT then a_row else a_col
    let ldb = if transa = nT then b_row else b_col
    let ldc = a_row

    cublas.Stream <- str.Stream
    cublas.Geam(transa, transb, a_row, a_col, alpha, ext_a A, lda, ext_b B, ldb, beta, ext_c C, ldc)

/// General matrix-matrix multiply from cuBLAS. Inplace version
let inline gemm 
        (str: CudaStream) transa transb 
        (alpha: float32) (ext_a: _ -> CudaDeviceVariable<float32>, A)
                         (ext_b: _ -> CudaDeviceVariable<float32>, B)
        (beta: float32)  (ext_c: _ -> CudaDeviceVariable<float32>, C) =

    // -------

    // These two are meant to be called from inside gemm as they lack boundary checks.
    // I've added them to enhance gemm's vector handling capabilities for online learning
    // tasks.

    /// o <- alpha * op(A) * x + beta * o
    /// Matrix-vector multiplication. Inplace version.
    let inline gemv
            (str: CudaStream) transa transb
            (alpha:float32) (ext_a, A) 
                            (ext_x, x) 
            (beta:float32)  (ext_o, o) =
        let m = rows A
        let n = cols A
        let lda = m
        cublas.Stream <- str.Stream
        cublas.Gemv(transa, m, n, alpha, ext_a A, lda, ext_x x, 1, beta, ext_o o, 1)

    // A <- alpha * x * yT + beta * A (outer product)
    let inline ger 
            (str: CudaStream)
            (alpha: float32) (ext_x: _ -> CudaDeviceVariable<float32>, x)
                             (ext_y: _ -> CudaDeviceVariable<float32>, y)
            (beta: float32)  (ext_a: _ -> CudaDeviceVariable<float32>, a) =
        let m = max (rows x) (cols x)
        let n = max (rows y) (cols y)
        if beta <> 1.0f then geam str nT nT beta (ext_a, a) 0.0f (ext_a, a) (ext_a, a) 
        cublas.Stream <- str.Stream
        let _status = CudaBlasNativeMethods.cublasSger_v2(cublas.CublasHandle, m, n, ref alpha, (ext_x x).DevicePointer, 1, (ext_y y).DevicePointer, 1, (ext_a a).DevicePointer, m)
        if _status <> CublasStatus.Success then raise <| new CudaBlasException(_status)

    // -------

    let inline is_vector (x: ^a) = rows x = 1 || cols x = 1

    let a_col = if transa = nT then cols A else rows A
    let b_row = if transb = nT then rows B else cols B
    if a_col <> b_row then failwithf "a_col(%i) <> b_row(%i) in gemm!" a_col b_row
    let m = if transa = nT then rows A else cols A
    let n = if transb = nT then cols B else rows B
    let k = a_col
    let lda = if transa = nT then m else k
    let ldb = if transb = nT then k else n
    let ldc = m

    if m <> rows C || n <> cols C then failwithf "m(%i) <> rows C(%i) || n(%i) <> cols C(%i)" m (rows C) n (cols C)

    // If is outer product call ger
    if a_col = 1 && b_row = 1 then 
        ger str alpha (ext_a, A) (ext_b, B) beta (ext_c, C)
    // If the vector is on the right side or both are vectors call gemv normally.
    elif is_vector B then 
        gemv str transa transb alpha (ext_a,A) (ext_b,B) beta (ext_c,C)
    // If the vector is on the left side call gemv with the arguments switched and transposed
    // It does not actually transpose them, just their views. The function should work regardless.
    elif is_vector A then
        let opta = if transa = nT then T else nT
        let optb = if transb = nT then T else nT
        gemv str optb opta alpha (ext_b,B) (ext_a,A) beta (ext_c,C)
    // Just do the standard matrix multiply
    else
        cublas.Stream <- str.Stream
        cublas.Gemm(transa, transb, m, n, k, alpha, ext_a A, lda, ext_b B, ldb, beta, ext_c C, ldc)


/// Does not only check, but also sets the undefined nodes to Dead or Alive.
let inline deadness_check c a (f : unit -> unit) =
    match isDead c with
    | Undefined -> failwith "The upper node should not be undefined."
    | Dead -> // If the upper node is dead no backpropagation is done.
        match isDead a with
        | Undefined -> deadIs a Dead
        | Dead | Alive -> () // If the bottom node is Alive do not modify it to be Dead as there exists a path from elsewhere through it.
    | Alive -> 
        deadIs a Alive
        f()

type Context<'userstate> =
    {
    // Memory (mutable)
    Workspace : Workspace
    Str : CudaStream
    Mem : ObjectPool
    // State (mutable)
    mutable UserState : 'userstate
    // (unit -> unit) is the closure for the backwards pass. 
    // The ref is there to make sure the mutable value does not get dereferenced during the copy
    // otherwise the nodes won't get accumulated properly through the with_userstate call.
    Tape : (string * (unit -> unit)) list ref
    // Initialized layers (mutable)
    Nodes : ResizeArray<DM[]>
    // State (immutable)
    IsInferenceOnly : bool
    }

    static member create =
        {
        Workspace = new Workspace()
        Str = new CudaStream()
        Mem = new ObjectPool()
        UserState = ()
        Tape = ref []
        Nodes = ResizeArray()
        IsInferenceOnly = false
        }

    interface IDisposable with
        member t.Dispose() = 
            dispose t.Workspace
            dispose t.Str
            dispose t.Mem
            Seq.iter (Array.iter dispose) t.Nodes

let inline with_is_inference_only (x: Context<_>) v =
    { x with IsInferenceOnly = v }

let inline with_userstate v (x: Context<_>) =
        {
        Workspace = x.Workspace
        Str = x.Str
        Mem = x.Mem
        UserState = v
        Tape = x.Tape
        Nodes = x.Nodes
        IsInferenceOnly = x.IsInferenceOnly
        }

let inline userstate (x: Context<_>) = x.UserState
let inline add_nodes (x: Context<_>) v = x.Nodes.Add v
let inline push_tape (x: Context<_>) v = x.Tape := v :: !x.Tape
let inline tape (x: Context<_>) = x.Tape
let inline mem (x: Context<_>) = x.Mem
let inline str (x: Context<_>) = x.Str
let inline workspace (x: Context<_>) = x.Workspace
let inline nodes (x: Context<_>) = x.Nodes
let inline is_inference_only (x: Context<_>) = x.IsInferenceOnly

/// Helper for the Getd2M.
let inline getd2M is_constant (rc: int*int) (ctx: Context<_>) =
    ctx.Mem.Getd2M(is_constant,rc,ctx.IsInferenceOnly,ctx.Str)

/// Helper for the Getd4M.
let inline getd4M is_constant (nchw: int*int*int*int) (ctx: Context<_>) =
    ctx.Mem.Getd4M(is_constant,nchw,ctx.IsInferenceOnly,ctx.Str)

/// Gets a dM the same size as the first one from the object pool.
let inline getdMLike (x: ^a) (p: ObjectPool) is_constant is_inference_only str = // TODO: Like copy, refactor this one too.
    (^a: (member GetFromObjectPool: ObjectPool * bool * bool * CudaStream -> ^a) x, p, is_constant, is_inference_only, str)

/// Gets a dM the same size as the first one from the object pool. The same as the first version except it has less boilerplate.
let inline getdMLike' (x: ^a) is_constant ctx =
    (^a: (member GetFromObjectPool: ObjectPool * bool * bool * CudaStream -> ^a) x, mem ctx, is_constant, is_inference_only ctx, str ctx)

/// Copies the dM type using the object pool.
let inline copy (x: ^a) is_constant ctx =
    (^a: (member CopyUsingObjectPool: ObjectPool * bool * bool * CudaStream -> ^a) x, mem ctx, is_constant, is_inference_only ctx, str ctx)

/// Returns matrix of the same dimensions at the current one without copying the values.
let inline ghostCopy is_constant (x: ^a) =
    (^a: (member GhostCopy: bool -> ^a) x, is_constant)

/// Returns matrix of the inner dimensions at the current one without copying the values.
let inline ghostCopyBias is_constant (x: ^a) =
    (^a: (member GhostCopyBias: bool -> ^a) x, is_constant)

/// A helper for setting primals. Is mutable.
let inline setPrimal' (v,ctx) x = setPrimal x (v, str ctx); x

/// Backwards function names for debugging. Simply adding a reference is much cheaper than instantiating a string on the fly.
let matmult_backward_left_name = "matmult_backward_left"
let matmult_backward_right_name = "matmult_backward_right"
let tensor_add_right_backwards_name = "tensor_add_right_backwards"
let tensor_add_left_backwards_name = "tensor_add_left_backwards"
let activation_backward_name = "activation_backward"
let pooling_backward_name = "pooling_backward"
let convolution_backwards_filter_name = "convolution_backwards_filter"
let convolution_backwards_data_name = "convolution_backwards_data"
let batch_normalization_backward_name = "batch_normalization_backward"
let hadmult_backward_left_name = "hadmult_backward_left"
let hadmult_backward_right_name = "hadmult_backward_right"
let square_backward_name = "square_backward"
let sum_backward_name = "sum_backward"
let scale_backward_name = "scale_backward"
let sum_scalars_backwards_name = "sum_scalars_backwards"
let log_backward_name = "log_backward"
let scalar_matrix_add_backward_name = "scalar_matrix_add_backward"
let add_backward_left_name = "add_backward_left"
let add_backward_right_name = "add_backward_right"
let softmax_channel_backward_name = "softmax_channel_backward"
let clip_backward_name = "clip_backward"

///// Matrix-matrix multiply.
let inline private matmult' (prev_output : d2M option) (a:d2M, b:d2M) (ctx: Context<_>) = 
    // Note: This function is generic enough that a,b can be anything.
    // If that is necessary, the type annotation can be removed.
    let c = 
        match prev_output with
        | None ->
            let num_rows = rows a
            let num_cols = cols b
            (mem ctx).Getd2M(false,(num_rows,num_cols),(is_inference_only ctx),(str ctx))
            |> fun c ->
                gemm (str ctx) nT nT 1.0f (P' a) (P' b) 0.0f (P' c)
                c
        | Some c ->
            gemm (str ctx) nT nT 1.0f (P' a) (P' b) 1.0f (P' c)
            c

    if (is_inference_only ctx) = false then
        if hasAdjoint a then 
            let matmult_backward_left () = 
                deadness_check c a <| fun _ -> 
                    gemm (str ctx) nT T 1.0f (A' c) (P' b) 1.0f (A' a)
            push_tape ctx (matmult_backward_left_name,matmult_backward_left)

        if hasAdjoint b then 
            let matmult_backward_right () = 
                deadness_check c b <| fun _ -> 
                    gemm (str ctx) T nT 1.0f (P' a) (A' c) 1.0f (A' b)
            push_tape ctx (matmult_backward_right_name,matmult_backward_right)
    c

let inline matmult a b = matmult' None (a, b)

let inline tensor_add' add_to_left alpha (left : ^a) beta (right : ^a) (ctx: Context<_>) =
    let left_nchw = nchw left
    let right_nchw = nchw right
    let leftDesc = (mem ctx).GetTensorDescriptor left_nchw
    let rightDesc = (mem ctx).GetTensorDescriptor right_nchw

    let output = 
        if add_to_left = false then
            getdMLike left (mem ctx) false (is_inference_only ctx) (str ctx)
            |> fun output ->
                geam (str ctx) nT nT 1.0f (P' left) 0.0f (P' output) (P' output)
                output
        else 
            left

    if left_nchw <> right_nchw then
        cudnn.SetStream(str ctx)
        cudnn.AddTensor(beta,rightDesc,extract_primal' right,alpha,leftDesc,extract_primal' output) // Add right to output.
    else 
        geam (str ctx) nT nT beta (P' right) alpha (P' output) (P' output)

    if (is_inference_only ctx) = false then
        if hasAdjoint right then 
            let tensor_add_right_backwards () =
                deadness_check output right
                <| fun _ ->
                    if left_nchw = right_nchw then
                        saxpy (str ctx) beta (A' output) (A' right)
                    else
                        cudnn.SetStream (str ctx)
                        let left_nchw = nchwBiasAdd left // Ugly hack to get cuDNN to work with 2D matrices.
                        let right_nchw = nchwBiasAdd right
                        let leftDesc = (mem ctx).GetTensorDescriptor left_nchw
                        let rightDesc = (mem ctx).GetTensorDescriptor right_nchw
                        cudnn.ConvolutionBackwardBias(beta,leftDesc,extract_adjoint' output,1.0f,rightDesc,extract_adjoint' right)
            push_tape ctx (tensor_add_right_backwards_name,tensor_add_right_backwards)

        if add_to_left = false && hasAdjoint left then // No point in adding the adjoint to itself.
            let tensor_add_left_backwards () = 
                deadness_check output left 
                <| fun _ -> 
                    saxpy (str ctx) alpha (A' output) (A' left)
            push_tape ctx (tensor_add_left_backwards_name,tensor_add_left_backwards)
    output

let inline linear_layer_matmult (mm: (d2M*d2M) []) (bias: d2M option) (ctx: Context<_>) =
    mm
    |> Array.fold (fun prev_output input -> 
        matmult' prev_output input ctx |> Some
        ) None
    |>  function
        | None -> failwith "There must be one input in mm"
        | Some left ->
            match bias with
            | None -> left
            | Some right -> tensor_add' true 1.0f left 1.0f right ctx

/// The activation function. Zeroes out the target primal during the call.
let inline activation_forward mode (input : ^a) (ctx: Context<_>) =
    let input_sizes = nchw input
    let srcTensorDesc = (mem ctx).GetTensorDescriptor input_sizes

    let output = getdMLike input (mem ctx) false (is_inference_only ctx) (str ctx)

    cudnn.SetStream (str ctx)
    cudnn.ActivationForward(mode,1.0f,srcTensorDesc,extract_primal' input,0.0f,srcTensorDesc,extract_primal' output)
    if (is_inference_only ctx) = false then
        if hasAdjoint input then 
            let activation_backward () =
                deadness_check output input 
                <| fun _ -> 
                    cudnn.SetStream (str ctx)
                    cudnn.ActivationBackward(mode,1.0f,srcTensorDesc,extract_primal' output,srcTensorDesc,extract_adjoint' output,srcTensorDesc,extract_primal' input,1.0f,srcTensorDesc,extract_adjoint' input)
            push_tape ctx (activation_backward_name,activation_backward)
    output

/// The pooling function. Zeroes out the target primal during the call.
let inline pooling_forward p (input : d4M) (ctx: Context<_>) =
    let poolingDescriptor = (mem ctx).GetPoolingDescriptor p
    let input_sizes = nchw input
    let srcTensorDesc = (mem ctx).GetTensorDescriptor input_sizes
    let dest_sizes = poolingDescriptor.GetPooling2dForwardOutputDim srcTensorDesc

    let output = (mem ctx).Getd4M(false,nchw input,(is_inference_only ctx),(str ctx))

    let dstTensorDesc = (mem ctx).GetTensorDescriptor dest_sizes

    cudnn.SetStream (str ctx)
    cudnn.PoolingForward(poolingDescriptor,1.0f,srcTensorDesc,extract_primal' input,0.0f,dstTensorDesc,extract_primal' output)

    if (is_inference_only ctx) = false then
        if hasAdjoint input then 
            let pooling_backward () =
                deadness_check output input 
                <| fun _ ->
                    cudnn.SetStream (str ctx)
                    cudnn.PoolingBackward(poolingDescriptor,1.0f,srcTensorDesc,extract_primal' output, srcTensorDesc,
                                            extract_adjoint' output,dstTensorDesc,extract_primal' input,1.0f,dstTensorDesc,extract_adjoint' input)
            push_tape ctx (pooling_backward_name,pooling_backward)
    output


let inline private convolutional_forward' (prev_output: d4M option) (convPar, data : d4M, filter : d4M) (ctx: Context<_>) =
    let data_sizes = data.nchw
    let filter_sizes = filter.nchw

    let srcTensorDesc = (mem ctx).GetTensorDescriptor data_sizes
    
    let filterDesc = (mem ctx).GetFilterDescriptor filter_sizes
    let convDesc = (mem ctx).GetConvolutionDescriptor convPar

    let dims, output = 
        let dims = convDesc.GetConvolution2dForwardOutputDim(srcTensorDesc,filterDesc)
        match prev_output with
        | Some prev_output ->
            let prev_dims = prev_output.nchw
            if dims <> prev_dims then failwith "dims <> prev_dims in linear_layer_conv"
            prev_dims, prev_output
        | None ->
            dims, (mem ctx).Getd4M(false,dims,(is_inference_only ctx),(str ctx))

    let dstTensorDesc = (mem ctx).GetTensorDescriptor dims

    let algo = 
        cudnn.GetConvolutionForwardAlgorithm(
            srcTensorDesc,filterDesc,convDesc,dstTensorDesc,
            cudnnConvolutionFwdPreference.PreferFastest,SizeT 0)
    let _ = 
        let workspace = 
            cudnn.GetConvolutionForwardWorkspaceSize(srcTensorDesc, filterDesc, convDesc, dstTensorDesc, algo) 
            |> int |> (workspace ctx).ResizeIf

        let beta = 
            match prev_output with
            | None -> 0.0f
            | Some _ -> 1.0f

        cudnn.SetStream (str ctx)
        cudnn.ConvolutionForward(1.0f,srcTensorDesc,extract_primal' data,filterDesc,extract_primal' filter,convDesc,algo,workspace,beta,dstTensorDesc,extract_primal' output) // Don't zero out the previous output.

    if (is_inference_only ctx) = false then
        if hasAdjoint filter then 
            let convolution_backwards_filter () =
                deadness_check output filter 
                <| fun _ ->
                    let algo = 
                        cudnn.GetConvolutionBackwardFilterAlgorithm(
                            srcTensorDesc,dstTensorDesc,convDesc,filterDesc,
                            cudnnConvolutionBwdFilterPreference.PreferFastest,SizeT 0)

                    let workspace =
                        cudnn.GetConvolutionBackwardFilterWorkspaceSize(srcTensorDesc,dstTensorDesc,convDesc,filterDesc,algo) 
                        |> int |> (workspace ctx).ResizeIf

                    cudnn.SetStream (str ctx)
                    cudnn.ConvolutionBackwardFilter(
                        1.0f,srcTensorDesc,extract_primal' data,dstTensorDesc,extract_adjoint' output,
                        convDesc,algo,workspace,1.0f,filterDesc,extract_adjoint' filter)
            push_tape ctx (convolution_backwards_filter_name,convolution_backwards_filter)

        if hasAdjoint data then 
            let convolution_backwards_data () =
                deadness_check output data 
                <| fun _ ->
                    let algo = 
                        cudnn.GetConvolutionBackwardDataAlgorithm(
                            filterDesc,dstTensorDesc,convDesc,srcTensorDesc,
                            cudnnConvolutionBwdDataPreference.PreferFastest,SizeT 0)

                    let workspace = 
                        cudnn.GetConvolutionBackwardDataWorkspaceSize(filterDesc,dstTensorDesc,convDesc,srcTensorDesc,algo) 
                        |> int |> (workspace ctx).ResizeIf

                    cudnn.SetStream (str ctx)
                    
                    cudnn.ConvolutionBackwardData(
                        1.0f,filterDesc,extract_primal' filter,dstTensorDesc,
                        extract_adjoint' output,convDesc,algo,workspace,1.0f,srcTensorDesc,extract_adjoint' data)

            push_tape ctx (convolution_backwards_data_name,convolution_backwards_data)

    output

/// The convolutional function. Zeroes out the target primal during the call.
let inline convolution_forward convPar (data : d4M) (filter : d4M) = 
    convolutional_forward' None (convPar,data,filter)
    
let inline batch_normalization_forward 
        bnMode (bnScale : ^a) (bnBias : ^a) (bnRunningMean : ^a) 
        (bnRunningVariance : ^a) exponentialAverageFactor (input : ^a) (ctx: Context<_>) =
    // Warning: Out of all the library functions, this one modifies the running ctx during the forward pass, so is
    // dangerously mutable. I had to spend a lot of time figuring out why the gradient check is not working due to that.
        
    // BN in particular is finicky. When I set the exponential factor to low of a constant value (such as 0.001) or
    // used 1.0/factor |> min 0.001 it also starts working incorrectly for some reason.
    // It works fine when the constant is 0.01 or 0.05 on Mnist as long as the batch size is not too small.

    // During gradient checking, make sure that running mean and running variance are set to null and that
    // BatchNormalizationForwardInference is not used instead of BatchNormalizationForwardTraining otherwise it won't work.

    let input_sizes = nchw input
    let srcTensorDesc = (mem ctx).GetTensorDescriptor input_sizes

    let bnDesc = 
        (mem ctx).GetBNDescriptor (input_sizes, bnMode, srcTensorDesc)

    let _ =
        let mutable d,n,c,h,w,sn,sc,sh,sw = cudnnDataType.Double,0,0,0,0,0,0,0,0
        bnDesc.GetTensor4dDescriptor(&d,&n,&c,&h,&w,&sn,&sc,&sh,&sw)
        let bn_nchw = n,c,h,w
        if bn_nchw <> nchw bnScale then failwithf "bn_nchw(%A) <> nchw bnScale(%A)" bn_nchw (nchw bnScale)
        if bn_nchw <> nchw bnBias then failwithf "bn_nchw(%A) <> nchw bnBias(%A)" bn_nchw (nchw bnBias)
        if bn_nchw <> nchw bnRunningMean then failwithf "bn_nchw(%A) <> nchw bnRunningMean(%A)" bn_nchw (nchw bnRunningMean)
        if bn_nchw <> nchw bnRunningVariance then failwithf "bn_nchw(%A) <> nchw bnRunningVariance(%A)" bn_nchw (nchw bnRunningVariance)

    let alpha, beta = 1.0f, 0.0f
    let epsilon = 1e-5
    let bnSavedMean = getdMLike bnScale (mem ctx) true (is_inference_only ctx) (str ctx)
    let bnSavedVariance = getdMLike bnScale (mem ctx) true (is_inference_only ctx) (str ctx)
    let output = getdMLike input (mem ctx) false (is_inference_only ctx) (str ctx)

    if (is_inference_only ctx) = false then
        cudnn.SetStream (str ctx)
        cudnn.BatchNormalizationForwardTraining(
            bnMode, alpha, beta, srcTensorDesc, extract_primal' input, srcTensorDesc,
            extract_primal' output, bnDesc, extract_primal' bnScale, extract_primal' bnBias,
            exponentialAverageFactor, 
            extract_primal' bnRunningMean, 
            extract_primal' bnRunningVariance,
            epsilon, extract_primal' bnSavedMean, extract_primal' bnSavedVariance)

//            let printable_output =
//                let t = (extract_primal' output).Gather()
//                let rows = rows output
//                let cols = cols output
//                Array2D.init rows cols (fun row col -> t.[row+col*rows])
//            printfn "training output=%A" printable_output

        let batch_normalization_backward () =
            let dx_alpha, dx_beta = 1.0f, 1.0f
            let param_alpha, param_beta = 1.0f, 1.0f

            deadness_check output input 
            <| fun _ ->
                let input_adjoint = 
                    // This function is giving me so much trouble. 
                    // It is really annoying how trying to apply batch norm to the first input requires
                    // making use of the workspace.
                    if hasAdjoint input then extract_adjoint' input 
                    else (workspace ctx).ResizeIf <| size input

                cudnn.SetStream (str ctx)
                cudnn.BatchNormalizationBackward(
                    bnMode, dx_alpha, dx_beta, param_alpha, param_beta, srcTensorDesc,
                    extract_primal' input, srcTensorDesc, extract_adjoint' output, srcTensorDesc,
                    input_adjoint, bnDesc, extract_primal' bnScale, extract_adjoint' bnScale,
                    extract_adjoint' bnBias, epsilon, extract_primal' bnSavedMean, extract_primal' bnSavedVariance)

        push_tape ctx (batch_normalization_backward_name,batch_normalization_backward)
    else
            cudnn.SetStream (str ctx)
            cudnn.BatchNormalizationForwardInference(
                bnMode, alpha, beta, srcTensorDesc,extract_primal' input, srcTensorDesc,
                extract_primal' output, bnDesc, extract_primal' bnScale, extract_primal' bnBias,
                extract_primal' bnRunningMean, 
                extract_primal' bnRunningVariance, 
                epsilon)

    output
    
let inline linear_layer_conv (convs: (ConvolutionParameters*d4M*d4M) []) (bias: d4M option) (ctx: Context<_>) =
    let folder prev_output input = 
        match prev_output with
        | Some (output) ->
            convolutional_forward' (Some output) input ctx |> Some
        | None ->
            convolutional_forward' None input ctx |> Some
    
    Array.fold folder None convs
    |>  function
        | Some(left) ->
            match bias with
            | None -> left
            | Some right -> tensor_add' true 1.0f left 1.0f right ctx
        | None -> failwith "linear_layer_conv has to have at least one input"


let hadamaradMultiplicationModule = lazy new DeviceBinaryTransformModule("x*y;", "HadMult")
let hadamaradMultiplicationErrorModule = lazy new DeviceTrinaryTransformModule("x*y+z;", "HadMultError")
/// Hadamarad (elementwise) multiplication function.
let inline private hadmult' (prev_output : ^a option) (a: ^a,b: ^a) (ctx: Context<_>) =
    let c = 
        match prev_output with
        | Some c -> 
            hadamaradMultiplicationErrorModule.Value.A((str ctx), P a, P b, P c, P c)
            c
        | None -> 
            getdMLike a (mem ctx) false (is_inference_only ctx) (str ctx)
            |> fun c -> 
                hadamaradMultiplicationModule.Value.A((str ctx), P a, P b, P c)
                c

    if (is_inference_only ctx) = false then
        if hasAdjoint a then 
            let hadmult_backward_left () = 
                deadness_check c a 
                <| fun _ ->
                    hadamaradMultiplicationErrorModule.Value.A((str ctx), P b, A c, A a, A a)
            push_tape ctx (hadmult_backward_left_name,hadmult_backward_left)
        if hasAdjoint b then 
            let hadmult_backward_right () = 
                deadness_check c b 
                <| fun _ ->
                    hadamaradMultiplicationErrorModule.Value.A((str ctx), P a, A c, A b, A b)
            push_tape ctx (hadmult_backward_right_name,hadmult_backward_right)
    c

let inline hadmult (a: ^a) (b: ^a) = hadmult' None (a, b)
let inline linear_layer_hadmult (hads: (^a * ^a)[]) (ctx: Context<_>) = 
    hads 
    |> Array.fold (fun prev_output input ->
        hadmult' prev_output input ctx |> Some 
        ) None
    |>  function
        | None -> failwith "linear_layer_hadmult requires at least one input"
        | Some v -> v

let squareModule = lazy new DeviceUnaryTransformModule("x*x;","Square")
//y = error
//z = previous adjoint value
let squareErrorModule = lazy new DeviceTrinaryTransformModule("2.0f*x*y + z;","SquareError")
let inline square (a:^a) (ctx: Context<_>) =
    let c = getdMLike a (mem ctx) false (is_inference_only ctx) (str ctx)

    squareModule.Value.A((str ctx), P a, P c)

    if (is_inference_only ctx) = false then
        if hasAdjoint a then 
            let square_backward () = 
                deadness_check c a 
                <| fun _ -> 
                    squareErrorModule.Value.A((str ctx), P a, A c, A a, A a)
            push_tape ctx (square_backward_name,square_backward)
    c

/// This one is for debugging currently
let squareSumModule = lazy new DeviceUnaryMapSumModule("x*x;", "SquareSum")

let sumModule = lazy new DeviceUnaryMapSumModule("x;", "Sum")
let sumErrorModule = lazy new DeviceUnaryCoefTransformModule("coef_x + x;", "SumError")
let inline sum (a: ^a) (ctx: Context<_>) =
    let c = Df.create 0.0f

    c.P := sumModule.Value.A((str ctx), P a)

    if (is_inference_only ctx) = false then
        if hasAdjoint a then 
            let sum_backward () = 
                if !c.A <> 0.0f then 
                    deadIs a Alive
                    sumErrorModule.Value.A((str ctx), !c.A, A a, A a)
                else deadIs a Dead
            push_tape ctx (sum_backward_name, sum_backward)
    c

/// alpha * a
let inline scale (alpha: float32) (a:Df) (ctx: Context<_>) =
    let c = Df.create 0.0f
    c.P := lazy (alpha * a.P.Value.Value)
    
    if (is_inference_only ctx) = false then
        let scale_backward () = a.A := alpha * !c.A + !a.A
        push_tape ctx (scale_backward_name,scale_backward)

    c

let inline sum_scalars (a:Df seq) (ctx: Context<_>) =
    let c = Df.create 0.0f
    c.P :=
        lazy 
            let mutable t = 0.0f
            for l in a do 
                t <- t + l.P.Value.Value
            t

    if (is_inference_only ctx) = false then
        let sum_scalars_backwards () = for l in a do l.A := !c.A + !l.A
        push_tape ctx (sum_scalars_backwards_name,sum_scalars_backwards)

    c

let logModule = lazy new DeviceUnaryTransformModule("logf(x);","Log")
//y=error
//z=previous adjoint
let logErrorModule = lazy new DeviceTrinaryTransformModule("y / x + z;","LogError")
let inline log_ (a:^a) (ctx: Context<_>) =
    let c = getdMLike a (mem ctx) false (is_inference_only ctx) (str ctx)

    logModule.Value.A((str ctx), P a, P c)

    if (is_inference_only ctx) = false then
        if hasAdjoint a then
            let log_backward () = 
                deadness_check c a 
                <| fun _ -> 
                    logErrorModule.Value.A((str ctx), P a, A c, A a, A a)
            push_tape ctx (log_backward_name,log_backward)

    c

//coef_x = scalar
//coef_y = coef
let scalarMatrixAddModule = lazy new DeviceBinaryCoefTransformModule("coef_x + coef_y*x;","ScalarMatrixAdd")
/// o <- scalar + coef*a
let inline scalar_matrix_add scalar coef (a:^a) (ctx: Context<_>) =
    let c = getdMLike a (mem ctx) false (is_inference_only ctx) (str ctx)

    scalarMatrixAddModule.Value.A((str ctx), scalar, P a, coef, P a, P c)

    if (is_inference_only ctx) = false then
        if hasAdjoint a then
            let scalar_matrix_add_backward () = 
                deadness_check c a
                <| fun _ -> 
                    saxpy (str ctx) coef (A' c) (A' a)
            push_tape ctx (scalar_matrix_add_backward_name,scalar_matrix_add_backward)
    c

let inline add alpha (a: ^a) beta (b: ^a) (ctx: Context<_>) =
    let c = getdMLike a (mem ctx) false (is_inference_only ctx) (str ctx)

    geam (str ctx) nT nT alpha (P' a) beta (P' b) (P' c)

    if (is_inference_only ctx) = false then
        if hasAdjoint a then
            let add_backward_left () = 
                deadness_check c a
                <| fun _ ->
                    saxpy (str ctx) alpha (A' c) (A' a)
            push_tape ctx (add_backward_left_name, add_backward_left)
        if hasAdjoint b then
            let add_backward_right () = 
                deadness_check c b
                <| fun _ ->
                    saxpy (str ctx) beta (A' c) (A' b)
            push_tape ctx (add_backward_right_name,add_backward_right)
    c

let inline softmax_instance_forward (data : ^a) (ctx: Context<_>) =
    let data_sizes = nchw data

    let srcTensorDesc = (mem ctx).GetTensorDescriptor data_sizes
    let output = getdMLike data (mem ctx) false (is_inference_only ctx) (str ctx)

    let algo = cudnnSoftmaxAlgorithm.Accurate // Log mode forgets to re-exponentiate at the end.
    let mode = cudnnSoftmaxMode.Instance

    cudnn.SetStream (str ctx)
    cudnn.SoftmaxForward(algo, mode, 1.0f, srcTensorDesc, extract_primal' data, 0.0f, srcTensorDesc, extract_primal' output)

    if (is_inference_only ctx) = false then
        if hasAdjoint data then
            let softmax_channel_backward () =
                deadness_check output data
                <| fun _ ->
                    cudnn.SetStream (str ctx)
                    cudnn.SoftmaxBackward(algo,mode,1.0f,srcTensorDesc,extract_primal' output,srcTensorDesc,extract_adjoint' output,1.0f,srcTensorDesc,extract_adjoint' data)
            push_tape ctx (softmax_channel_backward_name,softmax_channel_backward)
    output

let inline softmax x = softmax_instance_forward x

let clipModule = lazy new DeviceTrinaryCoefTransformModule("((x < coef_x) ? coef_x : (x > coef_y ? coef_y : x))+coef_z;","Clip")
let clipErrorModule = lazy new DeviceTrinaryCoefTransformModule("y*((x < coef_x) ? 0.0f : (x > coef_y ? 0.0f : 1.0f))+z;","ClipError")
/// o <- clip(min,max,a)+scalar
/// The clip function. Can be used as Relu by setting max to positive infinity. 
/// Can be used to make linear clipped sigmoid by setting min,max,scalar to -0.5f,0.5f,0.5f.
let inline clip min max (a : ^a) scalar (ctx: Context<_>) =
    let c = getdMLike a (mem ctx) false (is_inference_only ctx) (str ctx)

    clipModule.Value.A((str ctx), min, P a, max, P a,scalar, P a, P c)

    if (is_inference_only ctx) = false then
        if hasAdjoint a then
            let clip_backward () =
                deadness_check c a
                <| fun _ -> 
                    clipErrorModule.Value.A((str ctx), min, P a, max, A c, max, A a, A a)
            push_tape ctx (clip_backward_name,clip_backward)
    c

let inline relu x (ctx: Context<_>) = 
    let t = (mem ctx).GetActivationDescriptor (cudnnActivationMode.Relu, defaultReluNanOption, 0.0)
    activation_forward t x ctx
let inline sigmoid x (ctx: Context<_>) = 
    let t = (mem ctx).GetActivationDescriptor (cudnnActivationMode.Sigmoid, defaultReluNanOption, 0.0)
    activation_forward t x ctx
let inline tanh_ x (ctx: Context<_>) = 
    let t = (mem ctx).GetActivationDescriptor (cudnnActivationMode.Tanh, defaultReluNanOption, 0.0)
    activation_forward t x ctx
let inline clipped_sigmoid x (ctx: Context<_>) = 
    let x = sigmoid x ctx
    clip 0.0001f 0.9999f x 0.0f ctx
let inline clipped_softmax x (ctx: Context<_>) = 
    let x = softmax x ctx
    clip 0.0001f 0.9999f x 0.0f ctx

/// Bind for the ctx passing functions. Is actually the reader monad rather than the state monad
/// since it is mutable.
let inline (>>=) (a: Context<_> -> ^a) (f: ^a -> Context<_> -> ^b): Context<_> -> ^b =
    fun ctx -> let v = a ctx in f v ctx

/// Kleisli arrow function for the easier ctxual function composition.
let inline (>=>) a b x = a x >>= b

// TODO: In a future version of Spiral, make the two operations actually run in parallel by
// passing in different streams and waiting on them using events. This would be a more controlable
// that what I tried in V3 of the library where I did not observe any speedups from concurrency worth noting.
/// Runs the operations in parallel and collects the results.
//let inline para2 f1 f2 (a0: ^a) (c: Context<_>) =
//    let a1 = f1 a0 c
//    let a2 = f2 a0 c
//    a1,a2

// The above function will be commented out for now. There is absolutely nothing wrong with it, but
// learning the finally tagless style made me realize that the above signature is the tagless form,
// which could be potentially dangerous since in that form, nodes will get re-evaluated multiple times
// without memoization.

// This is not a problem with costs for obvious reasons, but if I used para2 carelessly I could get in trouble.

let inline squared_error_cost (target: ^a) (activations: ^a) =
    add 1.0f target -1.0f activations 
    >>= square
    >>= sum
    >>= scale (0.5f / float32 (cols target))

type ContextBuilder() =
    member inline t.Return a = fun (c: Context<_>) -> a
    member inline t.Bind(a,f) = a >>= f
    member inline t.ReturnFrom x = x

let context = ContextBuilder()

let inline cross_entropy_cost (target: ^a) (activations: ^a) = context {
    let lt = target
    let! ll = log_ activations
    let! rt = scalar_matrix_add 1.0f -1.0f target
    let! rl = scalar_matrix_add 1.0f -1.0f activations >>= log_
    return! linear_layer_hadmult [|lt, ll; rt, rl|] 
            >>= sum
            >>= scale (-1.0f / float32 (cols target))
    }

let maxColumnActivationModule = lazy new DeviceMaxColumnActivationModule()
let accuracyModule = lazy new DeviceBinaryMapSumModule("(x*y == 0.0f) ? 0.0f : 1.0f;","Accuracy")
/// Gets the accuracy.
let inline get_accuracy (targets: ^a) (activations : ^a) (ctx: Context<_>) =
    let a =
        lazy
            let o = convertdMLikeFromWorkspace targets (workspace ctx)
            maxColumnActivationModule.Value.A((str ctx), P activations, P o)
            accuracyModule.Value.A((str ctx), P targets, P o).Value |> round |> int
    (a, cols targets)

type Cost =
    {
    accuracy: Lazy<int>
    max_accuracy: int
    cost: Df
    }

/// Makes a Cost record.
let toCost' accuracy max_accuracy cost = {accuracy=accuracy; max_accuracy=max_accuracy; cost=cost}
/// Makes a Cost record.
let toCost((accuracy,max_accuracy),cost) = {accuracy=accuracy; max_accuracy=max_accuracy; cost=cost}
/// Helper for extracting the cost as a tuple from the Cost record.
let costAsTuple (cost: Cost) = cost.accuracy,cost.max_accuracy,cost.cost

/// Squared error cost that also returns the accuracy.
let inline squared_error_cost' (targets: ^a) (activations : ^a) (ctx: Context<_>) =
    (get_accuracy targets activations ctx, squared_error_cost targets activations ctx) |> toCost

/// Cross entropy cost that also returns the accuracy.
let inline cross_entropy_cost' (targets: ^a) (activations : ^a) (ctx: Context<_>) =
    (get_accuracy targets activations ctx, cross_entropy_cost targets activations ctx) |> toCost

let find_max_index (action_values : float32[]) =
    let mutable max = Single.NegativeInfinity
    let mutable index = -1
    for i=0 to action_values.Length-1 do
        let x = action_values.[i]
        if max < x then max <- x; index <- i
    index

/// As it says on the tin. TODO: Make initializers for other activation functions.
let inline reluInitializer (ctx: Context<_>) (a: ^a) =
    let scale = (1.0f / sqrt(addDims a |> float32))
    fillRandomUniformMatrix (str ctx) a scale 0.0f
    a

/// As F# does not have passing by name, the way to get that functionality is to pass messages in the form of
/// discriminated unions. Merely passing function does not give generic enough functionality.
type Optimizer =
    | GradChecking
    | Sgd of learning_rate: float32
    | ClippedSgd of clipping_threshold: float32 * learning_rate: float32

    member inline t.Optimize (node : DM, ctx: Context<_>) =
        let inline opt (node: ^a) =
            match t with
            | GradChecking -> () // Does nothing. This is here so the adjoints do not get zeroed out.
            | Sgd(learning_rate) -> 
                saxpy (str ctx) -learning_rate (A' node) (P' node)
                extract_adjoint' node |> fun x -> x.MemsetAsync(0u,(str ctx).Stream)
            | ClippedSgd(clipping_threshold, learning_rate) -> 
                gradclipModule.Value.A((str ctx), clipping_threshold, A node,A node)
                saxpy (str ctx) -learning_rate (A' node) (P' node)
                extract_adjoint' node |> fun x -> x.MemsetAsync(0u,(str ctx).Stream)
        match node with
        | D2M x -> if x.HasAdjoint then opt x
        | D4M x -> if x.HasAdjoint then opt x

let inline createFFSublayer has_bias activation desired_hidden_size (input: d2M) (ctx: Context<_>) =
    let W = d2M.create(desired_hidden_size,input.Rows) |> reluInitializer ctx
    let b = if has_bias then d2M.create(desired_hidden_size,1) |> reluInitializer ctx |> Some else None
    let a = activation

    match b with
    | Some b -> [|W;b|]
    | None -> [|W|] 
    |> Array.map D2M
    |> add_nodes ctx

    fun (x: d2M) -> linear_layer_matmult [|W,x|] b >>= a

/// Applies the optimizer to an individual node (such as DM)
let inline optimize (optimizer: Optimizer, ctx: Context<_>) node =
    optimizer.Optimize(node,ctx)

type LayerType<'input, 'ctx, 'layer_type> =
    | Uninitialized of create_layer: ('input -> 'ctx -> 'layer_type)
    | Initialized of tag: int * node: 'layer_type

/// Returns an unique global tag.
let get_tag = 
    let mutable tags = 0
    fun () ->
        tags <- tags+1
        tags

let inline createLayer (create_layer: (^input -> ^ctx -> (^input -> ^ctx -> ^output))) =
    let mutable node = Uninitialized(create_layer)
    fun (input: ^input) (ctx: ^ctx) ->
        match node with
        | Initialized(tag,sub_layer) ->
            sub_layer input ctx
        | Uninitialized(create_layer) ->
            let sub_layer = create_layer input ctx
            node <- Initialized(get_tag(),sub_layer)
            sub_layer input ctx

let inline createStdRNNSublayer has_bias activation desired_hidden_size (input: d2M) (ctx: Context<_>) =
    let W = d2M.create(desired_hidden_size,input.Rows) |> reluInitializer ctx
    let U = d2M.create(desired_hidden_size,desired_hidden_size) |> reluInitializer ctx
    let b = if has_bias then d2M.create(desired_hidden_size,1) |> reluInitializer ctx |> Some else None

    match b with
    | Some b -> [|W;U;b|] 
    | None -> [|W;U|] 
    |> Array.map D2M
    |> add_nodes ctx

    fun (y: d2M option,x: d2M) ->
        match y with
        | None -> linear_layer_matmult [|W,x|] b >>= activation
        | Some y -> linear_layer_matmult [|W,x;U,y|] b >>= activation

// The dictionaries used to be inside the Layers directly in a previous version, but that led to some state related bugs so
// it has been changed to this. It is a matter of tunning the right level of abstraction for the state.

// Just like the Context is a level below having direct global state, the userstate is supposed to represent a level between
// the Context level and local state.

// UPDATE: At first I meant to create state for every kind of RNN, but using dynamic casts for this sort of thing is one place
// where it makes sense. Because the layers can remember the types if not the state and types can only change in depth, it makes
// sense to store all the nodes in one dict.
type RNNState<'timestep> =
    {                 // tag * timestep
    RNNDict : Dictionary<int * 'timestep, obj>
    mutable Timestep : 'timestep
    }

    // The GetRNNState function is for getting this particular record when it is nested inside others.
    // Here it is just the identity. Elsewhere it would do a deep dive.
    member t.GetRNNState = t

    static member GetRNNDM(t: RNNState<'timestep>, tag, timestep: 'timestep) =
        match t.RNNDict.TryGetValue((tag,timestep)) with
        | true, v -> Some (v :?> _) // Amazingly this works. It casts to ^output automatically in the RNN layer function.
        | false, _ -> None

    static member SetRNNDM(t: RNNState<'timestep>, tag, timestep: 'timestep, v: obj) =
        t.RNNDict.[(tag,timestep)] <- v

    static member create x =
        {
        RNNDict = Dictionary(HashIdentity.Structural)
        Timestep = x
        }

let inline getRNNState (ctx: Context<_>) = (^userstate : (member GetRNNState: RNNState<_>) ctx.UserState)
let inline timestep userstate = (^userstate : (member Timestep: ^time) userstate)
let inline set_timestep userstate v = (^userstate : (member set_Timestep: ^time -> unit) userstate, v)
let inline getRNNDM userstate tag timestep = 
    ((^userstate or ^time) : (static member GetRNNDM: ^userstate * int * ^time -> ^typ option) userstate, tag, timestep)
let inline setRNNDM userstate tag timestep v = 
    ((^userstate or ^time) : (static member SetRNNDM: ^userstate * int * ^time * obj -> unit) userstate, tag, timestep, v)

let inline create1DRNNLayer
        (create_layer: ( ^input -> Context<_> -> ((^output option * ^input) -> Context<_> -> ^output))) =
    let mutable node = Uninitialized(create_layer)
    
    fun (input: ^input) (ctx: Context<_>) ->
        let inline execute tag (sub_layer: (^output option * ^input) -> Context<_> -> ^output) =
            let state = getRNNState ctx
            let step: int = state |> timestep
            let v = getRNNDM state tag (step-1)
            let output = sub_layer (v,input) ctx
            setRNNDM state tag step output
            output
        match node with
        | Initialized (tag,sub_layer) -> execute tag sub_layer
        | Uninitialized(create_layer) ->
            let sub_layer = create_layer input ctx
            let tag = get_tag()
            node <- Initialized(tag,sub_layer)
            execute tag sub_layer