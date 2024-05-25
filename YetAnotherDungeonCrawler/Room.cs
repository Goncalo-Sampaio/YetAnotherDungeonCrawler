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
        public int Id { get;}
        /// <summary>
        /// Enemy in Room. If none then Enemy == null
        /// </summary>
        public Enemy Enemy { get; set; }
        /// <summary>
        /// Item in Room. If none then Item == null
        /// </summary>
        public IItem Item { get; private set; }
        /// <summary>
        /// Array that contains room Ids at set index.
        /// [0] = North , [1] = South , [2] = East ,[3] = West 
        /// </summary>
        public int[] Exits { get;}
        //Constructor
        public Room(int id, Enemy enemy, IItem item, int[] exits ) 
        {
            Id = id;
            Enemy = enemy;
            Item = item;
            Exits = exits;
        }

        public void ItemPickup(){
            Item = null;
        }
    } 
}