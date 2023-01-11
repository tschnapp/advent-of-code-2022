open System
open System.IO


// Day 06

let input = File.ReadAllLines(@"../../../Data_A.txt")

let getMessageMarker (mmLength: int, input: string) : int =
    let mutable result = 0
    for i in 0 .. input.Length - mmLength do
        if input.[i..i + mmLength - 1] |> Seq.toList |> Seq.distinct |> Seq.length = mmLength && result = 0 then
            result <- i + mmLength
    result

printfn "%i" (getMessageMarker(4, input[0]))    // 1531
printfn "%i" (getMessageMarker(14, input[0]))   // 2518