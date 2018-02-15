using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_C_Sharp_Melay_Hubert
{
    class BoardGame
    {
        static GameEngine gameEngine;
        static Player player1;
        static Player player2;

        public List<Player> Players { get; set; }

        public BoardGame()
        {
        }

        public BoardGame(List<Player> player)
        {
            this.Players = player;
        }

        public String playersListToString()
        {
            String text = "";
            foreach (Player player in Players)
            {
                text += player.ToString();
            }
            return text;
        }

        public void createGame()
        {
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
            Pit pit1 = new Pit(1, new List<Seed> { seed2, seed8, seed3 });
            Pit pit2 = new Pit(2, new List<Seed> { seed3, seed4 });
            Pit pit3 = new Pit(3, new List<Seed> { seed9, seed6 });
            Pit pit4 = new Pit(4, new List<Seed> { seed7, seed1, seed13 });
            Pit pit5 = new Pit(5, new List<Seed> { seed5, seed10 });
            Pit pit6 = new Pit(6, new List<Seed> { seed11, seed12 });

            // On crée les joueurs et on leur affecte des pits
            player1 = new Player(97, "Jux", new List<Pit> { pit4, pit5, pit3 });
            player2 = new Player(99, "Cécile", new List<Pit> { pit1, pit2, pit6 });

            // Liste des joueurs
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);
            this.Players = players;

            gameEngine = new GameEngine(this, player1, player2);

            //Who start the game with a random
           /* Random rand = new Random();
            if (rand.Next(0, 2) == 0)
            {
                gameEngine = new GameEngine(this, player1, player2);
            }
            else
            {
                gameEngine = new GameEngine(this, player2, player1);
            }  */        
            gameEngine.launchGame();

        }

        public void designateCurrentPlayer()
        {
            if (player1 == gameEngine.CurrentPlayer)
            {
                player1 = gameEngine.OtherPlayer;
                player2 = gameEngine.CurrentPlayer;
            }
            else
            {
                player2 = gameEngine.OtherPlayer;
                player1 = gameEngine.CurrentPlayer;
            }
            gameEngine.playOneRound();
        }
    }
}
