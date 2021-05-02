// lr, lr' - learning rates
// grad_u, grad_v - gradient functions
// M - GAN objective
// u, v - discriminator & generator parameters
let minimize_approx_duality_gap lr lr' grad_u grad_v k M u v =
    let mutable u' = u
    let mutable v' = v
    for i=1 to k do
        u' <- u' - lr * grad_u M u' v
        v' <- v' + lr * grad_v M u v'

    let DG u v = M u v' - M u' v
    let u_new = u - lr' * grad_u DG u v
    let v_new = v - lr' * grad_v DG u v
    u_new, v_new