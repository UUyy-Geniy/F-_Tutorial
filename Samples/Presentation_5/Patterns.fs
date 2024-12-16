////// Функциональные паттерны.
// 1. Partial Application
// Частичное применение функции позволяет создавать новые функции, фиксируя часть параметров.
let add x y = x + y
let add5 = add 5  // Частичное применение: создаём функцию, которая прибавляет 5

// 2. Currying
// Каррирование позволяет преобразовать функцию с несколькими аргументами в серию функций с одним аргументом.
let multiply x y = x * y
let curriedMultiply = multiply 2  // Возвращает функцию, которая умножает на 2

// 3. Pattern Matching
// Сопоставление с образцом позволяет извлекать данные из типов и обрабатывать различные случаи.
let divide x y =
    match y with
    | 0 -> "Cannot divide by zero"
    | _ -> string (x / y)

// 4. Function Composition
// Композиция функций позволяет комбинировать функции таким образом, что результат одной функции передаётся в другую.
let increment x = x + 1
let double x = x * 2
let incrementAndDouble = increment >> double  // Сначала увеличиваем, потом умножаем на 2

// 5. Maybe/Option Monad
// Монада Maybe (или Option) используется для представления значений, которые могут быть отсутствующими (None).
let safeDivide x y =
    if y = 0 then None
    else Some (x / y)

// 6. Result Monad
// Монада Result используется для обработки ошибок, оборачивая результат в Success или Error.
let divideWithErrorHandling x y =
    if y = 0 then Error "Cannot divide by zero"
    else Success (x / y)

// 7. Порождающие последовательности
// Мы используем последовательности для создания цепочек значений.
let fibonacciSeq = seq {
    yield 0
    yield 1
    let rec loop a b = 
        yield a + b
        loop b (a + b)
    loop 0 1
}

//// Функциональный коллектор.

let numbers = [1; 2; 3; 4; 5]

// Сумма элементов через fold
let sum = 
    List.fold (fun acc x -> acc + x) 0 numbers

// Произведение элементов через fold
let product = 
    List.fold (fun acc x -> acc * x) 1 numbers

printfn $"Сумма: {sum}"       // Сумма: 15
printfn $"Произведение: {product}"  // Произведение: 120

// Использование reduce
let maxElement = 
    List.reduce (fun acc x -> if x > acc then x else acc) numbers

let minElement = 
    List.reduce (fun acc x -> if x < acc then x else acc) numbers

printfn $"Максимум: {maxElement}"  // Максимум: 5
printfn $"Минимум: {minElement}"   // Минимум: 1

//FoldBack
// Обратная конкатенация. 
let words = ["Hello"; "world"; "from"; "F#"]

let concatenatedString = 
    List.foldBack (fun word acc -> acc + " " + word) words ""

printfn $"Обратная конкатенация: {concatenatedString}" 

// Обратный список
let reversedList = 
    List.foldBack (fun x acc -> acc @ [x]) numbers []

printfn $"Обратный список: {reversedList}"



//// OOP
// Singleton
open System.Collections.Generic
type MessageCollector private () = 
    // Приватное поле для хранения сообщений
    static let instance = MessageCollector()
    let messages = new List<string>()  // Создание изменяемого списка

    // Метод для добавления сообщения
    member this.AddMessage(msg: string) =
        messages.Add(msg)
        printfn $"Message added: {msg}"

    // Метод для вывода всех сообщений
    member this.PrintMessages() =
        printfn "All messages:"
        messages |> Seq.iter (printfn "- %s")

    // Статический член для доступа к единственному экземпляру
    static member Instance = instance

let collector1 = MessageCollector.Instance
let collector2 = MessageCollector.Instance

collector1.AddMessage("Hello from collector1")
collector2.AddMessage("Hello from collector2")
collector1.AddMessage("Another message from collector1")

collector1.PrintMessages()
collector2.PrintMessages()

// Factory
// Определим дискриминируемое объединение для сообщений
type MessageType =
    | Info of string
    | Warning of string
    | Error of string

// Фабрика для создания сообщений
module MessageFactory =

    // Функция для создания сообщения на основе типа
    let createMessage msgType content =
        match msgType with
        | "info" -> Info(content)
        | "warning" -> Warning(content)
        | "error" -> Error(content)
        | _ -> failwith "Unsupported message type"

    // Функция для вывода сообщения
    let printMessage message =
        match message with
        | Info(text) -> printfn $"[INFO]: {text}"
        | Warning(text) -> printfn $"[WARNING]: {text}"
        | Error(text) -> printfn $"[ERROR]: {text}"

// Использование фабрики
let msg1 = MessageFactory.createMessage "info" "System started"
let msg2 = MessageFactory.createMessage "warning" "Disk space is low"
let msg3 = MessageFactory.createMessage "error" "System crash detected"

MessageFactory.printMessage msg1
MessageFactory.printMessage msg2
MessageFactory.printMessage msg3

// Decorator
// Базовый интерфейс логгера
type ILogger =
    abstract member Log: string -> unit

// Реализация простого логгера
type SimpleLogger() =
    interface ILogger with
        member _.Log(message: string) =
            printfn $"[LOG]: {message}"

// Декоратор для добавления времени к логированию
type TimeLoggerDecorator(baseLogger: ILogger) =
    interface ILogger with
        member _.Log(message: string) =
            let timestamp = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            baseLogger.Log($"[{timestamp}] {message}")

// Декоратор для добавления уровня важности
type LevelLoggerDecorator(baseLogger: ILogger, level: string) =
    interface ILogger with
        member _.Log(message: string) =
            baseLogger.Log($"[{level}] {message}")

// Использование логгеров
let simpleLogger = SimpleLogger() :> ILogger

// Добавляем декоратор с временем
let timeLogger = TimeLoggerDecorator(simpleLogger) :> ILogger

// Добавляем декоратор с уровнем важности
let levelLogger = LevelLoggerDecorator(timeLogger, "INFO") :> ILogger

// Логгируем с использованием цепочки декораторов
levelLogger.Log("System started")
levelLogger.Log("Connection established")
