module ParseAlgebra

// n + - * /

//let (|Empty|) s = 
//    match s with
//    | "" -> Empty
//    | "*" -> Empty
//    | "" -> Empty

let lex s = 
    match s with 
    | [] -> ('0', [])
    | '+'::tail -> ('+', tail)
    | '-'::tail -> ('-', tail)
    | '*'::tail -> ('*', tail)
    | '/'::tail -> ('/', tail)
    | _::tail -> ('0', tail)

    http://www.quanttec.com/fparsec/tutorial.html#parsing-json
    https://fsharpforfunandprofit.com/posts/understanding-parser-combinators-2/
    https://cockneycoder.wordpress.com/2014/04/06/reusable-decorators-in-f/
