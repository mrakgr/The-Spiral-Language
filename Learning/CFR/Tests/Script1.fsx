#r @"..\..\..\packages\FsCheck.3.0.0-alpha4\lib\net452\FsCheck.dll"

open FsCheck

let insertKeepsOrder (x:int) xs = ordered xs ==> ordered (insert x xs)
Check.Quick insertKeepsOrder