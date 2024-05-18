using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{   
    /// <summary>
    /// Character base class
    /// </summary>
    public class Character
    {
        //Instance variables
        private int Health {get; set;} //protected maybe??
        
        private int AttackPower {get; set;}

        //maybe abstract check again
        /// <summary>
        /// Calls target's "TakeDamage()"
        /// </summary>
        /// <param name="target"></param>
        public void Attack(Character target) 
        {
            target.TakeDamage(AttackPower);
        }

        public void TakeDamage(int damage)
        {
            if (Health - damage <= 0)
            {
                Health = 0;
            }
            else  Health =- damage;
        }
        public Character(int health, int attack)
        {
            this.Health = health;
            this.AttackPower = attack;
        }
    }
}