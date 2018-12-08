// Learn more about F# at http://fsharp.org
namespace AdventOfCode

open System
open System.IO
open System.Text.RegularExpressions

module Day8 =
    let readLines (filePath:string) = seq {
        use sr = new StreamReader(filePath)
        while not sr.EndOfStream do
            yield sr.ReadLine()
    }
    type Header = {metaData:int; children:int;}
    type Node = {header:Header; children:seq<Node>;}
    let buildTree (nums:seq<int>) (idx:int) = 
        0
    let main (argv) = 
        let data = "day8\\input.txt" |> readLines |> Seq.exactlyOne
        let nums = data.Split [|' '|]

        0



