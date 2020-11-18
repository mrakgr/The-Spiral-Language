module Spiral.Supervisor

open System
open System.IO
open System.Collections.Generic

open VSCTypes
open Spiral.SpiProj
open Spiral.ServerUtils
open Spiral.StreamServer

type SupervisorState = {
    modules : Map<string, ParserRes Hopac.Promise * ModuleStream>
    schemas : Map<string, ValidatedSchema>
    }