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
            this.controller = controller;
            this.player = player;
        }

        //Welcome Players
        public void WelcomeMessage()
        {
            Console.WriteLine("Welcome to Yet Another Dungeon Crawler!");
            Console.WriteLine("")
        }

        //Tell the Player how to play
        public void Instructions()
        {
            Console.WriteLine("");
        }

        //Display all available actions
        public int ShowActions()
        {
            Console.WriteLine("Your available Actions");
            Console.WriteLine("-------\n");
            Console.WriteLine("1. Move");
            Console.WriteLine("0. Quit game\n");
            Console.Write("Your choice: ");

            return int.Parse(Console.ReadLine());
        }

        //Display all available actions when there is an Item
        public int ShowActions(Item item)
        {
            Console.WriteLine("Your available Actions");
            Console.WriteLine("-------\n");
            Console.WriteLine("1. Move");
            Console.WriteLine($"2. Pick up {item.Name}");
            Console.WriteLine("0. Quit game\n");
            Console.Write("Your choice: ");

            return int.Parse(Console.ReadLine());
        }

        //Display all available actions when there is an Enemy
        public int ShowActions(Enemy enemy)
        {
            Console.WriteLine("Your available Actions");
            Console.WriteLine("-------\n");
            Console.WriteLine("1. Move");
            Console.WriteLine($"2. Fight {enemy.Name}");
            Console.WriteLine("0. Quit game\n");
            Console.Write("Your choice: ");

            return int.Parse(Console.ReadLine());
        }

        //Display all available actions when there is an Item
        //And an Enemy
        public int ShowActions(Item item, Character enemy)
        {
            Console.WriteLine("Your available Actions");
            Console.WriteLine("-------\n");
            Console.WriteLine("1. Move");
            Console.WriteLine($"2. Pick up {item.Name}");
            Console.WriteLine($"3. Fight {enemy.Name}");
            Console.WriteLine("0. Quit game\n");
            Console.Write("Your choice: ");

            return int.Parse(Console.ReadLine());
        }

        //Describing Rooms
        public void ShowRoom(Room room)
        {
            Console.WriteLine("");
        }

        public void MoveDirection(Direction direction)
        {
            Console.WriteLine($"You moved {Direction.direction.ToString()}");
        }

        //Entering Battle
        void EnterBattle()
        {
            Console.WriteLine("");
        }
    }
}