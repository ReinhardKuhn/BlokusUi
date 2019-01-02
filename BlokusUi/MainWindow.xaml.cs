using System.Windows;
using GameElements;

namespace BlokusUi
{
    public partial class MainWindow : Window
    {
        //public MainWindow()
        //{
        //    InitializeComponent();
        //}

        //private readonly Dictionary<Player, Color> colorMap = new Dictionary<Player, Color>();

        //private static void InitColorMap(IDictionary<Player, Color> colorMap)
        //{
        //    colorMap.Add(Player.None, Colors.White);
        //    colorMap.Add(Player.P1, Colors.Red);
        //    colorMap.Add(Player.P2, Colors.Blue);
        //    colorMap.Add(Player.P3, Colors.Green);
        //    colorMap.Add(Player.P4, Colors.Yellow);
        //}

        //private readonly Player[,] gameBoard = new Player[20, 20];

        //private static void InitGameBoard(Player[,] gameBoard)
        //{
        //    foreach (var row in Enumerable.Range(0, 19))
        //        foreach (var column in Enumerable.Range(0, 19))
        //            gameBoard[row, column] = Player.None;

        //    gameBoard[3, 5] = Player.P1;
        //    gameBoard[4, 5] = Player.P1;
        //    gameBoard[5, 5] = Player.P1;
        //    gameBoard[5, 6] = Player.P1;
        //    gameBoard[5, 7] = Player.P1;
        //}

        //private static void DrawBoard(Panel canvas, Player[,] gameBoard, IDictionary<Player, Color> colorMap)
        //{
        //    foreach (var row in Enumerable.Range(0, 19))
        //        foreach (var column in Enumerable.Range(0, 19))
        //            DrawSquare(canvas, row, column, colorMap[gameBoard[row, column]]);
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Game.Draw(this.TheCanvas);
            //InitColorMap(this.colorMap);
            //InitGameBoard(this.gameBoard);
            //MoveGenerator.Say.hello("Reinhard");
            //MoveGenerator.Move.generate("test");
            //MoveGenerator.Board.Draw(this.gameBoard, this.TheCanvas);
            //DrawBoard(this.TheCanvas, this.gameBoard, this.colorMap);
        }

        //private static void DrawSquare(Panel canvas, int row, int column, Color color)
        //{
        //    const int size = 20;
        //    var rect = new Rectangle
        //    {
        //        Stroke = new SolidColorBrush(Colors.Black),
        //        StrokeThickness = 1,
        //        Fill = new SolidColorBrush(color),
        //        Width = size + 1,
        //        Height = size + 1
        //    };

        //    Canvas.SetTop(rect, size * row);
        //    Canvas.SetLeft(rect, size * column);
        //    canvas.Children.Add(rect);
        //}
    }
}