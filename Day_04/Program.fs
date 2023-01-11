open System
open System.IO


// Day 04

let input = File.ReadAllLines(@"../../../Data_A.txt") |> Array.toList
let mutable result = 0

let overlap (line : string) : bool =
    let d = line.Split(',', '-')
    let firstElfRange = [ d[0] |> int; d[1] |> int ]
    let secondElfRange =  [ d[2] |> int; d[3] |> int ]
    if (firstElfRange[0] >= secondElfRange[0] && firstElfRange[1] <= secondElfRange[1]) || 
        (firstElfRange[0] <= secondElfRange[0] && firstElfRange[1] >= secondElfRange[1]) then
        true
    else
        false

for line in input do
    if overlap(line) then result <- result + 1
    else result <- result

printfn "%i" result



result <- 0

let overlap2 (line : string) : bool =
    let d = line.Split(',', '-')
    let firstElfRange = [ d[0] |> int; d[1] |> int ]
    let secondElfRange =  [ d[2] |> int; d[3] |> int ] 
    if (firstElfRange[0] >= secondElfRange[0] && firstElfRange[0] <= secondElfRange[1]) || 
        (firstElfRange[1] >= secondElfRange[0] && firstElfRange[1] <= secondElfRange[1]) || 
        (secondElfRange[0] >= firstElfRange[0] && secondElfRange[0] <= firstElfRange[1]) || 
        (secondElfRange[1] >= firstElfRange[0] && secondElfRange[1] <= firstElfRange[1])then
        true
    else
        false

for line in input do
    if overlap2(line) then result <- result + 1
    else result <- result

printfn "%i" result

