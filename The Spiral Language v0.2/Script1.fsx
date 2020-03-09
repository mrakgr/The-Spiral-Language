open System
open System.Reflection
open System.Globalization

let inline guard cond next = if cond then next () else None

let getBuildDate (assembly: Assembly) : DateTime option =
    let buildVersionMetadataPrefix = "+build"
    let attribute = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()

    guard (attribute <> null && attribute.InformationalVersion <> null) <| fun _ ->
    let value = attribute.InformationalVersion
    let index = value.IndexOf(buildVersionMetadataPrefix)
    guard (index > 0) <| fun _ ->
    let value = value.Substring(index + buildVersionMetadataPrefix.Length)
    let success, timestamp = DateTime.TryParseExact(value, "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None)
    guard success <| fun _ ->
    Some timestamp