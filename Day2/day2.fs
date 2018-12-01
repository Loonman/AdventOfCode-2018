// Learn more about F# at http://fsharp.org
namespace AdventOfCode

open System
open System.IO

module Day1 =
    let readLines (filePath:string) = seq {
        use sr = new StreamReader(filePath)
        while not sr.EndOfStream do
            yield sr.ReadLine()
    }

    let main (argv) = 
        let nums = "day2\\input.txt" |> readLines




