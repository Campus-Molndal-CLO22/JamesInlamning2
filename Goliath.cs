using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfGiants
{
    public class Goliath : Monster
    {
        public int HealthPoints { get; set; }
        public int RewardXP { get; set; }
        public int MonsterAttack { get; set; }

        public Goliath(string name, int healthPoints, int rewardXP, int monsterAttack) : base(name)
        {
            HealthPoints = healthPoints;
            RewardXP = rewardXP;
            MonsterAttack = monsterAttack;  
        }

        public void giveXP(Player player)
        {
            
            player.Experience += RewardXP*player.Level;
        }

        public void monsterLevelUp(Goliath goliath)
        {
            goliath.HealthPoints += 50;
        }
    }
}
