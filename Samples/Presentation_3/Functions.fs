
let printMessage() = printfn "Hello world" // определение функции  
printMessage()      // вызов функции
printMessage()
printMessage "" // Error

//  Upgraded First Func

let printMessage() =                      // начало определения функции   
    printfn "Welcome to F#"
    let message = "Hello MSG"
    printfn "%s" message                 // конец определения функции
 
printMessage()    // вызов функции  


// IMPORTANT !!!
// Differences in defining
let printMessage = printfn "Welcome to F#"            
 
printMessage 
printMessage


// Simple Func

let sum x y = 
    let result = x + y
    printfn $"Сумма {x} и {y} равна {result}"
 
sum 10 2
sum 5 4
sum 31 4

// Автоматическая генерализация.
let printMessage message = printfn $"Message: {message}"           
 
printMessage "Hello"
printMessage 3.14
printMessage 22
printMessage true



// Типизация параметров.
let printPerson (name:string) (age:int) = 
    printfn $"Person name: {name}   age:{age}"
  
printPerson "Tom" 37
printPerson "Sam" 45

// --------------------

let printPerson (name:string, age:int) (company:string)= 
    printfn $"Person name: {name}   age:{age}  company: {company}"
  
printPerson("Tom", 37) "Microsoft"
printPerson("Sam", 45)  "Google"

// --------------------

let printPerson (name:string) age (company: string) = 
    printfn $"Person name: {name}   age:{age}  company: {company}"
  
printPerson ("Tom", "Microsoft") 37
printPerson("Sam", "Google") 45


// Ignoring params
let printMessage _ = printfn $"Hi"

printMessage()
printMessage ""
printMessage 1

// Использование списков.
let sum [a; b; c;] = a + b + c
let n = sum [1; 2; 3]
printfn $"n = {n}"


type Point = { x : float; y : float }

let (| Polar |) { x = x; y = y} =
    ( sqrt (x*x + y*y), System.Math.Atan (y/ x) )

let radius (Polar(r, _)) = r
let angle (Polar(_, theta)) = theta

let p = { x = 3.0; y = 4.0 }
let r = radius p
let theta = angle p
printfn $"r = {r}  theta = {theta}"

// Рекурсия.
let rec factorial n = if n <= 1 then 1 else n * factorial (n - 1)    
let result = factorial 5  // Результат будет 120


// Замыкания.
let add x =
    let inner y = x + y
    inner

let addFive = add 5
let result = addFive 3  // Результат будет 8

// Типизация вывода.
let sum (x: int64) (y: int64) : int64 = 
    x + y

let get_callback (y: int64) : (int64 -> int64) =
    fun x -> sum x y
 
let callback = get_callback 600L

// Применяем результатирующую функцию с аргументом 900
let n = callback 900L
printfn $"n = {n}"  // n = 1500