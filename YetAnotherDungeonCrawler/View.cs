using System;
using System.Collections.Generic;

namespace YetAnotherDungeonCrawler
{
    public class View : IView
    {
        //Defining Variables
        //private Map map;

        private Controller controller;
        private Player player;

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
            Console.Write("You are in a Dungeon, explore it and ");
            Console.WriteLine("defeat the Boss to win the Game!")
        }

        //Tell the Player how to play
        public void Instructions()
        {
            Console.Write("The Dungeon is divided by Rooms, where you can find Items and/or");
            Console.WriteLine("Enemies");
            Console.WriteLine("\n-- Warning --");
            Console.WriteLine("You will not be able to move until the Monster is dead.");
            Console.WriteLine("You will receive a list with couple of options.");
            Console.WriteLine("Choose one by typing a number on the Console to Play.");
            Console.WriteLine("And the most import Rule, have fun!");
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
        public int ShowActions(IItem item)
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
            //Console.WriteLine($"2. Fight {Enemy.enemy}");
            Console.WriteLine("0. Quit game\n");
            Console.Write("Your choice: ");

            return int.Parse(Console.ReadLine());
        }

        //Display all available actions when there is an Item
        //And an Enemy
        public int ShowActions(IItem item, Character enemy)
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
            Console.WriteLine($"You moved {direction}");
        }

        //Entering Battle
        void EnterBattle()
        {
            Console.WriteLine("");
        }
    }
}