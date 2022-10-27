using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfGiants
{
    public class Game
    {
        
        public Player player;
        private HealthPotion healthPotion;
        Goliath goliath = new Goliath("Goliath", 100, 50, 25);
        private InGameMenu inGameMenu;
        private string name;


        public void RunGame()
        {
            Console.Clear();
            player = new Player(name, 1, 0, 100, 100, 100);
            player.HealthPoints = 100;
            player.Experience = 0;
            player.Level = 1;

            Console.WriteLine("Welcome, traveler, to the World of Giants.\n");
            Console.WriteLine("What is your name?");
            name = Console.ReadLine();
            Console.WriteLine($"\n{name}, your objective is to hunt down and kill Giants.\n");
            Console.WriteLine("For each Giant you kill, you will gain experience.");
            Console.WriteLine("Gain enough experience and you will level up.");
            Console.WriteLine("With each level you become stronger, gaining health and attack power.");
            Console.WriteLine("The same is true for the Giants.\n");
            Console.WriteLine("Now, your journey will begin.");
            Console.WriteLine("\nPress ENTER to continue.");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("What would you like to do?\n");
            
            inGameMenu = new InGameMenu();
            inGameMenu.Menu(player);
            
        }

    }
}
