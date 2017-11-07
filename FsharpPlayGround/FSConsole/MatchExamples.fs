module MatchExamples

let example1 x = 
    match x=1 with
    | true -> "a" 
    | false -> "b"

let example1Better x = 
    match x with
    | 1 -> "a" 
    | _ -> "b"

let rec printList x = 
    match x with
    | [] -> printfn ""
    | head::tail -> printfn "%d " head; printList tail


