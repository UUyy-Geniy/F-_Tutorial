// Iterators usege example

// C++ Usecase example
let list = [1; 2; 3; 4; 5]

// Получаем итератор с помощью метода GetEnumerator
let enumerator = list.GetEnumerator()

// Используем цикл while для явного обхода элементов списка
while enumerator.MoveNext() do
    let current = enumerator.Current
    printfn $"Current item: {current}"

// Пример использования явного управления итератором

open System.Collections

// Итератор для последовательности факториалов
type FactorialEnumerator() =
    let mutable n = 1
    let mutable result = 1
    interface IEnumerator with
        member this.Current = result  // Текущий факториал
        member this.MoveNext() =
            result <- result * n
            n <- n + 1
            true  // Продолжаем вычислять факториалы
        member this.Reset() =
            n <- 1
            result <- 1  // Сбрасываем последовательность

// Определяем последовательность факториалов
type FactorialSequence() =
    interface IEnumerable with
        member this.GetEnumerator() = new FactorialEnumerator() :> IEnumerator

// Пример использования итератора для факториалов
let factorialSeq = FactorialSequence()

// Используем явное управление итератором
let factorialEnumerator = (factorialSeq :> IEnumerable).GetEnumerator()
for _ in 1 .. 10 do  // Получаем первые 10 факториалов
    factorialEnumerator.MoveNext() |> ignore
    printfn $"Factorial: {factorialEnumerator.Current}"


let numbers = [1; 2; 3; 4; 5]

let res = 
    numbers
    |> List.map (fun x -> x * 2)  // Удваиваем числа 
    |> List.filter (fun x -> x > 5)  // Оставляем только числа больше 5

printfn "Result: %A" res


let names = ["Alice"; "Bob"; "Charlie"; "Dave"]

names
|> List.map (fun name -> name.ToUpper())  // Переводим все имена в верхний регистр
|> List.filter (fun name -> name.Length > 3)  // Оставляем имена, длина которых больше 3
|> List.sort  // Сортируем по алфавиту
|> List.iter (fun name -> printfn $"Name: {name}")  // Выводим результат

let list1 = [1; 2; 3]
let list2 = [4; 5; 6]

list1 @ list2  // Объединяем два списка
    |> List.map (fun x -> x * 2)  // Удваиваем все элементы
    |> List.sum  // Суммируем результат
    |> printfn "Sum of doubled numbers: %d"


let numbers = [|1; 2; 3; 4; 5|]

numbers
    |> Array.toSeq  // Преобразуем массив в последовательность
    |> Seq.map (fun x -> x * 10)  // Умножаем на 10
    |> Seq.filter (fun x -> x > 20)  // Оставляем значения больше 20
    |> Seq.toArray  // Преобразуем обратно в массив
    |> Array.iter (fun x -> printfn $"Transformed value: {x}")


let evenNumbers = Seq.initInfinite (fun x -> x * 2)  // Бесконечная последовательность чётных чисел

evenNumbers
    |> Seq.take 10  // Берём первые 10 чисел
    |> Seq.iter (fun x -> printfn $"Even number: {x}")


let items = ["apple"; "banana"; "apple"; "orange"; "banana"; "banana"]

items
    |> List.fold (fun acc item ->
        match Map.tryFind item acc with
        | Some count -> Map.add item (count + 1) acc
        | None -> Map.add item 1 acc) Map.empty  // Подсчитываем количество каждого элемента
    |> Map.iter (fun item count -> printfn $"{item}: {count}")

// Определение записи
type Product = {
    Name: string
    Price: float
    Quantity: int
}

// Коллекция товаров
let products = [
    { Name = "Laptop"; Price = 999.99; Quantity = 10 }
    { Name = "Smartphone"; Price = 499.99; Quantity = 20 }
    { Name = "Tablet"; Price = 299.99; Quantity = 15 }
]

// Итерация по списку записей и вычисление общей стоимости каждого товара
let totalCost product = product.Price * float product.Quantity

products 
    |> List.iter (fun product -> printfn $"Product: {product.Name}, Total cost: {totalCost product}")



