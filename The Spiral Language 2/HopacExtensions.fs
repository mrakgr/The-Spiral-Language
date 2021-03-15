module Hopac.Infixes

let (>>**) x f = if Hopac.Promise.Now.isFulfilled x then f (Hopac.Promise.Now.get x) else Hopac.Infixes.(>>=*) x f