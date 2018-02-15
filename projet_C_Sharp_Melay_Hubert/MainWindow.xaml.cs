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
        public MainWindow()
        {
            InitializeComponent();

            // On crée les graines
            Seed seed1 = new Seed(1);
            Seed seed2 = new Seed(2);
            Seed seed3 = new Seed(3);
            Seed seed4 = new Seed(4);
            Seed seed5 = new Seed(5);
            Seed seed6 = new Seed(6);
            Seed seed7 = new Seed(7);
            Seed seed8 = new Seed(8);
            Seed seed9 = new Seed(9);
            Seed seed10 = new Seed(10);
            Seed seed11 = new Seed(11);
            Seed seed12 = new Seed(12);
            Seed seed13 = new Seed(13);

            // On crée les pits et on leur affecte des graines
            Pit pit1 = new Pit(1, new List<Seed> { seed2, seed8, seed3 } );
            Pit pit2 = new Pit(2, new List<Seed> { seed3, seed4 } );
            Pit pit3 = new Pit(3, new List<Seed> { seed9, seed6 } );
            Pit pit4 = new Pit(4, new List<Seed> { seed7, seed1, seed13 } );
            Pit pit5 = new Pit(5, new List<Seed> { seed5, seed10 } );
            Pit pit6 = new Pit(6, new List<Seed> { seed11, seed12 } );

            // On crée les joueurs et on leur affecte des pits
            Player player1 = new Player(97, "Jux", new List<Pit> { pit4,pit5,pit3 } );
            Player player2 = new Player(99, "Cécile", new List<Pit> { pit1, pit2, pit6 });

            // Liste des joueurs
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);

            BoardGame boardGame = new BoardGame(players);
            GameEngine gameEngine = new GameEngine(boardGame);
            Console.Write(gameEngine.BoardGame.playersListToString()); // Affichage du plateau au départ

            // Move de cailloux par les joueurs
            Console.WriteLine("Egrainage de cailloux du joueur "+player1.Name);
            gameEngine.BoardGame.Players[0].moveSeed(gameEngine.BoardGame.Players[0].Pits[0], gameEngine.BoardGame.Players[0].Pits[1]);
            gameEngine.BoardGame.Players[0].moveSeed(gameEngine.BoardGame.Players[0].Pits[0], gameEngine.BoardGame.Players[0].Pits[2]);
            gameEngine.BoardGame.Players[0].moveSeed(gameEngine.BoardGame.Players[0].Pits[0], gameEngine.BoardGame.Players[1].Pits[0]); // Vers le pit de Cécile
            Console.Write(gameEngine.BoardGame.playersListToString()); // Affichage du plateau après les moves


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

    }
}
