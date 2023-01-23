using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TierGehege
{
    public class Tier
    {
        public int leben = 100;
        public int hunger = 100;
        public int liebe = 100;
        public int verbrauchHunger = 5;
        public int verbrauchLiebe = 5;
        public string pfad;


        public virtual double Essen(int food, int hungerLeiste) 
        { 
            return food + hungerLeiste; 
        }

        public virtual double Kuscheln(int liebe, int liebeLeiste)
        { 
            return liebe + liebeLeiste; 
        }

        public List<Tier> Sterben(List<Tier> tierlist, int index)
        {
            tierlist.RemoveAt(index);
            return tierlist;
        }

    }
}
