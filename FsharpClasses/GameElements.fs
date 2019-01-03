namespace GameElements

open System.Windows.Controls
open System.Drawing
open System.Windows.Media
open System.Diagnostics

type Player =
    | None
    | P1
    | P2
    | P3
    | P4

module GameUi =
    open System.Windows.Shapes

    let size = 20.0;

    let buildSquare (size, color : Color)  =
        let square = Rectangle()
        square.Height  <- size + 1.0
        square.Width   <- size + 1.0
        square.Fill    <- SolidColorBrush(color)
        square.Stroke  <- SolidColorBrush(Colors.Black)
        square.StrokeThickness <- 1.0

        square

    let addSquareToCanvas (panel:Panel, square:Rectangle,  row, column) =
       Canvas.SetLeft(square, size * row)
       Canvas.SetTop(square, size * column)
       panel.Children.Add(square)

    let DrawSquare (panel, row, column, color: Color) =
       let square = buildSquare( size, color)
       addSquareToCanvas( panel, square, row, column)
        |> ignore

module GamePiece =

    type Edge =
        | Up
        | Right
        | Down
        | Left

    type Rotation =
        | R0
        | R90
        | R180
        | R270

    type Piece =
        struct
            val Flip : bool
            val Rotation : Rotation
            val Contour : Edge list
            new (contour) = { Flip = false; Rotation = R0; Contour=contour}
        end

    let Flip(p : Piece) =
        p.Flip = not p.Flip

    let FlipEdge edge =
        match edge with
            | Up -> Up
            | Down -> Down
            | Left -> Right
            | Right -> Left

    let RotateEdge edge =
        match edge with
            | Up -> Right
            | Down -> Left
            | Left -> Up
            | Right -> Down

    let Next( r : Rotation) =
        match r with
        | R0 -> R90
        | R90 -> R180
        | R180 -> R270
        | R270 -> R90

    let Rotate(p : Piece) =
        p.Rotation = Next(p.Rotation)

    let Log( e: Edge) =
        match e with
        | Up -> "Up"
        | Down -> "Down"
        | Right -> "Right"
        | Left -> "Left"

    let Render ( p: Piece, pos: Player[,]) =
        p.Contour |> List.map(fun x -> Debug.WriteLine(Log(x)))
                  |> ignore

// 1
    let p_1_1 =
        [Edge.Up; Edge.Right; Edge.Down; Edge.Left]

// 2
    let p_2_1 =
        [Edge.Up; Edge.Up; Edge.Right; Edge.Down; Edge.Down;Edge.Left]

// 3
    let p_3_1 =
        [Edge.Up; Edge.Up; Edge.Up;
         Edge.Right;
         Edge.Down; Edge.Down; Edge.Down;
         Edge.Left]

    let p_3_2 =
        [Edge.Up; Edge.Up;
         Edge.Right;
         Edge.Down;
         Edge.Right;
         Edge.Down;
         Edge.Left;
         Edge.Left]

// 4
    // straight
    let p_4_1 =
        [Edge.Up; Edge.Up; Edge.Up; Edge.Up;
         Edge.Right;
         Edge.Down; Edge.Down;Edge.Down; Edge.Down;
         Edge.Left]

    let p_4_2 =
        [Edge.Up; Edge.Up; Edge.Up;
         Edge.Right;
         Edge.Down;
         Edge.Right;
         Edge.Down;
         Edge.Left;
         Edge.Down;
         Edge.Left]

    let p_4_3 =
        [Edge.Up; Edge.Up;
         Edge.Right;
         Edge.Down;
         Edge.Right;
         Edge.Down;
         Edge.Left;Edge.Left]

    let p_4_4 =
        [Edge.Up; Edge.Up;
         Edge.Right;
         Edge.Down;
         Edge.Right;
         Edge.Down;
         Edge.Left;Edge.Left]

    let p_4_5 =
        [Edge.Up; Edge.Up;
         Edge.Right;
         Edge.Down;
         Edge.Right;
         Edge.Down;
         Edge.Left;Edge.Left]

    let p_4_6 =
        [Edge.Up; Edge.Up;
         Edge.Right;
         Edge.Down;
         Edge.Right;
         Edge.Down;
         Edge.Left;
         Edge.Left]

