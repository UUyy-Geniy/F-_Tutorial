
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
let sum x y : int64 = 

    printfn $"x = {x}"
    printfn $"y = {y}"
    x + y
 
let n = sum 600L 300L
printfn $"n = {n}"  // n = 900