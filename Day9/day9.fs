// Learn more about F# at http://fsharp.org
namespace AdventOfCode

open System
open System.IO
open System.Text.RegularExpressions

module Day9 =
    let readLines (filePath:string) = seq {
        use sr = new StreamReader(filePath)
        while not sr.EndOfStream do
            yield sr.ReadLine()
    }

        node
    let main (argv) = 
        let players = 258
        let lastMarble = 71307
        let (scores : int[]) = Array.zeroCreate(players)
        
        0



