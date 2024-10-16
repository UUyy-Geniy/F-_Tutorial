open System
open System.IO
open System.Text.Json

// Read from consle
printf "Введите ваше имя: "
let name = Console.ReadLine()
printfn "Привет, %s!" name


// More complex sample
printf "Введите число: "
let input = Console.ReadLine()

match Int32.TryParse(input) with
| (true, number) -> printfn "Вы ввели число: %d" number
| (false, _) -> printfn "Неверный формат числа!"


// Files saples

// Read all lines from file into one string 
let filePath = "example.txt"

let lines = File.ReadAllLines(filePath)
printfn "Содержимое файла: \n%s" content

// Read lines sequentially
File.ReadLines(filePath)
|> Seq.iter (fun line -> printfn "Строка: %s" line)

// Write to file
let filePath = "output.txt"
let content = "Привет, это новый файл!"
let newLine = "Добавляем эту строку в конец файла."

// Write to file
File.WriteAllText(filePath, content)
File.AppendAllText(filePath, "\n" + (content.Split([|' '; ','|], StringSplitOptions.RemoveEmptyEntries) |> String.concat "\n"))
File.AppendAllText(filePath, "\n" + newLine)

type Person = {
    Name: string
    Age: int
    Company: string
}

let people = [
    { Name = "Tom"; Age = 37; Company = "Microsoft" }
    { Name = "Sara"; Age = 29; Company = "Google" }
]

// Запись данных в файл JSON
let saveToJson filePath data =
    let jsonString = JsonSerializer.Serialize(data)
    File.WriteAllText(filePath, jsonString)

let readFromJson<'T> filePath =
    let jsonString = File.ReadAllText(filePath)
    JsonSerializer.Deserialize<'T>(jsonString)

// Пути к файлам
let filePath = "people.json"

// Сохраняем данные в JSON файл
saveToJson filePath people
printfn $"Данные сохранены в файл: {filePath}"

// Читаем данные из JSON файла
let loadedPeople = readFromJson<Person list> filePath
printfn $"Загруженные данные: {loadedPeople}"







