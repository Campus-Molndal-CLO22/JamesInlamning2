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



/* while (player.HealthPoints > 0)
            {
                var lookForMonster = random.Next(10);


                if (lookForMonster == 10)
                {
                    Console.WriteLine("\n--- You venture out into the wild looking for monsters. ---\n");
                    System.Threading.Thread.Sleep(1500);
                    Console.WriteLine("You spot a Giant on the horizon. It is too far away and you decide not to take up pursuit.");
                    Console.WriteLine("You ask yourself: am I 'David the Giant-Slayer' or a just a simple farmer, incapable of such heroic deeds?\n");
                    gm.Menu(player);
                }
                else
                {
                    CombatSystem c = new CombatSystem();
                    Goliath goliath = new Goliath("Goliath", 100, 25, 15);
                    Weapon weapon = new Weapon(33, 10);
                    c.Combat(player, goliath, weapon);
                }

            }

            if (player.HealthPoints == 0)
            {
                
                Console.WriteLine("You have died.");
                Console.WriteLine("Would you like to restart? y / n");

                string choice = Console.ReadLine();

                if (choice == "y")
                {
                    Game g = new Game();
                    g.RunGame();
                }
                else if (choice == "n")
                {
                    QuitGame q = new QuitGame();
                    q.Quit();
                }
                else
                {
                    Console.WriteLine("Try again, noob!");
                }

            }
*/ 