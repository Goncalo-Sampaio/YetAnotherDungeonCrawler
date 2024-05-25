using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    /// <summary>
    /// Enemy Character
    /// </summary>
    public class Enemy : Character
    {
        //Enemy Constructor 
        public Enemy (string name,int health, int attack) 
        :base (name,health,attack)
        {
            
        }
        
        public static Enemy Clone(Enemy enemy){
            Enemy clone = new Enemy (enemy.Name, enemy.Health, enemy.AttackPower);
            return clone;
        }
    }
}