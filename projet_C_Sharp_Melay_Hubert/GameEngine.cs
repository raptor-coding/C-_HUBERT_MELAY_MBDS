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

        public GameEngine(BoardGame boardgame)
        {
            this.BoardGame = boardgame;
        }

        public void launchGame()
        {
            // Move de cailloux par les joueurs
            Console.WriteLine("Egrainage de cailloux du joueur " + this.BoardGame.Players[0].Name);
            this.BoardGame.Players[0].moveSeed(this.BoardGame.Players[0].Pits[0], this.BoardGame.Players[0].Pits[1]);
            this.BoardGame.Players[0].moveSeed(this.BoardGame.Players[0].Pits[0], this.BoardGame.Players[0].Pits[2]);
            this.BoardGame.Players[0].moveSeed(this.BoardGame.Players[0].Pits[0], this.BoardGame.Players[1].Pits[0]); // Vers le pit de Cécile
            Console.Write(this.BoardGame.playersListToString()); // Affichage du plateau après les moves
        }

    }
}
