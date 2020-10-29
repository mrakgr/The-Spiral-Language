module VSCTypes

type Pos = {|line : int; character : int|}
type Range = Pos * Pos
type RString = Range * string