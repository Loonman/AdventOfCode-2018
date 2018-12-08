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
    let rec buildTree (nums:array<int>) (idx:int) = 
        let node = {header = {children = nums.[idx]; metaData = nums.[idx + 1]}; children = Seq.empty}
        match node.header.children with
            | 0 -> 
        node
    let main (argv) = 
        let data = "day8\\input.txt" |> readLines |> Seq.exactlyOne
        let nums = data.Split [|' '|] |> Seq.map System.Int32.Parse |> Seq.toArray
        let testNums = "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2".Split [|' '|] |> Seq.map System.Int32.Parse |> Seq.toArray
        let node = buildTree testNums 0

        0



