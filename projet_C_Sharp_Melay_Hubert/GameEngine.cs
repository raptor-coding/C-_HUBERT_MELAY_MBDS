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

        public Player Player1 { get; set; }

        public Player Player2 { get; set; }

        public int currentPlayerNb;

        public GameEngine(BoardGame boardgame, Player Player1, Player Player2)
        {
            this.BoardGame = boardgame;
            this.Player1 = Player1;
            this.Player2 = Player2;


            Player1.playerPlayedEvent += Player1_playerPlayedEvent;
            Player2.playerPlayedEvent += Player2_playerPlayedEvent;
        }

        public Player CurrentPlayer
        {
            get
            {
                if (currentPlayerNb == 1)
                    return Player1;
                return Player2;
            }
    
        }

        public Player OtherPlayer
        {
            get
            {
                if (currentPlayerNb == 1)
                    return Player2;
                return Player1;
            }

        }

        public void designatePlayerToPlay()
        {
            if(currentPlayerNb == 0)
            {
                currentPlayerNb = 1;
                 
            } else
            {
                currentPlayerNb = 0;
                
                
            }
            playOneRound();
        }

        public void launchGame()
        {
            currentPlayerNb = 0;

            playOneRound();

        }

        private void Player2_playerPlayedEvent(int pit)
        {
            //CODE APPELE QUAND LE JoueuR 2 VIENS DE JOUER
            leaveSeeds(pit);
        }

        private void Player1_playerPlayedEvent(int pit)
        {
            //CODE APPELE QUAND LE JoueuR 1 VIENS DE JOUER
            leaveSeeds(pit);
        }

        public void playOneRound()
        {
            this.CurrentPlayer.choosePit();
            //Then wait for the event (see method up in this file)
        }

        public void leaveSeeds(int currentPlayerPit)
        { 

            int nbSeeds = this.CurrentPlayer.Pits[currentPlayerPit].Seeds;
            int nbSeedsPlayed = nbSeeds;

            //Sow the seeds in the currentPlayer pits
            if (nbSeeds > 0)
            {
                for (int i = 1; i < nbSeeds; i++)
                {
                    if (currentPlayerPit + i < 6)
                    {
                        CurrentPlayer.moveSeed(CurrentPlayer.Pits[currentPlayerPit], CurrentPlayer.Pits[currentPlayerPit + i]);
                        nbSeedsPlayed--;
                    } else if (nbSeedsPlayed == 0)
                    {
                        if (CurrentPlayer.Score < 24)
                        {
                            Console.WriteLine("fin du tour : le joueur n'a pas déposé de graines dans les trous de son adversaire");
                            Console.WriteLine("other : " + OtherPlayer);
                            Console.WriteLine("current : " + CurrentPlayer);
                            designatePlayerToPlay();
                            
                        }
                    }
                    {
                        
                    }
                }

            } else
            {
                //TODO ask player to choose another pit
            }

            int nbSeedsPlayedInTheOtherPlayerPits = nbSeedsPlayed;
            
            //Sow the seeds in the otherPlayer pits
            if (nbSeedsPlayed > 0)
            {
                int otherPlayerPit = 1;
                for (int i = 0; i < nbSeedsPlayed; i++)
                {
                    CurrentPlayer.moveSeed(CurrentPlayer.Pits[currentPlayerPit], OtherPlayer.Pits[otherPlayerPit + i]);
                    nbSeedsPlayedInTheOtherPlayerPits--;
                   
                    Console.WriteLine(nbSeedsPlayedInTheOtherPlayerPits);
                    if (CurrentPlayer.Score < 24 && nbSeedsPlayedInTheOtherPlayerPits == 0)
                    {
                        Console.WriteLine("fin du tour : le joueur a déposé des graines dans les trous de son adversaire");
                        Console.WriteLine("other : "+OtherPlayer);
                        Console.WriteLine("current : " + CurrentPlayer);
                        designatePlayerToPlay();
                    
                        //BoardGame.designateCurrentPlayer();

                    }
                    //Collect Seed
                    if (OtherPlayer.Pits[otherPlayerPit + i].Seeds == 2
                        || OtherPlayer.Pits[otherPlayerPit + i].Seeds == 3)
                    {
                        OtherPlayer.Pits[otherPlayerPit + i].Seeds--;
                        CurrentPlayer.Score++;
                        
                    }
                }
                
            }

            

            //TEST JULIEN
         /* Console.WriteLine(this.BoardGame.playersListToString()); // Affichage du plateau avant de commencer les coups
            // Move de cailloux par les joueurs
            Console.WriteLineLine("Egrainage de cailloux du joueur " + this.BoardGame.Players[0].Name);
            this.BoardGame.Players[0].moveSeed(this.BoardGame.Players[0].Pits[0], this.BoardGame.Players[0].Pits[1]);
            this.BoardGame.Players[0].moveSeed(this.BoardGame.Players[0].Pits[0], this.BoardGame.Players[0].Pits[2]);
            this.BoardGame.Players[0].moveSeed(this.BoardGame.Players[0].Pits[0], this.BoardGame.Players[1].Pits[0]); // Vers le pit de Cécile
            Console.WriteLineLine("Egrainage de cailloux du joueur " + this.BoardGame.Players[1].Name);
            this.BoardGame.Players[1].moveSeed(this.BoardGame.Players[1].Pits[0], this.BoardGame.Players[1].Pits[1]);
            this.BoardGame.Players[1].moveSeed(this.BoardGame.Players[1].Pits[0], this.BoardGame.Players[1].Pits[2]);
            this.BoardGame.Players[1].moveSeed(this.BoardGame.Players[1].Pits[0], this.BoardGame.Players[0].Pits[0]); // Vers le pit de Jux
            Console.WriteLine(this.BoardGame.playersListToString()); // Affichage du plateau après les moves */

        }

        

    }
}
