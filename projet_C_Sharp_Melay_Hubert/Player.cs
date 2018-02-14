using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_C_Sharp_Melay_Hubert
{
    class Player
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int Score { get; set; }
        public List<Pit> Pits { get; set; }

        public Player(int ID, String name, List<Pit> pits)
        {
            this.Id = ID;
            this.Name = name;
            this.Score = 0;
            this.Pits = pits;
        }

        override
        public String ToString()
        {
            return this.Id + " - " + this.Name + " - score : " + this.Score + "\npits :\n" + this.PitsListToString()+ "\n";
        }

        public String PitsListToString()
        {
            String text = "";
            foreach (Pit pit in Pits)
            {
                text += pit.ToString();
            }
            return text;
        }

        /*public void fillPitWithMulitpleSeed(List<Seed> seeds, Pit pit)
        {
            pit.receiveMultipleSeed(seeds);
        }

        public void fillPitWithOneSeed(Seed seeds, Pit pit)
        {
            pit.receiveOneSeed(seeds);
        }*/
        
    }
}
