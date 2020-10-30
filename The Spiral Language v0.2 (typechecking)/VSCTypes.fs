module VSCTypes

type VSCPos = {|line : int; character : int|}
type VSCRange = VSCPos * VSCPos
type RString = VSCRange * string