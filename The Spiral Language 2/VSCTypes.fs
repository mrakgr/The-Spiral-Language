module VSCTypes

type VSCPos = {|line : int; character : int|}
type VSCRange = VSCPos * VSCPos
type RString = VSCRange * string

type PackageId = int
type ModuleId = int
type DirId = int
type GlobalId = { package_id : PackageId; module_id : ModuleId; tag : int }
type RGlobalId = VSCRange * GlobalId