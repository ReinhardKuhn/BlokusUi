namespace MoveGenerator

module Say =
    let hello name =
        printfn "Hello %s" name

 module Move =
    let generate piece =
        printfn "generate %s" piece

 module Board =
    let Draw(board, canvas) =
        printfn "draw canvas"