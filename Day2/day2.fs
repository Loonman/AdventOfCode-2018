// Learn more about F# at http://fsharp.org
namespace AdventOfCode

open System
open System.IO

module Day2 =
    let readLines (filePath:string) = seq {
        use sr = new StreamReader(filePath)
        while not sr.EndOfStream do
            yield sr.ReadLine()
    }

    let countCharOccurence (str:string) (c:char) : int32=
        str
        |> Seq.filter (fun x' -> x' = c)
        |> Seq.length

    let distinctChars (str:string) = seq {
        Seq.toList str |> Seq.distinct
    }

     let boolToNum b : int32= 
        match b with
        | true -> 1
        | false -> 0

    let sumBools (b:seq<bool>) : int32=
        let nums = b |> Seq.map boolToNum
        nums |> Seq.sum

    let hasNRepeatedChar (strings:seq<string>) (n:int32) : int32=
        let chars = strings |> Seq.map distinctChars
        let stringsAndChars = Seq.zip strings chars
        let counts =
            match stringsAndChars with
            | (s, c) -> countCharOccurence s c 
        let result =
            match counts with
            | c -> Seq.contains n
        result |> sumBools

    let main argv =
        let strings = "day2\\input.txt" |> readLines
        let twoPeat, threePeat = hasNRepeatedChar strings 2, hasNRepeatedChar strings 3
        printf "%i" twoPeat * threePeat