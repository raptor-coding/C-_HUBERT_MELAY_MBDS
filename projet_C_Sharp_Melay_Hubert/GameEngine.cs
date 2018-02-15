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

        }

    }
}
