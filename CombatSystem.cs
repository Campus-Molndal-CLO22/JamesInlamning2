using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfGiants
{
    public class CombatSystem
    {

        public void Combat(Player player, Weapon weapon, Goliath goliath)
        {

            InGameMenu gm = new InGameMenu();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("--- MONSTER FOUND ---");
            Console.ResetColor();
            Console.WriteLine($"\nSTOMP STOMP STOMP");
            Console.WriteLine($"A wild {goliath.Name} appears!");
            Console.WriteLine("Combat ensues.");
            Console.WriteLine($"\nEnemy health: {goliath.HealthPoints}.");
            Console.WriteLine($"Player health : {player.HealthPoints}.");

            CombatMenu(player, goliath, weapon);
            

            void CombatMenu(Player player, Goliath goliath, Weapon weapon)
            {
                do
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("\n--- PLAYER TURN ---\n");
                    Console.ResetColor();
                    Console.WriteLine("1. Attack");
                    Console.WriteLine("2. Use Health Potion");
                    Console.WriteLine("3. Flee");
                    
                    int option = int.Parse(Console.ReadLine());
                    

                    if (option == 1)
                    {
                        Console.Clear();
                        PlayerAttack(player, goliath, weapon);
                    }
                    else if (option == 2)
                    {
                        HealthPotion healthPotion = new HealthPotion("Health Potion", 25);
                        healthPotion.Heal(player);
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("--- HEAL ---");
                        Console.ResetColor();
                        Console.WriteLine("You heal yourself for 25 health points!");
                        Console.WriteLine($"You now have {player.HealthPoints} health.\n");
                    }
                    else if (option == 3)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("---  FLEE ---");
                        Console.ResetColor();
                        Console.WriteLine("Someone once called you Coward and you decided to live up to that name.");
                        Console.WriteLine("You flee from combat.\n");
                        player.RefillHP();
                        System.Threading.Thread.Sleep(500);
                        gm.Menu(player);
                    }
                    else
                    {
                        Console.WriteLine("Try again! Use keys 1, 2 or 3 to select action.");
                    }

                    
                    MonsterAttack();
                    System.Threading.Thread.Sleep(500);

                } while (goliath.HealthPoints > 0 && player.HealthPoints > 0);



                void MonsterAttack()
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("--- ENEMY TURN --- \n");
                    Console.ResetColor();
                    int monsterattack = goliath.MonsterAttack * player.Level / 3;
                    player.HealthPoints -= monsterattack;
                    Console.WriteLine($"{goliath.Name} strikes you, dealing {monsterattack} damage!\n");


                    if (player.HealthPoints <= 0)
                    {
                        Game g = new Game();
                        QuitGame q = new QuitGame();

                        Console.WriteLine("Your world blackens as your skull is crushed under the weight of your opponent's foot.");
                        Console.WriteLine("You fall into nothingness.\n");

                        while (true)
                        {

                            Console.WriteLine("Would you like to restart?");
                            Console.WriteLine("1. Yes.");
                            Console.WriteLine("2. No, quit game.");

                            int option = int.Parse(Console.ReadLine());

                            if (option == 1)
                            {
                                g.RunGame();
                            }
                            else if (option == 2)
                            {
                                q.Quit();
                            }
                            else
                            {
                                Console.WriteLine("Try again.");
                            }

                        }

                    }
                    else if (player.HealthPoints > 0)
                    {
                        
                        Console.WriteLine($"You now have {player.HealthPoints} health!");
                    }
                }

                void PlayerAttack(Player player, Goliath goliath, Weapon weapon)
                {
                    Random random = new Random();
                    int attackdmg = random.Next(weapon.MinDmg, weapon.MaxDmg) * player.Level / 2;
                    goliath.HealthPoints -= attackdmg;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("--- ATTACK ---");
                    Console.ResetColor();
                    Console.WriteLine($"\nYou strike {goliath.Name}, dealing {attackdmg} damage!");
                    
                    if (goliath.HealthPoints <= 0)
                    {
                        Console.WriteLine($"{goliath.Name} falls dead to the ground.");
                        Console.WriteLine($"\nCongratulations, you have defeated {goliath.Name} like the true hero you are!");
                        player.RefillHP();
                        Console.WriteLine("Your health has been refilled.");
                        goliath.giveXP(player);
                        Console.WriteLine("\n----------");
                        Console.WriteLine($"You gain {goliath.RewardXP*player.Level} experience.");
                        Console.WriteLine($"Current experience: {player.Experience}.");
                        Console.WriteLine($"Experience required to level up: {player.MaxExperience}.");
                        Console.WriteLine("----------\n");

                        if (player.Experience >= player.MaxExperience)
                        {
                            player.LevelUp();
                            goliath.monsterLevelUp(goliath);

                            if (player.Level < 10)
                            {
                                Console.WriteLine("--- LEVEL UP ---\n");
                                Console.WriteLine($"Congratulations, you have reached level {player.Level}!");
                                Console.WriteLine($"Your max health has increased to {player.MaxHealthPoints}.");
                                Console.WriteLine("Attack power increased.\n");
                            }
                            else if (player.Level == 10)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("--- VICTORY ---\n");
                                Console.ResetColor();
                                Console.WriteLine($"Congratulations, you have reached level {player.Level}!");
                                Console.WriteLine("By reaching level 10 you have proved yourself a worthy giant-slayer.");
                                Console.WriteLine("You are relieved of your duties and may return home.");
                                Console.WriteLine("You win.");
                                QuitGame q = new QuitGame();
                                q.Quit();
                            }
                            

                        }
                        
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("What's your next move?\n");
                        gm.Menu(player);

                    }
                    else if (goliath.HealthPoints > 0)
                    {
                        Console.WriteLine($"\n{goliath.Name} now has {goliath.HealthPoints} health.\n");
                    }
                }
            }
        }
    }
}
