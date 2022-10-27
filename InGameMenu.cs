using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfGiants
{
    public class InGameMenu
    {
        public void Menu(Player player)
        {
                                    
            QuitGame q = new QuitGame();

            while (true)
            {
                

                Console.WriteLine("1. Go Adventuring");
                Console.WriteLine("2. Display Character Information");
                Console.WriteLine("3. Exit Game");

                int option = int.Parse(Console.ReadLine());
                
                if (option == 1)
                {
                    Console.Clear();
                    Adventure adventure = new Adventure();
                    adventure.GoAdventuring(player);
                    
                }
                else if (option == 2)
                {
                    Console.Clear();
                    player.DisplayCharInfo();
                }
                else if (option == 3)
                {
                    Console.Clear();
                    q.Quit();
                }
                else
                {
                    Console.WriteLine("Try again!");
                }
            }
            
            

        }
    }
}
