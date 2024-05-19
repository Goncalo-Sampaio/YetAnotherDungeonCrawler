using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    /// <summary>
    /// A Single Room in the Dungeon
    /// </summary>
    public class Room
    {
        /// <summary>
        /// Used to identify the Room
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Enemy in Room. If none then Enemy == null
        /// </summary>
        private Enemy Enemy { get; set; }
        /// <summary>
        /// Item in Room. If none then Item == null
        /// </summary>
        private Item Item { get; set; }  
        /// <summary>
        /// Array that contains room Ids at set index.
        /// [0] = North , [1] = South , [2] = East ,[3] = West 
        /// </summary>
        private int[] exits { get; set; }
        //Constructor
        public Room(int id, Enemy enemy, Item Item, int[] exits ) 
        {
            this.Id = id;
            this.Enemy = enemy;
            this.Item = Item;
            this.exits = exits;
        }

    }

    
}