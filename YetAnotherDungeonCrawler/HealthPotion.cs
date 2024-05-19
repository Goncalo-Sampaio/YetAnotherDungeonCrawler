using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    /// <summary>
    /// Item class. Implements IItem
    /// </summary>
    public class HealthPotion : IItem
    {
        public string Name {get; set;} = "HealthPotion";
        public void Use(Character player) 
        {
            //player.Health += 10;
        }
    }
}