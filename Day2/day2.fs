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

    let hasNRepeatedChar (boxes:seq<string>) (n:int32) : int32=
        let containsN = Seq.contains n
        let chars = boxes |> Seq.map distinctChars
        Seq.zip boxes chars
        |> Seq.map countCharOccurences 
        |> Seq.map containsN
        |> sumBools

    //https://rosettacode.org/wiki/Levenshtein_distance#F.23
    let levDist (strOne : string) (strTwo : string) =
        let strOne = strOne.ToCharArray ()
        let strTwo = strTwo.ToCharArray ()
     
        let (distArray : int[,]) = Array2D.zeroCreate (strOne.Length + 1) (strTwo.Length + 1)
     
        for i = 0 to strOne.Length do distArray.[i, 0] <- i
        for j = 0 to strTwo.Length do distArray.[0, j] <- j
     
        for j = 1 to strTwo.Length do
            for i = 1 to strOne.Length do
                if strOne.[i - 1] = strTwo.[j - 1] then distArray.[i, j] <- distArray.[i - 1, j - 1]
                else
                    distArray.[i, j] <- List.min (
                        [distArray.[i-1, j] + 1; 
                        distArray.[i, j-1] + 1; 
                        distArray.[i-1, j-1] + 1]
                    )
        distArray.[strOne.Length, strTwo.Length]
        
    let isEditDistance1 (boxes:seq<string>) (box:string) : bool=
        let levDist2 = levDist box
        let contains1 = Seq.contains 1
        boxes
        |> Seq.map levDist2
        |> contains1

    let dropAtIndex drop (idx, item) =
        idx <> drop

    let findCorrectBoxes (boxes:seq<string>) : string =
        let isEditDistance12 = isEditDistance1 boxes
        let correct = boxes |> Seq.map isEditDistance12

        let index1 = Seq.findIndexBack (fun x -> x ) correct
        let index2 = Seq.findIndex (fun x -> x ) correct
        let boxesList = Seq.toList boxes
        let str1 = Seq.toList boxesList.[index1]
        let str2 = Seq.toList boxesList.[index2]

        let diff = Seq.zip str1 str2 |> Seq.takeWhile (fun (a, b) -> a = b) |> Seq.length
        let dropDiff = dropAtIndex diff
        str1 
        |> List.indexed 
        |> List.filter dropDiff 
        |> List.map (fun (a, b) -> b) 
        |> List.toArray 
        |> System.String
        
    let main argv =
        let strings = "day2\\input.txt" |> readLines
        let twoPeat, threePeat = hasNRepeatedChar strings 2, hasNRepeatedChar strings 3
        printf "%i\r\n" (twoPeat * threePeat)
        let box = findCorrectBoxes strings
        printf "%s\r\n" box