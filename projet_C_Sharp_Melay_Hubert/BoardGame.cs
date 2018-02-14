using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_C_Sharp_Melay_Hubert
{
    class BoardGame
    {
        public List<Player> Players { get; set; }

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
    }
}
