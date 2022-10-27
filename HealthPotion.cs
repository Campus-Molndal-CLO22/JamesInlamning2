using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfGiants
{
    public class HealthPotion
    {
        public string Name { get; set; }
        public int AmountToHeal { get; set; }

        public HealthPotion(string name, int amountToHeal)
        {
            Name = name;
            AmountToHeal = amountToHeal;
        }

        public void Heal(Player player)
        {
            
            if (player.Level < 3)
            {
                AmountToHeal = 25;
            }
            else if (player.Level >= 3)
            {
                AmountToHeal *= player.Level / 2;
            }
                        
            
            if (player.HealthPoints == player.MaxHealthPoints)
            {
                Console.WriteLine("You are already at full health.");
                Console.WriteLine("Turn wasted.");
            }
            else if (player.HealthPoints < player.MaxHealthPoints)
            {
                player.HealthPoints += AmountToHeal;

                if (player.HealthPoints > player.MaxHealthPoints)
                {
                    player.HealthPoints = player.MaxHealthPoints;
                }
            }
            
        }
                     
    }
}
