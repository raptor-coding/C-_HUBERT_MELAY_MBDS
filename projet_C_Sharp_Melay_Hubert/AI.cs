using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_C_Sharp_Melay_Hubert
{
    internal class AI : Player
    {

        public BoardGame BoardGame { get; set; }
        public Player Adversary { get; set; }
        public int ChoosenPit { get; set; }

        public AI(int ID, string name, List<Pit> pits, Player adversary) : base(ID, name, pits)
        {
            this.Adversary = adversary;
        }

        public int choosePit()
        {
            return 0;
        }
    }
}
