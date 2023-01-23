using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TierGehege
{

    internal class Katze :Tier
    {
        public Katze()
        {
            pfad = "/img/katze.jpg";
            verbrauchHunger = 5;
            verbrauchLiebe = 5;
        }
    }
}
