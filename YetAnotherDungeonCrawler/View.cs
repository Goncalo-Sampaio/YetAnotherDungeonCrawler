using System;
using System.Collections.Generic;

namespace YetAnotherDungeonCrawler
{
    public class View : IView
    {
        //Welcome Players
        public void WelcomeMessage()
        {
            Console.WriteLine("Welcome to Yet Another Dungeon Crawler!");
            Console.WriteLine(">-------------------------------------<\n");
            Console.Write("You are in a Dungeon, explore it and ");
            Console.WriteLine("defeat the Boss to win the Game!");
        }

        //Tell the Player how to play
        public void Instructions()
        {
            Console.Write("\nThe Dungeon is divided by Rooms, where you can find Items and/or");
            Console.WriteLine("Enemies");
            Console.WriteLine("\n---- Warning ----");
            Console.WriteLine("You will not be able to move until the Monster is dead.");
            Console.WriteLine("\n~~ How to Play? ~~");
            Console.WriteLine("You will receive a list with a couple of options.");
            Console.WriteLine("Choose one by typing a number on the Console.");
            Console.WriteLine("And the most important Rule, have fun!");
        }

        //Tell the Player when they die
        public void DeadMessage()
        {
            Console.WriteLine("\nYou died...");
        }

        //Thank the Player for playing
        public void EndMessage()
        {
            Console.WriteLine("\nThanks for playing our Dungeon Crawler!");
            Console.WriteLine("Hope you had Fun!");
        }

        //General invalid option display
        public void InvalidOption()
        {
            Console.WriteLine("\n>>> That is not a Valid Option! <<<");
            Console.WriteLine("Please try again...");
        }

        //
        public void AfterMenu()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }

        //Display all available actions
        public int ShowActions(Player player)
        {   Console.WriteLine(">----------------------------------------<");
            Console.WriteLine(">---------|||THE ROOM IS EMPTY|||--------<");
            Console.WriteLine(">----------------------------------------<");
            ShowPlayerState(player);
            Console.WriteLine("\nYour available Actions");
            Console.WriteLine(">--------------------<\n");
            Console.WriteLine("1. Move");
            Console.WriteLine("4. Use Item");
            Console.WriteLine("0. Quit game");
            Console.Write("\nYour choice: ");

            return int.Parse(Console.ReadLine());
        }

        //Display all available actions when there is an Item
        public int ShowActions(Player player,IItem item)
        {
            Console.WriteLine(">----------------------------------------<");
            Console.WriteLine(">---|||THERE IS AN ITEM IN THE ROOM|||---<");
            Console.WriteLine(">----------------------------------------<");
            ShowPlayerState(player);
            Console.WriteLine("\nYour available Actions");
            Console.WriteLine(">--------------------<\n");
            Console.WriteLine("1. Move");
            Console.WriteLine($"2. Pick up {item.Name}");
            Console.WriteLine("4. Use Item");
            Console.WriteLine("0. Quit game");
            Console.Write("\nYour choice: ");

            return int.Parse(Console.ReadLine());
        }

        //Display all available actions when there is an Enemy
        public int ShowActions(Player player,Character enemy)
        {
            Console.WriteLine(">----------------------------------------<");
            Console.WriteLine(">---|||THERE IS AN ENEMY IN THE ROOM|||--<");
            Console.WriteLine(">----------------------------------------<");
            ShowPlayerState(player);
            ShowEnemyState(enemy);
            Console.WriteLine("\nYour available Actions");
            Console.WriteLine(">--------------------<\n");
            Console.WriteLine("1. Move");
            Console.WriteLine($"3. Fight {enemy.Name}");
            Console.WriteLine("4. Use Item");
            Console.WriteLine("0. Quit game");
            Console.Write("\nYour choice: ");

            return int.Parse(Console.ReadLine());
        }

