using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_C_Sharp_Melay_Hubert
{
    class GameEngine
    {

        public BoardGame BoardGame { get; set; }

        public Player CurrentPlayer { get; set; }

        public Player OtherPlayer { get; set; }

        public GameEngine(BoardGame boardgame, Player currentPlayer, Player otherPlayer)
        {
            this.BoardGame = boardgame;
            this.CurrentPlayer = currentPlayer;
            this.OtherPlayer = otherPlayer;
        }

        public void launchGame()
        {

            playOneRound();

            // Move de cailloux par les joueurs
            /*Console.WriteLine("Egrainage de cailloux du joueur " + this.BoardGame.Players[0].Name);
            CurrentPlayer.moveSeed(CurrentPlayer.Pits[0], CurrentPlayer.Pits[1]);
            CurrentPlayer.moveSeed(CurrentPlayer.Pits[0], CurrentPlayer.Pits[2]);
            CurrentPlayer.moveSeed(CurrentPlayer.Pits[0], OtherPlayer.Pits[0]); // Vers le pit de Cécile
            Console.Write(this.BoardGame.playersListToString()); // Affichage du plateau après les moves*/
        }

        public void playOneRound()
        {
            int currentPlayerPit = 1;
            int pitToFill = 6 - currentPlayerPit;
            int nbGrainesPlayed = CurrentPlayer.Pits[currentPlayerPit].Seeds.Count;

            //Sow the seeds in the currentPlayer pits
            if (nbGrainesPlayed > 0)
            {
                for (int i = 0; i < pitToFill; i++)
                {
                    if (nbGrainesPlayed > 0)
                    {
                        CurrentPlayer.moveSeed(CurrentPlayer.Pits[currentPlayerPit], CurrentPlayer.Pits[currentPlayerPit + i]);
                        nbGrainesPlayed--;
                    }
                }
            } else
            {
                //TODO ask player to choose another pit
            }
            
            //Sow the seeds in the otherPlayer pits
            if (nbGrainesPlayed > 0)
            {
                int otherPlayerPit = 1;
                for (int i = 0; i < nbGrainesPlayed; i++)
                {
                    CurrentPlayer.moveSeed(CurrentPlayer.Pits[currentPlayerPit], OtherPlayer.Pits[otherPlayerPit + i]);

                    //Collect Seed
                    if (OtherPlayer.Pits[otherPlayerPit + i].Seeds.Count == 2
                        || OtherPlayer.Pits[otherPlayerPit + i].Seeds.Count == 3)
                    {
                        //OtherPlayer.Pits[otherPlayerPit + i].removeGraine(1);
                        CurrentPlayer.Score++;
                    }
                }
            }

           // BoardGame.designateCurrentPlayer();
        }

        

    }
}
