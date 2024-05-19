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
        private string Name {get; set;}
        private int Health {get; set;}        
        private int AttackPower {get; set;}

        /// <summary>
        /// Calls target's TakeDamage() method passing in the AttackPower
        /// </summary>
        /// <param name="target">target Character instance</param>
        public void Attack(Character target) 
        {
            target.TakeDamage(AttackPower);
        }
        /// <summary>
        /// Subtracts damage from Health. Health doesn't go bellow 0
        /// </summary>
        /// <param name="damage">incoming damage value</param>
        public void TakeDamage(int damage)
        {
            if (Health - damage <= 0)
            {
                Health = 0;
            }
            else  Health =- damage;
        }
        //Character Constructor
        public Character(string name,int health, int attack)
        {
            this.Name = name;
            this.Health = health;
            this.AttackPower = attack;
        }
    }
}