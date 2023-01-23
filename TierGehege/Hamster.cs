using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TierGehege
{
    internal class Hamster :Tier
    {
        public Hamster()
        {
            pfad = "/img/hamster.jpg";
            verbrauchHunger = 2;
            verbrauchLiebe = 13;
        }
    }
}
