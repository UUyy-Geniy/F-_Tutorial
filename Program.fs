module MyApp
open System

let from whom =
    sprintf "from %s" whom

[<EntryPoint>]
let main argv =
    let message = from "F#" // Вызов функции
    printfn "Hello world %s" message
    MyFuncs.squares
    0 // возврат кода завершения
