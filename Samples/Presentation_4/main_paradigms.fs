// OOP
// Constructors samples
type Person (name, age) = 
    do printfn $"Person name: {name}  age: {age}"
    new() = Person("Undefined")
    new(name) =             // определение вторичного конструтора
        Person(name, 1) 
        then                // действия выполняемые во вторичном конструкторе
            printfn $"Для name передано значение: {name}"
            printfn $"Для age будет передано значение: 1"
 
let tom = Person("Tom", 37) // вызов первичного конструктора
let bob = Person()           // вызов первого вторичного конструктора
let sam = Person("Sam")     // вызов второго вторичного конструктора

// Properties and methods samples
type Person_with_properties (name, age) =
    let getYearOfBirth() = System.DateTime.Now.Year - age 
    member self.Name = name
    member this.Age = age
    member this.SayHello_without_property() = printfn $"Without property: Hello, I am {name} and I am {age} years old."
    member this.SayHello_with_property() = printfn $"With property: Hello, I am {this.Name} and I am {this.Age} years old."
    member _.Say text = printfn $"{name} говорит: `{text}`"
    member _.Print() = printfn $"Имя: {name}  Год рождения: { getYearOfBirth() }"


type Car(initialSpeed: int, name: string) =
    let mutable speed = initialSpeed
    member this.Name = name
    member this.Speed
        with get() = speed
        and set(value) = speed <- value
    member _.Print() = printfn $"Name: {name}  Speed: {speed} km" 

let ferrari = Car(200, "Ferrari").Print()

let tom = Person_with_properties("Tom", 37)
printfn $"Name: %s{tom.name}  Age: %d{tom.Age}" // tom.Age = tom.Name
tom.SayHello_without_property()
tom.SayHello_with_property()

// Sample of INCAPSULATION
// Класс Address представляет адрес человека
type Address(private street: string, private city: string, private zipCode: string) =
    member public this.Street
        with get() = street
        and private set(value) = street <- value

    member public this.City
        with get() = city
        and private set(value) = city <- value

    member public this.ZipCode
        with get() = zipCode
        and private set(value) = zipCode <- value

    member public this.FullAddress() = $"{this.Street}, {this.City}, {this.ZipCode}"

// Класс Person с инкапсулированным объектом Address
type Person(public name: string, public age: int, street: string, city: string, zipCode: string) =
    let address = Address(street, city, zipCode)

    member public this.Name
        with get() = name
        and set(value) = name <- value

    member public this.Age
        with get() = age
        and set(value) = age <- value

    member public this.GetAddress() = address.FullAddress()

    member public this.UpdateAddress(newStreet: string, newCity: string, newZipCode: string) =
        address.Street <- newStreet
        address.City <- newCity
        address.ZipCode <- newZipCode

    member public this.DisplayInfo() =
        printfn $"Name: {this.Name}, Age: {this.Age}, Address: {this.GetAddress()}"


// Создание объекта Person с адресом
let person = Person("Alice", 30, "123 Main St", "Wonderland", "000001")
person.DisplayInfo()  // Выведет: Name: Alice, Age: 30, Address: 123 Main St, Wonderland, 000001

// Обновление адреса через методы класса Person
person.UpdateAddress("456 New Ave", "Dreamland", "123456")
person.DisplayInfo()  // Выведет: Name: Alice, Age: 30, Address: 456 New Ave, Dreamland, 123456

// Sample of INHERITANCE
// Интерфейс для контактной информации
type IContactInfo =
    abstract member GetContactInfo : unit -> string

// Базовый класс Person
type Person(name: string, age: int) =
    member val Name = name with get, set
    member val Age = age with get, set

    // Метод для отображения информации о человеке
    member this.DisplayInfo() =
        printfn $"Name: {this.Name}, Age: {this.Age}"

// Класс Employee наследует Person и реализует IContactInfo
type Employee(name: string, age: int, position: string, email: string) =
    inherit Person(name, age)  // Наследование Person
    let email = email
    member val Position = position with get, set
    // Реализация интерфейса IContactInfo
    interface IContactInfo with
        member this.GetContactInfo() = $"Email: {email}"

    // Переопределение DisplayInfo для Employee
    member this.DisplayEmployeeInfo() =
        base.DisplayInfo()
        printfn $"Position: {this.Position}, Contact: {(this :> IContactInfo).GetContactInfo()}"

