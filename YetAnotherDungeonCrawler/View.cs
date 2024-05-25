using System;
using System.Collections.Generic;

namespace YetAnotherDungeonCrawler
{
    public class View : IView
    {
        /// <summary>
        /// Welcome Players
        /// </summary>
        public void WelcomeMessage()
        {
            Console.WriteLine("\nWelcome to Yet Another Dungeon Crawler!");
            Console.WriteLine(">-------------------------------------<\n");
            Console.Write("You are in a Dungeon, explore it and ");
            Console.WriteLine("defeat the Boss to win the Game!");
        }

        /// <summary>
        /// Tell the Player how to play
        /// </summary>
        public void Instructions()
        {
            Console.Write("\nThe Dungeon is divided by Rooms, where you can find Items and/or");
            Console.WriteLine("Enemies");
            Console.WriteLine("\n---- Warning ----");
            Console.WriteLine("You will not be able to move until the Monster is dead.");
            Console.WriteLine("\n~~ How to Play? ~~");
            Console.WriteLine("You will receive a list with a couple of options.");
            Console.WriteLine("Choose one by typing a number on the Console.");
            Console.WriteLine("And the most important Rule, have fun!\n");
        }

        /// <summary>
        /// Tell the Player when they die
        /// </summary>
        public void DeadMessage()
        {
            Console.WriteLine("\nYou died...");
        }

        /// <summary>
        /// Thank the Player for playing
        /// </summary>
        public void EndMessage()
        {
            Console.WriteLine("\nThanks for playing our Dungeon Crawler!");
            Console.WriteLine("Hope you had Fun!");
        }

        /// <summary>
        /// General invalid option display
        /// </summary>
        public void InvalidOption()
        {
            Console.WriteLine("\n>>> That is not a Valid Option! <<<");
            Console.WriteLine("Please try again...");
        }

        /// <summary>
        /// Before overloading the Player with information, ask for input
        /// </summary>
        public void AfterMenu()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }

