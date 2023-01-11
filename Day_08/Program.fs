open System
open System.IO


// Day 08

let input = File.ReadAllLines(@"../../../Data_A.txt")
let mutable result = 0;


let getIsHidden (yLoc, xLoc) : int =
    let mutable isVisible = [| 1; 1; 1; 1 |]

    for x in 0 .. xLoc - 1 do                           (*right from edge*)
        if input[yLoc][x] >= input[yLoc][xLoc] then
            isVisible[0] <- 0

    for x in (xLoc + 1) .. (input[yLoc].Length - 1) do  (*right from point*)
        if input[yLoc][x] >= input[yLoc][xLoc] then
            isVisible[1] <- 0

    for y in 0 .. yLoc - 1 do                           (*down from edge*)
        if input[y][xLoc] >= input[yLoc][xLoc] then
            isVisible[2] <- 0

    for y in (yLoc + 1) .. (input.Length - 1) do        (*down from point*)
        if input[y][xLoc] >= input[yLoc][xLoc] then
            isVisible[3] <- 0

    if isVisible[0] + isVisible[1] + isVisible[2] + isVisible[3] > 0 then
        1
    else
        0
    
for y in 1 .. input.Length - 2 do
    //printfn ""
    for x in 1 .. input[y].Length - 2 do
        let val1 = getIsHidden(y, x)
        //printf "%i" val1
        result <- result + val1

printfn "\r\n%i" (result + 99 + 99 + 97 + 97)    // 1533





result <- 0

let getIsHidden2 (yLoc, xLoc) : int =
    let mutable isVisible = [| 0; 0; 0; 0 |]

    for x in xLoc - 1 .. -1 .. 0 do                           (*right from edge*)
        if (input[yLoc][x] >= input[yLoc][xLoc] || x = 0) && isVisible[0] = 0 then
            isVisible[0] <- xLoc - x

    for x in (xLoc + 1) .. (input[yLoc].Length - 1) do  (*right from point*)
        if (input[yLoc][x] >= input[yLoc][xLoc] || x = 98) && isVisible[1] = 0 then
            isVisible[1] <- x - xLoc

    for y in yLoc - 1 .. -1 .. 0 do                           (*down from edge*)
        if (input[y][xLoc] >= input[yLoc][xLoc] || y = 0) && isVisible[2] = 0 then
            isVisible[2] <- yLoc - y

    for y in (yLoc + 1) .. (input.Length - 1) do        (*down from point*)
        if (input[y][xLoc] >= input[yLoc][xLoc] || y = 98) && isVisible[3] = 0 then
            isVisible[3] <- y - yLoc

    isVisible[0] * isVisible[1] * isVisible[2] * isVisible[3]

for y in 1 .. input.Length - 2 do
    for x in 1 .. input[y].Length - 2 do
        let val1 = getIsHidden2(y, x)
        if val1 > result then
            result <- val1

printfn "\r\n%i" result    // 345744