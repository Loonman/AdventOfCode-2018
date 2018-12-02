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
    type stringChars = (string*seq<char>)
    let countCharOccurence (str:string) (c:char) : int32=
        str
        |> Seq.filter (fun x' -> x' = c)
        |> Seq.length

    let countCharOccurences (sc:stringChars) : seq<int32>=
        let str, c = sc
        let func2 = countCharOccurence str
        c |> Seq.map func2

    let distinctChars (str:string) = 
        Seq.toList str |> Seq.distinct

    let boolToNum b : int32= 
       match b with
       | true -> 1
       | false -> 0

    let sumBools (b:seq<bool>) : int32=
        let nums = b |> Seq.map boolToNum
        nums |> Seq.sum

    let hasNRepeatedChar (strings:seq<string>) (n:int32) : int32=
        let containsN = Seq.contains n
        let chars = strings |> Seq.map distinctChars
        Seq.zip strings chars
        |> Seq.map countCharOccurences 
        |> Seq.map containsN
        |> sumBools

    let main argv =
        let strings = "day2\\input.txt" |> readLines
        let twoPeat, threePeat = hasNRepeatedChar strings 2, hasNRepeatedChar strings 3
        printf "%i" (twoPeat * threePeat)