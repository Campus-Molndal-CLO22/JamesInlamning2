using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfGiants
{
    public class Weapon
    {
        public string Name { get; set; }
        public int MaxDmg { get; set; }
        public int MinDmg { get; set; }

        public Weapon(int maxDmg, int minDmg)
        {
            MaxDmg = maxDmg;
            MinDmg = minDmg;
        }
      
    }
}
