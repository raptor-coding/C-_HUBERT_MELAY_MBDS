using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_C_Sharp_Melay_Hubert
{
    public class Pit
    {
        public int Id { get; set; }
        public int Seeds { get; set; }

        public Pit(int id, int seeds)
        {
            this.Id = id;
            this.Seeds = seeds;
        }

        override
        public String ToString()
        {
            return "pit "+this.Id + " - nb graines : " + this.Seeds+"\n";
        }
    }
}
