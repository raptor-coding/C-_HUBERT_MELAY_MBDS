using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace projet_C_Sharp_Melay_Hubert
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static String nameUser;
        public BoardGame boardGame { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            BoardGame boardGame = new BoardGame();
            boardGame.createGame();
            this.boardGame = boardGame;
        }

        void EnterClicked(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                nameUser = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd).Text;
                Console.Write(nameUser);
                e.Handled = true;
            }
        }

        private void localGame1v1_button_Click(object sender, RoutedEventArgs e)
        {
            Game gameWindow = new Game();
            gameWindow.Show();
            gameWindow.updateGUI(this.boardGame);
        }
    }
}
