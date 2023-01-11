open System
open System.IO


// Day 02

let input = File.ReadAllLines(@"../../../Data_A.txt")
let mutable result1 = 0

let matchResult1 (round : string) : int =
    if round = "A X" || round = "B Y" || round = "C Z" then
        3 + (if round = "A X" then 1 elif round = "B Y" then 2 elif round = "C Z" then 3 else 0)
    elif round = "C X" || round = "A Y" || round = "B Z" then
        6 + (if round = "C X" then 1 elif round = "A Y" then 2 elif round = "B Z" then 3 else 0)
    else 
        0 + (if round = "B X" then 1 elif round = "C Y" then 2 elif round = "A Z" then 3 else 0)

for line in input do
    result1 <- result1 + matchResult1(line)

printfn "Result %i" result1



let mutable result2 = 0
let matchResult2 (round : string) : int =
    if round[2] = 'X' then
        0 + (if round = "A X" then 3 elif round = "B X" then 1 elif round = "C X" then 2 else 0)
    elif round[2] = 'Y' then
        3 + (if round = "C Y" then 3 elif round = "A Y" then 1 elif round = "B Y" then 2 else 0)
    else 
        6 + (if round = "B Z" then 3 elif round = "C Z" then 1 elif round = "A Z" then 2 else 0)

for line in input do
    result2 <- result2 + matchResult2(line)

printfn "Result %i" result2
