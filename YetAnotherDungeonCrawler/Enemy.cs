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
        
        /// <summary>
        /// Takes an enemy instance and creates a new one with the same~
        /// variables
        /// </summary>
        /// <param name="enemy"></param>
        /// <returns></returns>
        public static Enemy Clone(Enemy enemy){
            Enemy clone = new Enemy (enemy.Name, enemy.Health, enemy.AttackPower);
            return clone;
        }
    }
}