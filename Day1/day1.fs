// Learn more about F# at http://fsharp.org
namespace AdventOfCode

open System
open System.IO

module Day1 =
    let readLines (filePath:string) = seq {
        use sr = new StreamReader(filePath)
        while not sr.EndOfStream do
            yield sr.ReadLine()
    }


    let rec findFirstDuplicate ((frequencies:List<int32>), (index:int32), (size:int32), (found:Set<int32>), (nums:List<int32>)) =
        let finished = found.Contains frequencies.[index]
        let newFound = found.Add frequencies.[index]
        let newIndex = if index < size - 1 then index + 1 else 1
        let newFrequencies = 
            match newIndex with
            | 1 -> 
                List.scan (+) frequencies.[index] nums
            | _ ->
                frequencies
        if finished then 
            frequencies.[index] 
        else 
            findFirstDuplicate(newFrequencies, newIndex, size, newFound, nums)
    
    let main (argv) = 
        let nums = "day1\\input.txt" |> readLines |> Seq.map System.Int32.Parse
        let sum =  nums |> Seq.sum
        let frequencies = Seq.scan (+) 0 nums
        printf "%i\r\n" sum
        let freqList = Seq.toList frequencies
        let numList = Seq.toList nums
        let dup = findFirstDuplicate(freqList, 1, freqList.Length, Set.empty.Add(0), numList)
         
        printf "%i" dup



