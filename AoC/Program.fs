open System

let do_func() = 

    let rand_list = [1;2;3]
    let rand_list2 = List.map (fun x -> x * 2) rand_list

    printfn "Result : %A" rand_list2

do_func()
