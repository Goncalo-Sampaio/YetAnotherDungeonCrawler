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
        private HealthPotion hpotion = new HealthPotion();
        /// <summary>
        /// Reference of the Room the player is currently occupying
        /// </summary>
        public Room CurrentRoom { get; private set; }
        /// <summary>
        /// Inventory. Uses Item as <key> with <value> being Item's quantity
        /// </summary>
        public Dictionary<IItem, int> Inventory { get; set; }
        /// <summary>
        /// Player Constructor
        /// </summary>
        /// <param name="name">Player Name</param>
        /// <param name="health">Player Health</param>
        /// <param name="attack">Player Attack</param>
        /// <param name="startingRoom">Player's starting Room</param>
        public Player(string name, int health, int attack, Room startingRoom)
        : base(name, health, attack)
        {
            maxHealth = health;
            CurrentRoom = startingRoom;
            //By default add a dedicated slot for health potion:            
            Inventory = new Dictionary<IItem, int>();

            Inventory[hpotion] = 0;

        }
        /// <summary>
        /// Sets Player's current Room to destination Room
        /// </summary>
        /// <param name="destination">Target room to move player to</param>
        public void Move(Room destination)
        {
            CurrentRoom = destination;
        }
        /// <summary>
        /// Adds Picked up item to Player's Inventory. If Item already exists
        ///then increases the count
        /// </summary>
        /// <param name="item">Picked up Item</param>
        public void PickUpItem(IItem item)
        {
            if (Inventory.ContainsKey(item)) Inventory[item] += 1;
            else Inventory.Add(item, 1);
        }

        public bool Heal()
        {
            //Check if item of type healinpotion exists in inventory:
            if (Inventory[hpotion] > 0)
            {
                //Remove item from inventory
                Inventory[hpotion] -= 1;
                //Heal Player
                int heal = Health + hpotion.Use();
                if (heal > maxHealth)
                {
                    Health = maxHealth;
                }
                else Health = heal;
                return true;
            }

            return false;
        }
    }
}