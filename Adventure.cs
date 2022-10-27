using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfGiants
{
    public class Adventure
    {
        public void GoAdventuring(Player player)
        {

            Goliath goliath = new Goliath("Goliath", 100, 50, 25);

            InGameMenu gm = new InGameMenu();

            Random random = new Random();
            var lookForMonster = random.Next(10);

            if (lookForMonster == 10)
            {
                Console.WriteLine("\n--- You venture out into the wild looking for monsters. ---\n");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("You spot a Giant on the horizon. It is too far away and you decide not to take up pursuit.");
                Console.WriteLine("You ask yourself: am I 'David the Giant-Slayer' or a just a simple farmer, incapable of such heroic deeds?\n");
                gm.Menu(player);
            }
            else
            {
                CombatSystem c = new CombatSystem();
                Weapon weapon = new Weapon(33, 10);
                c.Combat(player, weapon, goliath);
            }

        }
    }
}

