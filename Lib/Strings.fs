namespace AdventOfCode

open System
open System.IO
open System.Text.RegularExpressions

module StringHelpers = 
    let readLines (filePath:string) = seq {
        use sr = new StreamReader(filePath)
        while not sr.EndOfStream do
            yield sr.ReadLine()
    }

    let explode (s:string) =
        [for c in s -> c]

    /// Converts a list of characters into a string.
    let implode (xs:char list) =
        let sb = System.Text.StringBuilder(xs.Length)
        xs |> List.iter (sb.Append >> ignore)
        sb.ToString()

    let oppositeCase c1:char =
        if Char.IsLower c1 then
            Char.ToUpper c1
        else
            Char.ToLower c1
