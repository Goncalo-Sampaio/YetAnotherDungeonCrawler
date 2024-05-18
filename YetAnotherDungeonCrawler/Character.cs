using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    public class Character
    {
        private int Health {get; set;} //protected maybe??
        private int AttackPower {get; set;}

        //maybe abstract check again
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