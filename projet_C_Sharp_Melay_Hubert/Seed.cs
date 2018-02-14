using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_C_Sharp_Melay_Hubert
{
    class Seed
    {
        public int Id { get; set; }

        public Seed(int id)
        {
            this.Id = id;
        }

        override
        public String ToString()
        {
            return this.Id.ToString();
        }

    }
}