// 5
    let p_5_1 =
        [Edge.Up; Edge.Up; Edge.Up; Edge.Up; Edge.Up;
         Edge.Right;
         Edge.Down; Edge.Down; Edge.Down; Edge.Down;Edge.Down;
         Edge.Left]

    let p_5_2 =
        [Edge.Up; Edge.Up; Edge.Up; Edge.Up;
         Edge.Right;
         Edge.Down; Edge.Down; Edge.Down; Edge.Down;Edge.Down;
         Edge.Left]

    let p_5_3 =
        [Edge.Up; Edge.Up; Edge.Up; Edge.Up; Edge.Up;
         Edge.Right;
         Edge.Down; Edge.Down; Edge.Down; Edge.Down;Edge.Down;
         Edge.Left]

    let p_5_4 =
        [Edge.Up; Edge.Up; Edge.Up; Edge.Up; Edge.Up;
         Edge.Right;
         Edge.Down; Edge.Down; Edge.Down; Edge.Down;Edge.Down;
         Edge.Left]

    let p_5_5 =
        [Edge.Up; Edge.Up; Edge.Up; Edge.Up; Edge.Up;
         Edge.Right;
         Edge.Down; Edge.Down; Edge.Down; Edge.Down;Edge.Down;
         Edge.Left]

    let p_5_6 =
        [Edge.Up; Edge.Up; Edge.Up; Edge.Up; Edge.Up;
         Edge.Right;
         Edge.Down; Edge.Down; Edge.Down; Edge.Down;Edge.Down;
         Edge.Left]

    let p_5_7 =
        [Edge.Up; Edge.Up; Edge.Up; Edge.Up; Edge.Up;
         Edge.Right;
         Edge.Down; Edge.Down; Edge.Down; Edge.Down;Edge.Down;
         Edge.Left]

    let p_5_8 =
        [Edge.Up; Edge.Up; Edge.Up; Edge.Up; Edge.Up;
         Edge.Right;
         Edge.Down; Edge.Down; Edge.Down; Edge.Down; Edge.Down;
         Edge.Left]

    let p_5_9 =
        [Edge.Up; Edge.Up; Edge.Up; Edge.Up; Edge.Up;
         Edge.Right;
         Edge.Down; Edge.Down; Edge.Down; Edge.Down;Edge.Down;
         Edge.Left]

    let p_5_10=
        [Edge.Up; Edge.Up; Edge.Up; Edge.Up; Edge.Up;
         Edge.Right;
         Edge.Down; Edge.Down; Edge.Down; Edge.Down;Edge.Down;
         Edge.Left]

module GamePosition =

    let Init (gamePosition:Player[,]) =
        GamePiece.Render(new GamePiece.Piece(GamePiece.p_3_2), gamePosition)
        for row = 0 to 19 do
            for col = 0 to 19 do
               gamePosition.[row,col] <- Player.None

    let Display ( panel: Panel, gamePosition: Player[,], colorMap: Map<Player,Color>) =
        for row = 0 to 19 do
            for col = 0 to 19 do
               GameUi.DrawSquare(panel, float row , float col, colorMap.[gamePosition.[row, col]]);
module Game =

    let ColorMap =
        Map.empty
           .Add(Player.None, Colors.White)
           .Add(Player.P1, Colors.Red)
           .Add(Player.P2, Colors.Blue)
           .Add(Player.P3, Colors.Green)

    let Draw (panel: Panel) =
        let position = Array2D.create<Player>  20 20 Player.None

        GamePosition.Init position

        GamePosition.Display( panel, position, ColorMap)