using System;
using System.Collections.Generic;

namespace YetAnotherDungeonCrawler
{
    public class View : IView
    {
        //Defining Variables
        private Player player;

        private Controller controller;

        //View Constructor
        public View(Controller controller, Player player)
        {
            this controller = controller;
            this player = player;
        }
        
        //Welcome Players
        void WelcomeMessage()
        {
            Console.WriteLine("");
        }

        void Instructions()
        {
            Console.WriteLine("");
        }
        //Describing Rooms
        void ShowRoom(Room room)
        {
            Console.WriteLine("");
        }

        //Entering Battle
        void EnterBattle();
        {
            Console.WriteLine("");
        }
    }
}