using System;
using System.Collections.Generic;

namespace YetAnotherDungeonCrawler
{
    public class View : IView
    {
        //Defining Variables
        private Map map;

        private Controller controller;

        //View Constructor
        public View(Controller controller, Player player)
        {
            this controller = controller;
            this player = player;
        }

        //Welcome Players
        public void WelcomeMessage()
        {
            Console.WriteLine("");
        }

        //Tell the Player how to play
        public void Instructions()
        {
            Console.WriteLine("");
        }

        //Describing Rooms
        public void ShowRoom(Room room)
        {
            Console.WriteLine("");
        }

        public void MoveDirection(Direction direction)
        {
            Console.WriteLine($"You moved {Direction.direction}");
        }

        //Entering Battle
        void EnterBattle();
        {
            Console.WriteLine("");
        }
    }
}