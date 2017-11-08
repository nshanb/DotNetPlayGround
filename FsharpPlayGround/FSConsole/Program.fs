module myMain

open FirstExamples

let knapsackLight value1 weight1 value2 weight2 maxW =
 let l = List.filter ( fun (x , y) -> y <= maxW ) [ (value1+value2, weight1+weight2); (value1,weight1); (value2,weight2); ]
 let r = List.sortBy (fun (x , y) -> -x) l
 if r.IsEmpty then 0
 else fst r.[0]

let arithmeticExpression a b c =
    let del x y = 
        if x%y<>0 
        then c+1 
        else x/y
    let rec res l (a,b,c) = 
        printfn "k"
        match l with
        | [] -> false
        | head::_ when head a b = c -> true
        | _::tail -> res tail (a,b,c)
    try
        res [(+);(-);(*);del] (a,b,c)
    with
        | _ -> false

let arithmeticExpression1 a b c =
    [a+b=c; a-b=c; a*b=c; a = b*c] |> List.fold (||)  false

// let oper xop (x1, x2, x3) = x1 xop x2 = x3
// let r = for op in [(+),(-),(*),(/)] do oper op (a, b, c) 


let test1 x = 1

[<EntryPoint>]
let main argv = 
    let x = arithmeticExpression1 1 2 3
    printfn "%A" argv
    0 // return an integer exit code

