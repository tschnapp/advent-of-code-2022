open System
open System.IO


// Day 05

let input = File.ReadAllLines(@"../../../Data_A.txt") |> Array.toList
let mutable dataSeparatorLine = 8
let stacks = [| ""; ""; ""; ""; ""; ""; ""; ""; "" |]

for i in 1 .. input.Length - 1 do
    if input[i] = " 1   2   3   4   5   6   7   8   9 " then
        dataSeparatorLine <- i

for y in dataSeparatorLine - 1 .. -1 .. 0 do
    for x in 0 .. 8 do
    if input[y].[(x * 4) + 1] <>  ' ' then 
        stacks[x] <- stacks[x] + string(input[y].[(x * 4) + 1])



// FOR PART 1
//for i in dataSeparatorLine + 2.. input.Length - 1 do
//    let line = input[i].Replace("move ", "").Replace(" from ", "-").Replace(" to ", "-")
//    let orders = line.Split("-")
//    let fromStackLength = String.length stacks[(orders[1] |> int) - 1]
//    let bitToAdd = stacks[(orders[1] |> int) - 1].[fromStackLength - (orders[0] |> int)..]
//    let bitToAddRev = bitToAdd |> Seq.toArray |> Array.rev |> System.String
//    stacks[(orders[2] |> int) - 1] <- (stacks[(orders[2] |> int) - 1] + bitToAddRev)
//    stacks[(orders[1] |> int) - 1] <- stacks[(orders[1] |> int) - 1].[..String.length stacks[(orders[1] |> int) - 1] - String.length bitToAdd - 1]



// FOR PART 2
for i in dataSeparatorLine + 2.. input.Length - 1 do
    let line = input[i].Replace("move ", "").Replace(" from ", "-").Replace(" to ", "-")
    let orders = line.Split("-")
    let fromStackLength = String.length stacks[(orders[1] |> int) - 1]
    let bitToAdd = stacks[(orders[1] |> int) - 1].[fromStackLength - (orders[0] |> int)..]
    stacks[(orders[2] |> int) - 1] <- (stacks[(orders[2] |> int) - 1] + bitToAdd)
    stacks[(orders[1] |> int) - 1] <- stacks[(orders[1] |> int) - 1].[..String.length stacks[(orders[1] |> int) - 1] - String.length bitToAdd - 1]

for x in 0 .. 8 do
    printf "%s" stacks[x].[String.length stacks[x] - 1..]