using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    public class Room
    {
        public int Id { get; set;}
        private Enemy Enemy {get; set;}
        private Item Item  {get; set;}

        //Rooms
        private Room North  {get; set;}
        private Room South {get; set;}
        private Room West {get; set;}
        private Room East {get; set;}

        private List<Room> Exits;  //for convenience 

        public Room () {}

    }

    
}