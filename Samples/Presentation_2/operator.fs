  let result = 10 |> fun x -> x * 2 |> fun x -> x + 5 |> fun x -> x / 3.0 

  // Эквивалентно:
  let result = (10 * 2) + 5 |> fun x -> x / 3.0

  let doubleAndAdd5 = fun x -> x * 2 |> fun x -> x + 5
  let doubleAndAdd5Shorter = (fun x -> x * 2) >> (fun x -> x + 5) 

  // Оба варианта эквивалентны и возвращают удвоенное значение плюс 5.
  let add x y = x + y
  let add10 = fun y -> add 10 y // add10 - это функция, которая всегда добавляет 10 к своему аргументу
  let result = add10 5 // result будет равно 15

  // Эквивалентно:
  let result = add 10 5
  let greet person = 
   match person with
   | { Name = "John"; Age = 30 } -> "Привет, Джон!"
   | { Name = name; Age = age } -> Printf.sprintf "Привет, %s! Тебе %d лет." name age
   | _ -> "Привет, неизвестный!"

  let numbers = [1; 2; 3; 4; 5]
  let doubledNumbers = numbers |> List.map (fun x -> x * 2) // doubledNumbers будет равно [2; 4; 6; 8; 10]
  
  let result = 10 |> fun x -> x * 2 |> fun x -> x + 5 |> fun x -> x / 3.0
  let doubleAndAdd5 = fun x -> x * 2 >> fun x -> x + 5
  let result = doubleAndAdd5 10
  let add x y = x + y
  let add10 = fun y -> add 10 y
  let result = add10 5

  let greet person = 
   match person with
   | { Name = "John"; Age = 30 } -> "Привет, Джон!"
   | { Name = name; Age = age } -> Printf.sprintf "Привет, %s! Тебе %d лет." name age
   | _ -> "Привет, неизвестный!"

  let numbers = [1; 2; 3; 4; 5]
  let doubledNumbers = numbers |> List.map (fun x -> x * 2)
