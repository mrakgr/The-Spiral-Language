open System
open System.Text
StringBuilder().AppendFormat

let name = "Fred"
String.Format("Name = {0}, hours = {1:hh}", name, DateTime.Now)

let multiple = String.Format("0x{0:X} {0:E} {0:N}", Int64.MaxValue)
let q = ([|1;2.2;"qwe"|] : System.Object[])