        /// <summary>
        /// Display all available actions and the Room
        /// </summary>
        /// <param name="player">
        /// Current Player
        /// </param>
        /// <param name="dungeonExit">
        /// If it's the the Dungeon Exit or not
        /// </param>
        /// <returns></returns>
        public int ShowActions(Player player, bool dungeonExit)
        {
            Console.WriteLine(">----------------------------------------<");
            Console.WriteLine(">---------|||THE ROOM IS EMPTY|||--------<");
            Console.WriteLine(">----------------------------------------<");
            if (dungeonExit)
            {
                Console.WriteLine(">----------------------------------------<");
                Console.WriteLine(">-----|||THE DUNGEON EXIT IS HERE!|||----<");
                Console.WriteLine(">----------------------------------------<");
            }
            ShowPlayerState(player);
            Console.WriteLine("\nYour available Actions");
            Console.WriteLine(">--------------------<\n");
            Console.WriteLine("1. Move");
            Console.WriteLine("4. Use Item");
            if (dungeonExit)
            {
                Console.WriteLine("5. ESCAPE!");
            }
            Console.WriteLine("0. Quit game");
            Console.Write("\nYour choice: ");

            return int.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Display all available actions and the Room when there is an Item
        /// </summary>
        /// <param name="player">
        /// Current Player
        /// </param>
        /// <param name="item">
        /// Item's name which is in the Room
        /// </param>
        /// <param name="dungeonExit">
        /// If it's the the Dungeon Exit or not
        /// </param>
        /// <returns></returns>
        public int ShowActions(Player player, IItem item, bool dungeonExit)
        {
            Console.WriteLine(">----------------------------------------<");
            Console.WriteLine(">---|||THERE IS AN ITEM IN THE ROOM|||---<");
            Console.WriteLine(">----------------------------------------<");
            if (dungeonExit)
            {
                Console.WriteLine(">----------------------------------------<");
                Console.WriteLine(">-----|||THE DUNGEON EXIT IS HERE!|||----<");
                Console.WriteLine(">----------------------------------------<");
            }
            ShowPlayerState(player);
            Console.WriteLine("\nYour available Actions");
            Console.WriteLine(">--------------------<\n");
            Console.WriteLine("1. Move");
            Console.WriteLine($"2. Pick up {item.Name}");
            Console.WriteLine("4. Use Item");
            if (dungeonExit)
            {
                Console.WriteLine("5. ESCAPE!");
            }
            Console.WriteLine("0. Quit game");
            Console.Write("\nYour choice: ");

            return int.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Display all available actions and the Room when there is an Enemy
        /// </summary>
        /// <param name="player">
        /// Current Player
        /// </param>
        /// <param name="enemy">
        /// The Enemy that is in this Room
        /// </param>
        /// <param name="dungeonExit">
        /// If it's the the Dungeon Exit or not
        /// </param>
        /// <returns></returns>
        public int ShowActions(Player player, Character enemy, bool dungeonExit)
        {
            Console.WriteLine(">----------------------------------------<");
            Console.WriteLine(">---|||THERE IS AN ENEMY IN THE ROOM|||--<");
            Console.WriteLine(">----------------------------------------<");
            if (dungeonExit)
            {
                Console.WriteLine(">----------------------------------------<");
                Console.WriteLine(">-----|||THE DUNGEON EXIT IS HERE!|||----<");
                Console.WriteLine(">----------------------------------------<");
            }
            ShowPlayerState(player);
            ShowEnemyState(enemy);
            Console.WriteLine("\nYour available Actions");
            Console.WriteLine(">--------------------<\n");
            Console.WriteLine("1. Move");
            Console.WriteLine($"3. Fight {enemy.Name}");
            Console.WriteLine("4. Use Item");
            if (dungeonExit)
            {
                Console.WriteLine("5. ESCAPE!");
            }
            Console.WriteLine("0. Quit game");
            Console.Write("\nYour choice: ");

            return int.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Display all available actions and the Room when there is an Item
        /// </summary>
        /// <param name="player">
        /// Current Player
        /// </param>
        /// <param name="item">
        /// Item's name which is in the Room
        /// </param>
        /// <param name="enemy">
        /// The Enemy that is in this Room
        /// </param>
        /// <param name="dungeonExit">
        /// If it's the the Dungeon Exit or not
        /// </param>
        /// <returns></returns>
        //And an Enemy
        public int ShowActions(Player player, IItem item, Character enemy,
            bool dungeonExit)
        {
            Console.WriteLine(">----------------------------------------<");
            Console.WriteLine(">---|||THERE IS AN ITEM IN THE ROOM|||---<");
            Console.WriteLine(">----------------------------------------<");
            Console.WriteLine(">----------------------------------------<");
            Console.WriteLine(">---|||THERE IS AN ENEMY IN THE ROOM|||--<");
            Console.WriteLine(">----------------------------------------<");
            if (dungeonExit)
            {
                Console.WriteLine(">----------------------------------------<");
                Console.WriteLine(">-----|||THE DUNGEON EXIT IS HERE!|||----<");
                Console.WriteLine(">----------------------------------------<");
            }
            ShowPlayerState(player);
            ShowEnemyState(enemy);
            Console.WriteLine("\nYour available Actions");
            Console.WriteLine(">--------------------<\n");
            Console.WriteLine("1. Move");
            Console.WriteLine($"2. Pick up {item.Name}");
            Console.WriteLine($"3. Fight {enemy.Name}");
            Console.WriteLine("4. Heal");
            if (dungeonExit)
            {
                Console.WriteLine("5. ESCAPE!");
            }
            Console.WriteLine("0. Quit game");
            Console.Write("\nYour choice: ");

            return int.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Display Move Action Menu
        /// </summary>
        /// <param name="north">
        /// If there's north exit or not
        /// </param>
        /// <param name="south">
        /// If there's south exit or not
        /// </param>
        /// <param name="west">
        /// If there's west exit or not
        /// </param>
        /// <param name="east">
        /// If there's east exit or not
        /// </param>
        /// <returns>
        /// Option the Player's chose
        /// </returns>
        public int ShowDirections(bool north, bool south, bool west, bool east)
        {
            Console.WriteLine("\nYour available Direction Actions");
            Console.WriteLine(">------------------------------<\n");
            if (north) { Console.WriteLine("1. Move North"); }
            if (south) { Console.WriteLine("2. Move South"); }
            if (west) { Console.WriteLine("3. Move West"); }
            if (east) { Console.WriteLine("4. Move East"); }
            Console.WriteLine("0. Leave Move Action");
            Console.Write("\nYour choice: ");

            return int.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Tell the Player which direction they moved
        /// </summary>
        /// <param name="direction">
        /// Direction which the Player moved
        /// </param>
        public void MoveDirection(Direction direction)
        {
            Console.WriteLine($"\nYou moved {direction}!");
        }

        /// <summary>
        /// Tell the Player they can't move set direction
        /// </summary>
        /// <param name="direction"></param>
        public void NotMove(Direction direction)
        {
            Console.WriteLine($"\n>>> You can't move {direction}! <<<");
            Console.WriteLine("Please try again...");
        }

        /// <summary>
        /// Remind the Player they can't move before killing the Enemy
        /// </summary>
        public void AttackBeforeMove()
        {
            Console.Write("\n>>> You can't move before defeating the ");
            Console.WriteLine("Monster <<<");
            Console.Write("Please try again, after killing it...");
        }

        /// <summary>
        /// Display Player's Health
        /// </summary>
        /// <param name="health">
        /// Player's current health
        /// </param>
        public void ShowHealth(int health)
        {
            Console.WriteLine($"You are at {health} Life now.");
        }

        /// <summary>
        /// Display when the Player attacks an Enemy
        /// </summary>
        /// <param name="damage">
        /// Damage that was dealt to the enemy
        /// </param>
        public void Attack(int damage)
        {
            Console.WriteLine("\nYou attacked the Monster!");
            Console.WriteLine($"You dealt {damage} Damage.");
        }

        /// <summary>
        /// Display when the Enemy attacks the Player
        /// </summary>
        /// <param name="damage">
        /// Damage the was dealt to the Player
        /// </param>
        public void EnemyAttack(int damage)
        {
            Console.WriteLine("\nThe Monster attacked you!");
            Console.WriteLine($"You were dealt {damage} Damage.");
        }

        /// <summary>
        /// Tell the Player the Enemy is dead
        /// </summary>
        public void EnemyDead()
        {
            Console.WriteLine("\nThe Monster died!");
            Console.WriteLine("Good Job!");
        }

        /// <summary>
        /// Tell the Player they picked an Item
        /// </summary>
        /// <param name="item">
        /// Item name which is picked up
        /// </param>
        public void PickUpMessage(IItem item)
        {
            Console.WriteLine($"You picked up a {item.Name}.");
        }

        /// <summary>
        /// Tell the PLayer they don't have enough Items
        /// </summary>
        public void NotEnoughItems()
        {
            Console.WriteLine("\n>>> You don't have enough Items <<<");
            Console.WriteLine("Please try again when you have an Item...");
        }

        /// <summary>
        /// Display text when Player heals
        /// </summary>
        /// <param name="health"></param>
        public void UseHeal(int health)
        {
            Console.WriteLine("\nYou used an Health Potion!");
            ShowHealth(health);
        }
        /// <summary>
        /// Tell the player they won the game
        /// </summary>
        public void ExitDungeon()
        {
            Console.WriteLine(">----------------------------------------<");
            Console.WriteLine(">-----|||YOU ESCAPED THE DUNGEON!|||-----<");
            Console.WriteLine(">---------|||CONGRATULATIONS!|||---------<");
            Console.WriteLine(">----------------------------------------<");
        }
        /// <summary>
        /// Display Player's health and attack
        /// </summary>
        /// <param name="player"></param>
        private void ShowPlayerState(Player player)
        {
            Console.WriteLine();
            Console.WriteLine("Player:");
            Console.WriteLine($"HP: {player.Health}/{player.maxHealth}");
            Console.WriteLine($"Attack: {player.AttackPower}");
        }
        /// <summary>
        /// Display Enemy's health and attack
        /// </summary>
        /// <param name="roomEnemy"></param>
        private void ShowEnemyState(Character roomEnemy)
        {
            Console.WriteLine();
            Console.WriteLine($"{roomEnemy.Name}:");
            Console.WriteLine($"HP: {roomEnemy.Health}");
            Console.WriteLine($"Attack: {roomEnemy.AttackPower}");
        }
    }
}