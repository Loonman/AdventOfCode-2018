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
            (dst, src)

    let buildDependencyMap xs =
        let add map (a,b) =
            let value = 
                match Map.tryFind a map with
                | Some list -> (b :: list)
                | None      -> [b]
            Map.add a value map
        Seq.fold add Map.empty xs

    let fillMissingKeys keys map =
        let add map key =
            let value =
                match Map.tryFind key map with
                | Some list -> list
                | None -> []
            Map.add key value map
        Seq.fold add map keys

    let printMap (map:Map<string, string list>):Unit =
        for dep in map do
            printfn "%s depends on" dep.Key
            for vals in dep.Value do
                printfn "%s, " vals
            printfn "\r\n"
    let rec getCompletionOrder  (complete:List<String>) (map:Map<string, string list>):String =


        match complete.Length with
        | 26 -> complete |> List.fold (+) ""
        | _ -> //This is where the magic happens
            getCompletionOrder complete map

    // 1. Create dictionary of type {Node, Dependencies}
    // 2. Find the Node(s) for which Dependencies is empty
    // 3. Add these nodes to 'Complete' (In alphabetical order), Remove them from map
    // 4. Iterate map looking for nodes whose dependencies are contained in complete
    // 5. Add node to complete (In alphabetical order)
    // 6. Remove node from map
    // 7. Goto 4
    let main (argv) = 
        //The alphabet is our set of dictionary keys
        let alphabet = [|'A'..'Z'|] |> Array.map Char.ToString
        let fillAlphabet = fillMissingKeys alphabet
        let getCompletionOrderEnter = getCompletionOrder List.Empty
        //Get individual dependencies
        "day7\\input.txt" 
        |> readLines 
        |> Seq.map processNode 
        |> buildDependencyMap 
        |> fillAlphabet
        |> getCompletionOrderEnter
        |> printfn "%s\r\n"
        0