// Создание и использование Employee
let employee = Employee("Alice", 30, "Software Developer", "alice@example.com")
employee.DisplayEmployeeInfo()  // Выводит данные сотрудника вместе с контактной информацией

// Sample of POLYMORPHISM
// Универсальная функция, которая может работать с любым типом списка
let reverseList (list: 'T list) : 'T list = List.rev list

let intList = reverseList [1; 2; 3]  // Работает со списком int
let stringList = reverseList ["a"; "b"; "c"]  // Работает со списком string

// Определяем интерфейс с одним абстрактным методом
type IShape =
    abstract member Area: unit -> float

// Класс-квадрат реализует интерфейс IShape
type Square(side: float) =
    interface IShape with
        member this.Area() = side * side

// Класс-круг реализует интерфейс IShape
type Circle(radius: float) =
    interface IShape with
        member this.Area() = System.Math.PI * radius * radius

// Функция, принимающая любой IShape и вызывающая метод Area
let printArea (shape: IShape) =
    printfn $"Area: {shape.Area()}"

// Используем полиморфизм: и Square, и Circle имеют метод Area()
let square = Square(5.0) :> IShape
let circle = Circle(3.0) :> IShape

printArea square  // Выводит площадь квадрата
printArea circle  // Выводит площадь круга







//// Functional paradigm
open System

// Чистая функция для деления чисел с использованием Option для обработки деления на ноль
let safeDivide x y =
    if y = 0 then None else Some (x / y)

// Функция высшего порядка: применяет функцию к значению, если оно не равно None
let bindOption opt f =
    match opt with
    | Some value -> f value
    | None -> None

// Композиция функций для последовательных вычислений
let processValue x =
    x
    |> safeDivide 100  // делим 100 на x
    |> bindOption (fun r -> Some (r + 10))  // добавляем 10 к результату, если он есть
    |> Option.map (fun final -> final * 2)  // умножаем результат на 2, если он существует

// Тестовая функция для отображения результата
let printResult x =
    match processValue x with
    | Some result -> printfn $"Result: {result}"
    | None -> printfn "Operation failed due to invalid input"

// Примеры
printResult 4    // -> Ожидается результат: 55 (100 / 4 + 10 * 2)
printResult 0    // -> Ожидается вывод: "Operation failed due to invalid input"
printResult 10   // -> Ожидается результат: 24 (100 / 10 + 10 * 2)






/// Protocol-based paradigm
type IDriveable =
    abstract member Drive : unit -> unit

type Car(name: string) =
    interface IDriveable with
        member this.Drive() = printfn $"{name} is driving."

let car = Car("MyCar") :> IDriveable
car.Drive()  // Выведет: "MyCar is driving."



/// Event-based paradigm
open System
open System.Timers

// Тип для уведомлений, имитирующий действия пользователя
type NotificationEventArgs(message: string) =
    inherit EventArgs()
    member val Message = message with get

// Интерфейс уведомлений
type INotificationHandler =
    abstract member OnNotification: NotificationEventArgs -> unit

// Класс уведомлений, который вызывает событие
type NotificationCenter() =
    let notificationEvent = new Event<NotificationEventArgs>()
    member this.Notify msg =
        printfn $"Sending notification: {msg}"
        notificationEvent.Trigger(NotificationEventArgs(msg))
    // Подписка на событие
    member this.NotificationReceived = notificationEvent.Publish

// Реализация интерфейса INotificationHandler
type User() =
    interface INotificationHandler with
        member this.OnNotification(args: NotificationEventArgs) =
            printfn $"User received notification: {args.Message}"

// Таймер для периодических уведомлений
let createNotificationTimer (interval: int) (callback: unit -> unit) =
    let timer = new Timer(float interval)
    timer.Elapsed.Add(fun _ -> callback())
    timer.AutoReset <- true
    timer.Enabled <- true
    timer

// Пример использования NotificationCenter с периодическим вызовом уведомлений
let runNotificationSystem() =
    let notificationCenter = NotificationCenter()
    let user = User()

    // Подписка на уведомления
    notificationCenter.NotificationReceived.Add(fun args -> 
        (user :> INotificationHandler).OnNotification(args))

    // Таймер отправляет уведомление каждые 3 секунды
    let timer = createNotificationTimer 3000 (fun () -> 
        notificationCenter.Notify "Time to check your messages!")

    // Ожидание для демонстрации работы таймера
    printfn "Press Enter to stop notifications..."
    Console.ReadLine() |> ignore
    timer.Stop()

// Запуск
runNotificationSystem()
