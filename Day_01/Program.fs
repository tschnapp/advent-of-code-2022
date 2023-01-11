open System
open System.IO


// Day 01

let mutable highestTotal = 0
let mutable total = 0

type Data() =
    member x.Read() =
        use stream = new StreamReader @"../../../Data_A.txt"
        while (not stream.EndOfStream) do
            let line = stream.ReadLine()
            if line = "" then
                if total > highestTotal then
                    highestTotal <- total
                total <- 0
            else
                total <- total + (line |> int)
            //printfn "%A" line

let input = Data()
input.Read()
printfn "Result 1: %i" highestTotal     // 71934



total <- 0
let mutable highestTotal1 = 0
let mutable highestTotal2 = 0
let mutable highestTotal3 = 0
let mutable totals = [0]

let GetTopThree val1 val2 val3 val4 =
    let values = [val1;val2;val3;val4]
    let retunValues = List.sortDescending values
    retunValues

type Data2() =
    member x.Read() =
        use stream = new StreamReader @"../../../Data_A.txt"
        while (not stream.EndOfStream) do
            let line = stream.ReadLine()
            if line = "" then
                let topThree = GetTopThree total highestTotal1 highestTotal2 highestTotal3
                total <- 0
                highestTotal1 <- topThree[0]
                highestTotal2 <- topThree[1]
                highestTotal3 <- topThree[2]
            else
                total <- total + (line |> int)

        highestTotal1 + highestTotal2 + highestTotal3

let input2 = Data2()
let result = input2.Read()
printfn "Result 2: %i" result   // 211447




// Shawn's Super Slick Solution
//let input = (([], 0), File.ReadAllLines(@"../../../Data_A.txt"))
//            ||> Seq.fold(fun (l, c) curr -> if String.IsNullOrWhiteSpace(curr) then ((l @ [c]), 0) else (l, c + int curr))
//            |> fun (l, c) -> l @ [c]

//input
//    |> Seq.max
//    |> printfn ("%d")

//input
//    |> Seq.sortDescending
//    |> Seq.take 3
//    |> Seq.sum
//    |> printfn ("%d")