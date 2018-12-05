// Learn more about F# at http://fsharp.org
namespace AdventOfCode

open System
open System.IO
open System.Text.RegularExpressions

module Day5 =
    let readLines (filePath:string) = seq {
        use sr = new StreamReader(filePath)
        while not sr.EndOfStream do
            yield sr.ReadLine()
    }

    let explode (s:string) =
        [for c in s -> c]

    /// Converts a list of characters into a string.
    let implode (xs:char list) =
        let sb = System.Text.StringBuilder(xs.Length)
        xs |> List.iter (sb.Append >> ignore)
        sb.ToString()

    let oppositeCase c1:char =
        if Char.IsLower c1 then
            Char.ToUpper c1
        else
            Char.ToLower c1

    let rec processPolyString (polymer:string) (idx:int) (len:int) =
        
        if idx = len - 1 then
            polymer
        else
            let char = polymer.[idx] 
            let char2 = oppositeCase polymer.[idx + 1] 
            
            if char = char2 then
                processPolyString (polymer.Remove(idx, 2)) 0 (len - 2)
            else
                processPolyString polymer (idx + 1) len
    
    let processPolymer polymer =
        processPolyString polymer 0 polymer.Length

    let removeAllUnits (unit:char) (polymer:string) =
        let chars = explode polymer
        let res = Seq.filter (fun x -> Char.ToLower x <> unit) chars

        Seq.toList res |> implode
        
    let efficientProcessPoly polymer = 
        let (polyChain : int[]) = Array.zeroCreate(26)
        let alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray()

        for i = 0 to (alphabet.Length - 1) do
             let poly = processPolymer (removeAllUnits alphabet.[i] polymer)
             polyChain.[i] <= poly.Length
        Array.min polyChain

    let main (argv) = 
        let res1 = "day5\\input.txt" |> readLines  |> Seq.exactlyOne |> processPolymer |> String.length
        let res2 = "day5\\input.txt" |> readLines  |> Seq.exactlyOne |> efficientProcessPoly
        printfn "%d %d\r\n" res1 res2



