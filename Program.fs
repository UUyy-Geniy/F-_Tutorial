module MyApp
open System

let from whom =
    sprintf "from %s" whom

[<EntryPoint>]
let main argv =
    let message = from "F#" // Call the function
    printfn "Hello world %s" message
    MyFuncs.squares
    0 // return an integer exit code