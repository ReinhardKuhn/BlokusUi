using GameElements;
using System.Windows;

namespace BlokusUi
{
    public partial class MainWindow
    {
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Game.Draw(this.TheCanvas);
        }
    }
}