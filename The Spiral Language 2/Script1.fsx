open System
open System.IO

let txt = """
123
423 abcd 5435
456
"""
Text.RegularExpressions.Regex.Replace(txt,"(.*)(abcd)(.*)","$1$3")