module Spiral.Main

// Global open
open System
open System.Collections.Generic
open HashConsing
open Types

// Parser open
open FParsec

// Codegen open
open System.Text

// #Main
let spiral_peval (settings: CompilerSettings) (Module(N(module_name,_,_,_)) as module_main) = 

    ()