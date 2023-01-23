using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TierGehege
{
    public class Hund : Tier
    {
        public Hund()
        {
            pfad = "/img/dog.jpg";
            verbrauchHunger = 10;
            verbrauchLiebe = 10;
        }

        public override double Essen(int food, int hungerLeiste)
        {
           return food + hungerLeiste;
        }

    }
}
