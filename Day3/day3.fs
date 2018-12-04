// Learn more about F# at http://fsharp.org
namespace AdventOfCode

open System
open System.IO
open System.Text.RegularExpressions

module Day1 =
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
        | Regex @"#(\d+) @ (\d+),(\d+): (\d)+x(\d)+" [id; left; top; width; height] ->
            {id=Int32.Parse(id); left=Int32.Parse(left); top=Int32.Parse(top); width=Int32.Parse(width); height=Int32.Parse(height);}

    let getOverlaps claims =
        let (claimsArray : int[,]) = Array2D.zeroCreate (1000) (1000)

        0
    let main (argv) = 
        let claims = "day3\\input.txt" |> readLines |> Seq.map claimFromString


        
        0



