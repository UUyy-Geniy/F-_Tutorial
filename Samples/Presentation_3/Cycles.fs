// Cycles
for i = 1 to 10 do
    printfn "i = %d" i

let mutable i = 1
while i <= 10 do
    printfn "i = %d" i
    i <- i + 1
    
    
// Conditional
let checkNumber x =
    if x > 0 then
        "Положительное"
    elif x < 0 then
        "Отрицательное"
    else
        "Ноль"
