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
        private readonly int maxHealth;
        /// <summary>
        /// Reference of the Room the player is currently occupying
        /// </summary>
        private  Room currentRoom;
        /// <summary>
        /// Inventory. Uses Item as <key> with <value> being Item's quantity
        /// </summary>
        private Dictionary<IItem, int> Inventory;
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
            maxHealth = health;
            currentRoom = startingRoom;
        }
        /// <summary>
        /// Sets Player's current Room to destination Room
        /// </summary>
        /// <param name="destination">Target room to move player to</param>
        public void Move(Room destination)
        {
            currentRoom = destination;
        }
        /// <summary>
        /// Adds Picked up item to Player's Inventory. If Item already exists
        ///then increases the count
        /// </summary>
        /// <param name="item">Picked up Item</param>
        public void PickUpItem(Item item)
        {
            if (Inventory.ContainsKey(item)) Inventory[item] += 1; 
            else Inventory.Add(item, 1);
        }
        
        public void Heal(Item healingPotion)
        {
            //Healing Behavior
        }
    }
}