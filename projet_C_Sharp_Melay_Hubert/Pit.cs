using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_C_Sharp_Melay_Hubert
{
    class Pit
    {
        public int Id { get; set; }
        public List<Seed> Seeds { get; set; }

        public Pit(int id, List<Seed> seeds)
        {
            this.Id = id;
            this.Seeds = seeds;
        }

        override
        public String ToString()
        {
            return "pit "+this.Id + " - nb graines : " + this.Seeds.Count+"\n";
        }
    }
}
