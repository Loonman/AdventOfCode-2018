// Learn more about F# at http://fsharp.org
namespace AdventOfCode

open System
open System.IO
open System.Text.RegularExpressions

module Day3 =
    let readLines (filePath:string) = seq {
        use sr = new StreamReader(filePath)
        while not sr.EndOfStream do
            yield sr.ReadLine()
    }

    type claim = {
    id:int32; 
    left:int32; 
    top:int32; 
    width:int32; 
    height:int32}
    
    let (|Regex|_|) pattern input =
        let m = Regex.Match(input, pattern)
        if m.Success then Some(List.tail [ for g in m.Groups -> g.Value ])
        else None

    let claimFromString claimStr = 
        match claimStr with
        | Regex @"#(\d+) @ (\d+),(\d+): (\d+)x(\d+)" [id; left; top; width; height] ->
            {id=Int32.Parse(id); left=Int32.Parse(left); top=Int32.Parse(top); width=Int32.Parse(width); height=Int32.Parse(height);}

    let greaterThanOne num =
        match num with
        | 0 -> 0
        | 1 -> 0
        | _ -> 1
    let getFabric (claims:list<claim>) =
        let (fabric : int[,]) = Array2D.zeroCreate (1000) (1000)

        for i = 0 to (List.length claims) - 1 do
            for x = claims.[i].left to claims.[i].left + claims.[i].width - 1 do
                for y = claims.[i].top to claims.[i].top + claims.[i].height - 1 do
                    fabric.[x,y] <- fabric.[x,y] + 1;
        fabric 
    let getOverlaps (claims:list<claim>) =
        getFabric claims
        |> Seq.cast<int> 
        |> Seq.map greaterThanOne
        |> Seq.sum

    let getNonOverlappingClaim (claims:list<claim>) =
        let fabric = getFabric claims
        let mutable res = -1
        for i = 0 to (List.length claims) - 1 do
            let mutable overlap = false
            for x = claims.[i].left to claims.[i].left + claims.[i].width - 1 do
                for y = claims.[i].top to claims.[i].top + claims.[i].height - 1 do
                    overlap <- match fabric.[x,y] with
                                | 1 -> overlap
                                | _ -> true
            res <- match overlap with 
                    | false -> claims.[i].id
                    | true -> res
        res

    let main (argv) = 
        let claims = "day3\\input.txt" |> readLines |> Seq.map claimFromString |> Seq.toList
        let res = getOverlaps claims
        printfn "%d\r\n" res
        let correctSwatch = getNonOverlappingClaim claims
        printfn "%d\r\n" correctSwatch
        0



