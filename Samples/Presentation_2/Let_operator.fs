// let operator
// First Sample of immutable
let name = "Tom"
printfn "%s" name

name = "Bob"	
printfn "%s" name


// Second Sample of immutable

let items = [1..5]
List.append items [6] 
items

// let mutable — для изменяемых значений.
let mutable counter = 0

counter <- counter + 1  // Изменение значения
printfn "Counter: %d" counter

// use и use! — для управления ресурсами.
let readFile filePath =
    use file = System.IO.File.OpenText(filePath)
    file.ReadLine()

let firstLine = readFile "example.txt"
printfn "First line: %s" firstLine


let asyncComputation = async {
    let! result = Async.Sleep 1000 |> Async.StartAsTask
    printfn "Completed after 1 second"
}

Async.RunSynchronously asyncComputation

// let — для неизменяемых значений (по умолчанию).
// let mutable — для изменяемых значений.
// use и use! — для управления ресурсами.
// let rec — для рекурсивных функций. (В след лекции)
// let inline — для инлайновых функций.(В след лекции)
// let private — для локальных переменных внутри модулей.
// val mutable — для изменяемых полей в классах.(Пример в Types.fs)








