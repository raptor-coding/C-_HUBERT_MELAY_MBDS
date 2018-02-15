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

            List<Player> players = new List<Player>();

            List<Pit> pits1 = createPits();
            //player1 = new Player(97, "Jux", pits1);
            AI p1 = new AI(97, "JUX", pits1, null);
            player1 = p1;      
            players.Add(player1);

            List<Pit> pits2 = createPits();
            //player2 = new Player(107, "Cécile", pits2);
            player2 = new AI(107, "Cécile", pits2, player1);
            
            players.Add(player2);
            this.Players = players;
            p1.Adversary = player2;

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

        

        List<Pit> createPits()
        {
            List<Pit> pits = new List<Pit>();
            for (int j = 0; j < 6; j++)
            {
                Pit pit = new Pit(j + 1, 4);
                pits.Add(pit);
            }
            return pits;
        }

      /*  public void designateCurrentPlayer()
        {
            if (player1.Name == gameEngine.CurrentPlayer.Name)
            {
                Console.Write("yolo1");
                gameEngine.OtherPlayer = player1;
                gameEngine.CurrentPlayer = player2;
            }
            else
            {
                Console.Write("yolo2");
                gameEngine.OtherPlayer = player2;
                gameEngine.CurrentPlayer = player1;
            }
            Console.Write("yolo");
            gameEngine.playOneRound();
        }*/
    }
}
