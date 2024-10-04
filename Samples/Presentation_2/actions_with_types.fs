let a = 5
let b = 7
let isEqual = (a = b) // False
let isNotEqual = (a <> b) // True
let isGreater = (a > b) // False

type Point = {X: int; Y: int}
let point1 = {X = 1; Y = 2}
let point2 = {X = 3; Y = 1}
let point3 = {X = 1; Y = 2}
let point4 = {X = 2; Y = 4}

let isEqual x y = x = y
let isGreater x y = (x > y) // False  
printfn $"isEqual: {isEqual point1 point2}" // False
printfn $"isEqual: {isEqual point1 point3}" // True
printfn $"isGreater: {isGreater point2 point1}" // False
printfn $"isGreater: {isGreater point4 point1}" // True
let isNotEqual = (point1 <> point2) // True 

let x = 5
let y = 5.0
printfn $"x: {x=y}"

