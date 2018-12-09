// Learn more about F# at http://fsharp.org
namespace AdventOfCode

open System
open System.IO
open System.Text.RegularExpressions

module Day6 =
    let readLines (filePath:string) = seq {
        use sr = new StreamReader(filePath)
        while not sr.EndOfStream do
            yield sr.ReadLine()
    }
    type point = {x:int; y:int}
    let inline (+) (a:point) (b:point) =
        {x = a.x + b.x; y = a.y + b.y}
        
    //A node is bounded by an edge if it's orthogonal distance to that edge is equal to or less than its edgewise distance from the nearest point on that edge
    let main (argv) = 
        let coords = "day6\\input.txt" |> readLines
        0



