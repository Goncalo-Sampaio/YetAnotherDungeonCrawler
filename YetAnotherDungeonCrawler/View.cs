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
            Console.WriteLine(">-------------------------------------<\n");
            Console.Write("You are in a Dungeon, explore it and ");
            Console.WriteLine("defeat the Boss to win the Game!")
        }

        //Tell the Player how to play
        public void Instructions()
        {
            Console.Write("The Dungeon is divided by Rooms, where you can find Items and/or");
            Console.WriteLine("Enemies");
            Console.WriteLine("\n---- Warning ----");
            Console.WriteLine("You will not be able to move until the Monster is dead.");
            Console.WriteLine("You will receive a list with couple of options.");
            Console.WriteLine("Choose one by typing a number on the Console to Play.");
            Console.WriteLine("And the most important Rule, have fun!");
        }

        //Display all available actions
        public int ShowActions()
        {
            Console.WriteLine("Your available Actions");
            Console.WriteLine(">--------------------<\n");
            Console.WriteLine("1. Move");
            Console.WriteLine("0. Quit game\n");
            Console.Write("Your choice: ");

            return int.Parse(Console.ReadLine());
        }

        //Display all available actions when there is an Item
        public int ShowActions(IItem item)
        {
            Console.WriteLine("Your available Actions");
            Console.WriteLine(">--------------------<\n");
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
            Console.WriteLine(">--------------------<\n");
            Console.WriteLine("1. Move");
            Console.WriteLine($"2. Fight {enemy.Name}");
            Console.WriteLine("0. Quit game\n");
            Console.Write("Your choice: ");

            return int.Parse(Console.ReadLine());
        }

        //Display all available actions when there is an Item
        //And an Enemy
        public int ShowActions(IItem item, Character enemy)
        {
            Console.WriteLine("Your available Actions");
            Console.WriteLine(">--------------------<\n");
            Console.WriteLine("1. Move");
            Console.WriteLine($"2. Pick up {item.Name}");
            Console.WriteLine($"3. Fight {enemy.Name}");
            Console.WriteLine("0. Quit game\n");
            Console.Write("Your choice: ");

            return int.Parse(Console.ReadLine());
        }

        //Describing Rooms and where can u more
        public void ShowRoom(Room room)
        {
            Console.WriteLine("In this Room you can move:");
            Console.WriteLine("") //room.directions?? help
        }

        //Display Move Action Menu
        public int ShowDirections(bool north, bool south, bool east, bool west)
        {
            Console.WriteLine("Your Direction Actions");
            Console.WriteLine(">-----------------------------<\n");
            Console.WriteLine("1. Move North");
            Console.WriteLine("2. Move South");
            Console.WriteLine("3. Move East");
            Console.WriteLine("4. Move West");
            Console.WriteLine("0. Leave Move Action\n");
            Console.Write("Your choice: ")

            return int.Parse(Console.ReadLine());
        }

        //Tell the Player which direction they moved
        public void MoveDirection(Direction direction)
        {
            Console.WriteLine($"You moved {direction}.");
        }

        //Tell the Player they can't move set direction
        public void NotMove(Direction direction)
        {
            Console.WriteLine($"You can't move {direction}.");
        }

        //Display Player's Health
        void ShowHealth(int health)
        {
            Console.WriteLine($"You are at {health} Life.");
        }

        //Display when the Player attacks an Enemy
        void Attack(int damage)
        {
            Console.WriteLine("You attacked the Monster.");
            Console.WriteLine($"You dealt {damage} Damage.");
        }

        //Display when the Enemy attacks the Player
        void EnemyAttack(int damage)
        {
            Console.WriteLine("The Monster attacked you.");
            Console.WriteLine($"You were dealt {damage} Damage.");
        }

        //Display text when Player heals
        void UseHeal(int healing)
        {
            Console.WriteLine("You used an Health Potion.");
            Console.WriteLine($"You Gained {healing} Life.");
        }
    }
}