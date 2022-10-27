using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfGiants
{
    public class Player
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public double MaxExperience { get; set; }
        public int HealthPoints { get; set; }
        public int MaxHealthPoints { get; set; }
        

        public Player(string name, int level, int experience, int maxExperience, int healthPoints, int maxHealthPoints)
        {
            Name = name;
            Level = level;
            Experience = experience;
            MaxExperience = maxExperience;
            HealthPoints = healthPoints;
            MaxHealthPoints = healthPoints;
        }

        public void DisplayCharInfo()
        {
            Console.WriteLine("\n");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("--- CHARACTER INFO ---\n");
            Console.WriteLine($"Level: {Level}.");
            Console.WriteLine($"Experience: {Experience}.");
            Console.WriteLine($"Experience required to level up: {MaxExperience}.");
            Console.WriteLine($"Health: {HealthPoints}.\n"); 
        }

        public void LevelUp()
        {
            
            Level++;
            MaxExperience *= 2;
            MaxHealthPoints += 25;
            RefillHP();         
           
        }

        public void RefillHP()
        {
            HealthPoints = MaxHealthPoints;
        }




    }

}
