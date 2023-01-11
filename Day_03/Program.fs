open System
open System.IO


// Day 03

let input = File.ReadAllLines(@"../../../Data_A.txt") |> Array.toList
let mutable result = 0

let getDupe (line : string) : int =
    let mutable returnValue = 0 
    let firstPouch = line.[..((String.length line) /  2 - 1)]
    let secondPouch = line.[((String.length line) / 2)..]
    for item in firstPouch do
        if (secondPouch.Contains(item)) then
                returnValue <- int(item) - (if int(item) > 96 then 96 else 38)
    returnValue

for line in input do
    result <- result + getDupe(line)

printfn "%i" result



result <- 0

let getDupe2  (line1 : string, line2 : string, line3 : string) : int =
    let mutable returnvalue = 0 
    for c in line1 do
        if (line2.Contains(c) && line3.Contains(c) && returnvalue = 0) then
            returnvalue <- int(c) - (if int(c) > 96 then 96 else 38)
    returnvalue

for i in 1 .. input.Length do
    if i % 3 = 0 then
        result <- result + getDupe2(input[i-3], input[i-2], input[i-1])

printfn "%i" result



