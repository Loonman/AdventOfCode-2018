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
    type Node = (string*string)

    let (|Regex|_|) pattern input =
        let m = Regex.Match(input, pattern)
        if m.Success then Some(List.tail [ for g in m.Groups -> g.Value ])
        else None

    let processNode nodeDecl = 
        match nodeDecl with
        | Regex @"Step (\w) must be finished before step (\w) can begin." [src; dst;] ->
            (src, dst)

    // let getNextNode (map:Map<string, seq<string>>) (complete:seq<string>) =
    //     for node, deps in map do
    //         for dep in deps do

    // 1. Create dictionary of type {Node, Dependencies}
    // 2. Find the Node(s) for which Dependencies is empty
    // 3. Add these nodes to 'Complete' (In alphabetical order)
    // 4. Iterate map looking for nodes whose dependencies are contained in complete
    // 5. Add node to complete (In alphabetical order)
    // 6. Goto 4
    let main (argv) = 
        let nodes = "day7\\input.txt" |> readLines |> Seq.map processNode
        0



