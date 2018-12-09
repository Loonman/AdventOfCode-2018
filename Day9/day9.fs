// Learn more about F# at http://fsharp.org
namespace AdventOfCode

open System
open System.IO
open System.Text.RegularExpressions
open System.Collections.Generic

module Day9 =
    let readLines (filePath:string) = seq {
        use sr = new StreamReader(filePath)
        while not sr.EndOfStream do
            yield sr.ReadLine()
    }

    let runGame (players:int) (finalMarble:int) = 
        let (scores : int[]) = Array.zeroCreate(players)
        let mutable (gameState:List<int>) = new List<int>()

        scores |> Array.toSeq |> Seq.max
        
    let main (argv) = 
        let players = 258
        let lastMarble = 71307
        
        
        0