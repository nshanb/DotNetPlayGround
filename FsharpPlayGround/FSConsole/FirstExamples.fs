module FirstExamples

let testVal = 0

let testFunc x = x

let testList = [1..10]

let testList1 = [1;2;10]

let testList2 = [for i in 0..4 -> i*i]

let testTuple = (1,2)

let emptyArray = [| |]
let testArray = [| 1; 2; 10 |]
let evenNumbers = Array.init 1001 (fun n -> n * 2)

let numbersSeq = seq { 1 .. 1000 }

let funAndArgInTuple = ((fun n -> n * n), 10)

// let firstFive s = s.[0..5]

// PIPE
let isOdd x = x%2 <> 0
let change x = x*x+1

let filterAndChange l =
    let odds = List.filter isOdd l
    let result = List.map change odds
    result

let filterAndChangeWithPipe l = l |> List.filter isOdd |> List.map change


let blackSquares = 
        [ for i in 0 .. 7 do
              for j in 0 .. 7 do 
                  if (i+j) % 2 = 1 then 
                      yield (i, j) ]

let x =1