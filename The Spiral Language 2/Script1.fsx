open System
open System.Text
open System.Collections.Generic

let s = "123456789"
StringBuilder(s).Remove(s.IndexOf("456"),3).Insert(3,"qwe").ToString()
