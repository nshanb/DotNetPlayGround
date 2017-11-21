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

let tennisSet score1 score2 =
    match (score1,score2) with
    | (6,x) when x<5 -> true
    | (x,6) when x<5 -> true
    | (x,y) when x>=5 && y>=5 && (x=7 || y=7) -> true
    | _ -> false

