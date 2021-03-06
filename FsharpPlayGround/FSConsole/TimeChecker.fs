﻿module TimeChecker

let TLog f = 
    printf "R\n"
    f

let TLog1 f args = 
    let stopWatch = System.Diagnostics.Stopwatch()
    stopWatch.Start()
    let res = f args
    stopWatch.Stop()
    printf "elapsed %i" stopWatch.ElapsedMilliseconds
    res

//let inline sq x = x*x
let sq x = x*x

//let val3 = 2.2 |> sq |> TLog

let val1 = 2 |> sq |> TLog
let val2 = TLog sq 2
let val3 = sq 2 |> TLog

//let val11 = 2 |> sq |> TLog1
let val12 = TLog1 sq 2


