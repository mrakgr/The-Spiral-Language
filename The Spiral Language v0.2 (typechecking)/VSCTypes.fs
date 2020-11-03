module VSCTypes

type VSCPos = {|line : int; character : int|}
type VSCRange = VSCPos * VSCPos
type RString = VSCRange * string
type GlobalId = {| package_id : int; module_id : int; tag : int |}
type RGlobalId = VSCRange * GlobalId