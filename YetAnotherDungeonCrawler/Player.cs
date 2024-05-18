using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    public class Player : Character
    {
        private Room currentRoom;
        private Dictionary<Item, int> Inventory;
        public Player(int health, int attack, Room startingRoom) : base(health, attack)
        {
            currentRoom = startingRoom;
        }
        //Should just move 
        public void Move(Room destination)
        {
            currentRoom = destination;
        }        
        public void PickUpItem() { }
        public void Heal()
        {
            //check if there’s health potion in inventory first. If true Item.Use()}
        }
    }
}