module Spiral.Startup
open Argu

type PrimitiveType =
    | UInt8T | UInt16T | UInt32T | UInt64T
    | Int8T | Int16T | Int32T | Int64T
    | Float32T | Float64T
    | BoolT | StringT | CharT

type DefaultEnv = {
    port : int
    default_int : PrimitiveType
    default_uint : PrimitiveType
    default_float : PrimitiveType
    }

type CliArguments =
    | [<Mandatory;Unique>] Port of int
    | [<Unique>] Default_Int of string
    | [<Unique>] Default_Float of string

    interface IArgParserTemplate with
        member s.Usage =
            match s with
            | Port _ -> "specify a primary port."
            | Default_Int _ -> "specify the default int: i8, i16, i32, i64, u8, u16, u32, u64"
            | Default_Float _ -> "specify the default float: f32, f64"

let parse args =
    let parser = ArgumentParser.Create<CliArguments>(programName = "spiral.exe")
    let results = parser.ParseCommandLine(args)
    let int = 
        match results.GetResult(Default_Int,"i32") with
        | "i8" -> Int8T
        | "i16" -> Int16T
        | "i32" -> Int32T
        | "i64" -> Int64T
        | "u8" -> UInt8T
        | "u16" -> UInt16T
        | "u32" -> UInt32T
        | "u64" -> UInt64T
        | x -> failwith $"Invalid default int.\nGot: %s{x}\nExpected one of: i8, i16, i32, i64, u8, u16, u32, u64"

    let uint =
        match int with
        | Int8T -> UInt8T
        | Int16T -> UInt16T
        | Int32T -> UInt32T
        | Int64T -> UInt64T
        | x -> x // If the int is unsigned then make them the same type.
    {
    port = results.GetResult(Port)
    default_int = int
    default_uint = uint
    default_float = 
        match results.GetResult(Default_Float,"f64") with
        | "f32" -> Float32T
        | "f64" -> Float64T
        | x -> failwith $"Invalid default float.\nGot: %s{x}\nExpected one of: f32, f64"
    }