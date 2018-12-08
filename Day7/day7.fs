// Learn more about F# at http://fsharp.org
namespace AdventOfCode

open System
open System.IO
open System.Text.RegularExpressions

module Day7 =
    let readLines (filePath:string) = seq {
        use sr = new StreamReader(filePath)
        while not sr.EndOfStream do
            yield sr.ReadLine()
    }
        
    let main (argv) = 
        let coords = "day7\\input.txt" |> readLines
        0



