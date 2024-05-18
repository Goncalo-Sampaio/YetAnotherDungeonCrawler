using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    /// <summary>
    /// Player Character 
    /// </summary>
    public class Player : Character
    {
        /// <summary>
        /// Player's current room
        /// </summary>
        private Room currentRoom;
        /// <summary>
        /// Inventory. Uses Item as <key> with <value> being Item's quantity
        /// </summary>
        private Dictionary<Item, int> Inventory;
        /// <summary>
        /// Player Constructor
        /// </summary>
        /// <param name="name">Player Name</param>
        /// <param name="health">Player Health</param>
        /// <param name="attack">Player Attack</param>
        /// <param name="startingRoom">Player's starting Room</param>
        public Player(string name,int health, int attack,Room startingRoom) 
        :base (name,health,attack)
        {
            currentRoom = startingRoom;
        }
        
        public void Move(Room destination)
        {
            currentRoom = destination;
        }
        public void PickUpItem(Item item)
        {
            if (Inventory.ContainsKey(item)) Inventory[item] += 1; 
            else Inventory.Add(item, 1);
        }
        public void Heal()
        {
            //if (Inventory.Keys.Co)

            //check if there’s health potion in inventory first. If true Item.Use()}
        }
    }
}