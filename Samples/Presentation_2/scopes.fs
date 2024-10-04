let exampleFunction() = 
    let locVar = 10
    printfn $"locVar = {locVar}"

module exampleModule = 
    let moduleVar = 10
    printfn $"moduleVar = {moduleVar}" 

let transferDonerShip value =
    let newValue = value + 1
    newValue

let result = transferDonerShip 10
printfn $"result = {result}"