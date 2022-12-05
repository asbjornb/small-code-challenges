module Day01

open System.IO

//take a path, read the file to a string
let readInput path = File.ReadAllText path

//take a string, split it into a list of strings at each newline
let split (input:string) = input.Split("\n")

//Couple it all together to find the largest group sum
let largestGroupSum (input:string) = 
    input.Split("\n\n") //group items between each empty line
    |> Array.map split //for each group split again at newlines
    |> Array.map (Array.map int) //map each individual string to ints
    |> Array.map Array.sum
    |> Array.max

let runDay01Part1 = readInput "Input/day01.txt" |> largestGroupSum
