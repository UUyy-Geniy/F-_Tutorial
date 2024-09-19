module MyFuncs
open System
[<EntryPoint>]
let numbers = [1; 2; 3; 4; 5]

let square x = x * x

let squares = numbers |> List.map square

printfn "Squares: %A" squares