module Day01

open System.IO

//take a path, read the file to a string
let readInput path = File.ReadAllText path

//take a string, split it into a list of strings at each newline
let split (input:string) = input.Split("\n")

let groupSums (input:string) =
    input.Split("\n\n") //group items between each empty line
    |> Array.map split //for each group split again at newlines
    |> Array.map (Array.map int) //map each individual string to ints
    |> Array.map Array.sum

//Part1: get the largest group sum
let runDay01Part1 = readInput "Input/day01.txt" |> groupSums |> Array.max

//Part2: sum the 3 largest group sums
let runDay01Part2 = readInput "Input/day01.txt" |> groupSums |> Array.sortDescending |> Array.take 3 |> Array.sum