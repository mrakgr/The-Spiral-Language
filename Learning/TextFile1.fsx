    ///// TODO: Does not work yet. In process of debugging.
    //inl layer_norm =
    //    inl fwd o i s =
    //        inl o_primal = s.CudaTensor.to_dev_tensor o.primal
    //        inl n = (primal i).dim |> snd |> HostTensor.span |> to float
    //        s.CudaKernel.map_d1_seq_broadcast {
    //            seq = 
    //                {
    //                redo=(+)
    //                map_out=inl i sum -> i - sum / n
    //                }
    //                ,
    //                {
    //                map_in=inl v -> v*v
    //                redo=(+)
    //                map_out=inl v vv -> 
    //                    inl o = o_primal 0 .get
    //                    v / (sqrt (o*o + vv / n))
    //                }
    //            } (primal i)

    //    inl bck o r i s =
    //        inl o = Struct.map s.CudaTensor.to_dev_tensor {o without block}
    //        inl n = (primal i).dim |> snd |> HostTensor.span |> to float
    //        s.CudaKernel.map_d1_seq_broadcast' {
    //            seq = 
    //                {
    //                map_in=inl _,i -> i
    //                redo=(+)
    //                map_out=inl dr,i sum -> dr, i - sum / n
    //                }
    //                ,
    //                {
    //                map_in=inl dr,v -> v*v
    //                redo=(+)
    //                map_out=inl dr,v vv -> 
    //                    inl o = o .primal 0 .get
    //                    dr,v,sqrt (o*o + vv / n)
    //                }
    //                ,
    //                {
    //                map_in=inl dr,v,div -> dr * -v / (div * div)
    //                redo=(+)
    //                map_out=inl dr,v,div dr_div -> 
    //                    inl dv_top = dr * div
    //                    dv_top,v, dr_div * to float 0.5 / div
    //                }
    //                ,
    //                {
    //                map_in=inl _,_,div' -> div'
    //                // redo' does not do broadcasting to the zeroth thread.
    //                redo'=(+)
    //                map_out=inl dv_top,v,dr_div' sum_dr_div' -> 
    //                    if threadIdx.x = 0 then two * o.primal 0 .get * sum_dr_div' |> atomic_add (o.adjoint 0)
    //                    inl dv_div = dr_div' * (two / n) * v 
    //                    dv_top + dv_div
    //                }
    //                ,
    //                {
    //                redo=(+)
    //                map_out=inl dv dv_mean adjoint -> adjoint + dv - dv_mean / n
    //                }
    //            } (r.adjoint, i.primal) i.adjoint

    //    inl init s = s.CudaTensor.zero {elem_type=float; dim=1} |> dr s

    //    inl activation o i s =
    //        inl r = fwd o i s |> dr s
    //        //s.CudaTensor.print r.primal
    //        r, inl _ -> bck o r i s

    //    {init activation} |> stackify

    //// Works, but is not fused.
    //inl layer_norm =
    //    inl mean_fwd i s =
    //        inl n = (primal i).dim |> snd |> HostTensor.span |> to float
    //        s.CudaKernel.map_d1_seq_broadcast {
    //            seq = 
    //                {
    //                redo=(+)
    //                map_out=inl i sum -> i - sum / n
    //                }
    //            } (primal i)

    //    inl mean_bck r i s =
    //        inl n = (primal i).dim |> snd |> HostTensor.span |> to float
    //        s.CudaKernel.map_d1_seq_broadcast' {
    //            seq = 
    //                {
    //                redo=(+)
    //                map_out=inl dv dv_mean adjoint -> adjoint + dv - dv_mean / n
    //                }
    //            } (adjoint r) (adjoint i)

    //    inl norm_fwd i s = 
    //        inl n = (primal i).dim |> snd |> HostTensor.span |> to float
    //        s.CudaKernel.map_d1_seq_broadcast {
    //            seq = 
    //                {
    //                map_in=inl v -> v*v
    //                redo=(+)
    //                map_out=inl v vv -> sqrt (vv / n)
    //                }
    //            } (primal i)

    //    inl norm_bck r i s =
    //        inl n = (primal i).dim |> snd |> HostTensor.span |> to float
    //        s.CudaKernel.map_d1_seq_broadcast' {
    //            seq = 
    //                {
    //                map_in=inl dr,v -> v*v
    //                redo=(+)
    //                map_out=inl dr,v vv -> dr,v,sqrt (vv / n)
    //                }
    //                ,
    //                {
    //                map_in=inl dr,_,norm -> dr * to float 0.5 / norm
    //                redo=(+)
    //                map_out=inl _,v,_ dr_norm adjoint -> adjoint + dr_norm * (two / n) * v 
    //                }
    //            } (adjoint r, primal i) (adjoint i)

    //    inl div_fwd a b s = s.CudaKernel.map (inl a,b -> a/b) (primal a, primal b)
    //    inl div_bck r a b s =
    //        s.CudaKernel.map' (inl er,b adjoint -> adjoint + er / b) (adjoint r, primal b) (adjoint a)
    //        s.CudaKernel.map' (inl er,a,b adjoint -> adjoint - er * a / (b*b)) (adjoint r, primal a, primal b) (adjoint b)

    //    inl init s = s.CudaTensor.zero {elem_type=float; dim=1} |> dr s

    //    inl activation _ i s =
    //        inl i' = mean_fwd i s |> dr s
    //        inl r = norm_fwd i' s |> dr s
    //        inl r' = div_fwd i' r s |> dr s
    //        //s.CudaTensor.print r.primal
    //        r, inl _ -> 
    //            div_bck r' i' r s
    //            norm_bck r i' s
    //            mean_bck i' i s

    //    {init activation} |> stackify
