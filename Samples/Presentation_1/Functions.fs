let printMessage() = printfn "Hello world" // определение функции  
printMessage()      // вызов функции
printMessage()
printMessage()

//  Upgraded First Func

let printMessage() =                      // начало определения функции   
    printfn "Welcome to F#"
    let message = "Hello METANIT.COM"
    printfn "%s" message                 // конец определения функции
 
printMessage()    // вызов функции  


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

// 

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
let printMessage _ = printfn "Hello"
 
printMessage()
printMessage ""
printMessage 1


// Типизация вывода.
let sum x y : int64 = 
    printfn $"x = {x}"
    printfn $"y = {y}"
    let result = x + y
    result
 
let n = sum 600L 300L
printfn $"n = {n}"  // n = 900