        //Display all available actions when there is an Item
        //And an Enemy
        public int ShowActions(Player player,IItem item, Character enemy)
        {
            Console.WriteLine(">----------------------------------------<");
            Console.WriteLine(">---|||THERE IS AN ITEM IN THE ROOM|||---<");
            Console.WriteLine(">----------------------------------------<");
            Console.WriteLine(">----------------------------------------<");
            Console.WriteLine(">---|||THERE IS AN ENEMY IN THE ROOM|||--<");
            Console.WriteLine(">----------------------------------------<");
            ShowPlayerState(player);
            ShowEnemyState(enemy);
            Console.WriteLine("\nYour available Actions");
            Console.WriteLine(">--------------------<\n");
            Console.WriteLine("1. Move");
            Console.WriteLine($"2. Pick up {item.Name}");
            Console.WriteLine($"3. Fight {enemy.Name}");
            Console.WriteLine("4. Heal");
            Console.WriteLine("0. Quit game");
            Console.Write("\nYour choice: ");

            return int.Parse(Console.ReadLine());
        }

        //Display Move Action Menu
        public int ShowDirections(bool north, bool south, bool west, bool east)
        {
            Console.WriteLine("\nYour available Direction Actions");
            Console.WriteLine(">------------------------------<\n");
            if (north)  {Console.WriteLine("1. Move North");}
            if (south)  {Console.WriteLine("2. Move South");}
            if (west)   {Console.WriteLine("3. Move West");}
            if (east)   {Console.WriteLine("4. Move East");}
            Console.WriteLine("0. Leave Move Action");
            Console.Write("\nYour choice: ");

            return int.Parse(Console.ReadLine());
        }

        //Tell the Player which direction they moved
        public void MoveDirection(Direction direction)
        {
            Console.WriteLine($"\nYou moved {direction}!");
        }

        //Tell the Player they can't move set direction
        public void NotMove(Direction direction)
        {
            Console.WriteLine($"\n>>> You can't move {direction}! <<<");
            Console.WriteLine("Please try again...");
        }

        //Remind the Player they can't move before killing the Enemy
        public void AttackBeforeMove()
        {
            Console.Write("\n>>> You can't move before defeating the ");
            Console.WriteLine("Monster <<<");
            Console.Write("Please try again, after killing it...");
        }

        //Display Player's Health
        public void ShowHealth(int health)
        {
            Console.WriteLine($"You are at {health} Life now.");
        }

        //Display when the Player attacks an Enemy
        public void Attack(int damage)
        {
            Console.WriteLine("\nYou attacked the Monster!");
            Console.WriteLine($"You dealt {damage} Damage.");
        }

        //Display when the Enemy attacks the Player
        public void EnemyAttack(int damage)
        {
            Console.WriteLine("\nThe Monster attacked you!");
            Console.WriteLine($"You were dealt {damage} Damage.");
        }

        //Tell the Player the Enemy is dead
        public void EnemyDead()
        {
            Console.WriteLine("\nThe Monster died!");
            Console.WriteLine("Good Job!");
        }

        //Tell the Player they picked an Item
        public void PickUpMessage(IItem item)
        {
            Console.WriteLine($"You picked up a {item.Name}.");
        }

        //Tell the PLayer they don't have enough Items
        public void NotEnoughItems()
        {
            Console.WriteLine("\n>>> You don't have enough Items <<<");
            Console.WriteLine("Please try again when you have an Item...");
        }

        //Display text when Player heals
        public void UseHeal(int health)
        {
            Console.WriteLine("\nYou used an Health Potion!");
            ShowHealth(health);
        }
        private void ShowPlayerState(Player player)
        {
            Console.WriteLine();
            Console.WriteLine("Player:");
            Console.WriteLine($"HP: {player.Health}/{player.maxHealth}");
            Console.WriteLine($"Attack: {player.AttackPower}");    
        }
        private void ShowEnemyState(Character roomEnemy)
        {
            Console.WriteLine();
            Console.WriteLine($"{roomEnemy.Name}:");
            Console.WriteLine($"HP: {roomEnemy.Health}");
            Console.WriteLine($"Attack: {roomEnemy.AttackPower}");
        }
    }
}