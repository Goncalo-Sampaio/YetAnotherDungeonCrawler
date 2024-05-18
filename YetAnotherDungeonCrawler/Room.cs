using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    public class Room
    {
        public int Id { get; set; }
        private Enemy Enemy { get; set; }
        private Item Item { get; set; }        
        private int[] exits ;

        public Room(int id, Enemy enemy, Item Item, int[] exits ) 
        {
            this.Id = id;
            this.Enemy = enemy;
            this.Item = Item;
            this.exits = exits;
        }

    }

    
}