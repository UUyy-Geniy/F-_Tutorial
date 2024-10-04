// such int types 
let a: int = 10  // целое число
let b: int64 = 100L  // 64-битное целое число
let c: byte = 255uy  // беззнаковый байт
// such float types
let pi: float = 3.14159  // 64-битное вещественное число
let e: float32 = 2.71828f  // 32-битное вещественное число
// types for boolean
let bool: bool = true  // логическое значение
// types for text
let sym: char = 'a'  // символ
let str: string = "Hello"  // строка
// types for other
let t: unit = ()  // пустое значение



// User's types
// Tuples:
let tuple = (1, "Hello", true) // Кортеж из разных типов 
let first, second, third = tuple // Декомпозиция кортежа
//Arrays:
let numbers: int[] = [| 1; 2; 3; 4; 5 |] 
let firstElement = numbers.[0] // Доступ к элементу по индексу
// List:
let list = [1; 2; 3; 4] // Список целых чисел 
let head::tail = list // Декомпозиция списка на голову и хвост

// Records:
type Person = { Name: string; Age: int }

let person1 = { Name = "Alice"; Age = 30 }
printfn "%s is %d years old." person1.Name person1.Age

// Discriminated Unions
type Shape =
    | Circle of radius: float
    | Rectangle of width: float * height: float

let shape1 = Circle(5.0)
let shape2 = Rectangle(4.0, 6.0)

let area shape =
    match shape with
    | Circle radius -> System.Math.PI * radius * radius
    | Rectangle (width, height) -> width * height
    
printfn "Area of circle: %f" (area shape1)
printfn "Area of rectangle: %f" (area shape2)

// Optional
let findElement (arr: int[]) (value: int) =
    let index = Array.tryFindIndex (fun x -> x = value) arr
    match index with
    | Some i -> printfn "Element found at index %d" i
    | None -> printfn "Element not found"

findElement [| 1; 2; 3 |] 2  // Найдет элемент
findElement [| 1; 2; 3 |] 5  // Элемента нет

// Classes
type Counter(initialValue: int) =
    val mutable count = initialValue

    member this.Increment() =
        count <- count + 1

    member this.GetCount() = count

let counter = Counter(10)
counter.Increment 1
printfn "Count: %d" (counter.GetCount())

// Way for Interfaces
type IDrawable =
    abstract member Draw: unit -> unit

type Circle(radius: float) =
    interface IDrawable with
        member this.Draw() =
            printfn "Drawing a circle with radius %f" radius

let shape: IDrawable = Circle(5.0)
shape.Draw()

// Определяем тип, представляющий функцию, которая принимает int и возвращает string
type IntToString = int -> string

// Реализация функции, которая соответствует типу IntToString
let intToStr: IntToString = fun x -> sprintf "Число: %d" x

// Используем функцию
let result = intToStr 42
printfn "%s" result





// About printfn

let name = "Tom"
let age = 37
let height = 1.68
 
printfn "name: %s  age: %d  height: %f" name age height
printfn $"name: {name}  age: {age}  height: {height}"

let user = $"User name: {name}  User age: {age}"
 
printfn $"{user}"
