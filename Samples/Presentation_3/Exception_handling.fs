// Тип результата Result
let divide x y =
    if y = 0 then Error "Cannot divide by zero"
    else Ok (x / y)

let result = divide 10 0
match result with
| Ok value -> printfn "Result: %d" value
| Error msg -> printfn "Error: %s" msg

//  Работа с исключениями
let divide x y =
    try
        Ok (x / y)
    with
    | :? System.DivideByZeroException -> Error "Cannot divide by zero"

let result = divide 10 0
match result with
| Ok value -> printfn "Result: %d" value
| Error msg -> printfn "Error: %s" msg

// Тип Option для обработки отсутствующих значений
let tryFindNumber lst n =
    lst |> List.tryFind (fun x -> x = n)

let number = tryFindNumber [1; 2; 3] 4
match number with
| Some value -> printfn "Number found: %d" value
| None -> printfn "Number not found"

// Комбинирование типов Result и Option
let parseAndDivide strX strY =
    match System.Int32.TryParse strX, System.Int32.TryParse strY with
    | (true, x), (true, y) -> divide x y
    | _ -> Error "Invalid input"

let result = parseAndDivide "10" "0"
match result with
| Ok value -> printfn "Result: %d" value
| Error msg -> printfn "Error: %s" msg


// Использование функции bind для обработки цепочек ошибок
let bind f = function
    | Ok x -> f x
    | Error e -> Error e

let divide x y =
    if y = 0 then Error "Cannot divide by zero"
    else Ok (x / y)

let result = 
    divide 10 2
    |> bind (fun r -> divide r 0)
    |> bind (fun r -> divide r 2)

match result with
| Ok value -> printfn "Result: %d" value
| Error msg -> printfn "Error: %s" msg
