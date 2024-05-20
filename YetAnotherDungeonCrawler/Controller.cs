using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    /// <summary>
    /// Controller class that will handle all the game logic and communicate
    /// with the View
    /// </summary>
    public class Controller
    {
        private IView view;

        private List<Room> rooms = new List<Room>();
        private HashSet<Enemy> enemies = new HashSet<Enemy>();
        private Player player;

        /// <summary>
        /// Method to start the game. The game loop will be here.
        /// </summary>
        public void Start(IView view)
        {
            this.view = view;


            ReadEnemyFile();
            ReadRoomFile();

            player = new Player("Player", 50, 20, rooms[0]);

            foreach (Room room in rooms)
            {
                Console.WriteLine(room.Id);
                Console.WriteLine(room.Enemy);
                Console.WriteLine(room.Item);
                foreach (int i in room.Exits)
                {
                    Console.WriteLine(i);
                }

                Console.WriteLine("------------------");
            }

            int option;
            bool playerDead = false;

            do
            {
                // Show menu and get user option
                option = DifferentMenu(player);

                // Determine the option specified by the user and act on it
                switch (option)
                {
                    case 1:
                        Move();
                        break;
                    case 2:
                        PickItem();
                        break;
                    case 3:
                        playerDead = Attack();
                        break;
                    case 4:
                        Heal();
                        break;
                    case 0:
                        //VIEW : end game message
                        //End Game
                        break;
                    default:
                        InvalidOption();
                        break;
                }

                //After Menu message

                // Keeps the loop going until player chooses 0
            } while (option != 0 || playerDead == false);
        }

        /// <summary>
        /// Method that shows a different menu depending on the current room's
        /// state
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        private int DifferentMenu(Player player)
        {
            Enemy roomEnemy = player.CurrentRoom.Enemy;
            IItem roomItem = player.CurrentRoom.Item;

            if (roomEnemy == null && roomItem == null)
            {
                return view.ShowActions();
            }
            else if (roomEnemy == null)
            {
                return view.ShowActions(roomItem);
            }
            else if (roomItem == null)
            {
                return view.ShowActions(roomEnemy);
            }
            else
            {
                return 0;
                //return view.ShowActions(roomItem, roomEnemy);
            }
        }

        private void ReadEnemyFile()
        {
            string s;
            using StreamReader r =
                new StreamReader("./YetAnotherDungeonCrawler/Enemies.txt");

            while ((s = r.ReadLine()) != null)
            {
                string[] enemySpecs = s.Split(',');
                string enemyName = enemySpecs[0];
                int enemyHealth = int.Parse(enemySpecs[1]);
                int enemyAttack = int.Parse(enemySpecs[2]);

                Enemy enemy = new Enemy(enemyName, enemyHealth, enemyAttack);
                enemies.Add(enemy);
            }
        }

        private void ReadRoomFile()
        {
            string s;
            using StreamReader r =
                new StreamReader("./YetAnotherDungeonCrawler/Rooms.txt");

            while ((s = r.ReadLine()) != null)
            {
                string[] roomSpecs = s.Split(',');
                int id = int.Parse(roomSpecs[0]);
                string enemyName = roomSpecs[1];
                string item = roomSpecs[2];
                int north = RoomExit(roomSpecs[3]);
                int south = RoomExit(roomSpecs[4]);
                int west = RoomExit(roomSpecs[5]);
                int east = RoomExit(roomSpecs[6]);

                Enemy roomEnemy = null;
                foreach (Enemy enemy in enemies)
                {
                    if (enemyName == enemy.Name)
                    {
                        roomEnemy = enemy;
                    }
                }

                IItem roomItem = null;
                if (item == "HealthPotion")
                {
                    roomItem = new HealthPotion();
                }

                int[] exits = new int[4] { north, south, west, east };

                rooms.Add(new Room(id, roomEnemy, roomItem, exits));
            }
        }

        private int RoomExit(string roomId)
        {
            if (roomId == "null")
            {
                return 0;
            }
            else
            {
                return int.Parse(roomId);
            }
        }

        /// <summary>
        /// Checks if enemy is defeated
        /// </summary>
        private void Move()
        {
            Enemy roomEnemy = player.CurrentRoom.Enemy;
            int[] exits = player.CurrentRoom.Exits;
            //check if the enemy is defeated first
            //if its not, show a message and return to menu

            if (roomEnemy != null)
            {
                //VIEW : tell the player he needs to defeat the enemy first
                return;
            }

            int exitOption;

            do
            {
                // VIEW :
                //Shows the player the available exits and asks for input
                exitOption = int.Parse(Console.ReadLine());

                // Determine the option specified by the user and act on it
                switch (exitOption)
                {
                    case 1:
                        if (exits[0] == 0)
                        {
                            InvalidExit(Direction.North);
                        }
                        else
                        {
                            MovePlayer(exits[0], Direction.North);
                            return;
                        }
                        break;
                    case 2:
                        if (exits[1] == 0)
                        {
                            InvalidExit(Direction.South);
                        }
                        else
                        {
                            MovePlayer(exits[1], Direction.South);
                            return;
                        }
                        break;
                    case 3:
                        if (exits[2] == 0)
                        {
                            InvalidExit(Direction.West);
                        }
                        else
                        {
                            MovePlayer(exits[2], Direction.West);
                            return;
                        }
                        break;
                    case 4:
                        if (exits[3] == 0)
                        {
                            InvalidExit(Direction.East);
                        }
                        else
                        {
                            MovePlayer(exits[3], Direction.East);
                            return;
                        }
                        break;
                    case 0:
                        break;
                    default:
                        InvalidOption();
                        break;
                }

                //After Menu message

                // Keeps the loop going until player chooses 0
            } while (exitOption != 0);
        }

        /// <summary>
        /// Tells the player its an invalid exit
        /// </summary>
        private void InvalidExit(Direction direction)
        {
            view.NotMove(direction);
        }

        /// <summary>
        /// Checks for the destination room and moves the player
        /// </summary>
        /// <param name="roomId"></param>
        private void MovePlayer(int roomId, Direction direction)
        {
            view.MoveDirection(direction);
            foreach (Room room in rooms)
            {
                if (room.Id == roomId)
                {
                    player.Move(room);
                }
            }
        }

        /// <summary>
        /// Adds the item to the player inventory and checks if there's
        /// an item to pick on that room
        /// </summary>
        private void PickItem()
        {
            if (player.CurrentRoom.Item != null)
            {
                player.Inventory[player.CurrentRoom.Item] += 1;
            }
            else
            {
                InvalidOption();
            }
        }

        /// <summary>
        /// Method to attack an enemy, if it exists, and get attacked by the
        /// enemy if it is still alive
        /// </summary>
        /// <returns></returns>
        private bool Attack()
        {
            //Get the enemy from the current room
            Enemy enemy = player.CurrentRoom.Enemy;

            //initizaling a variable to check if player is dead
            bool playerDead = false;

            //Making sure the enemy exists
            if (enemy != null)
            {
                //Attack the enemy
                player.Attack(enemy);

                //Check if enemy died and remove if from the room if it did
                if (enemy.Health == 0)
                {
                    player.CurrentRoom.Enemy = null;
                }
                else
                {
                    //------enemy attack needs to return true if player dies
                    //check if player died after getting attacked
                    enemy.Attack(player);
                }
            }
            else
            {
                //Cant attack because there is no enemy in the room
                InvalidOption();
            }
            if (player.Health == 0)
            {
                playerDead = true;
            }

            return playerDead;
        }

        /// <summary>
        /// Method that calls player's Heal method that return a bool depending
        /// on if there was enough potions to heal or not
        /// </summary>
        private void Heal()
        {
            bool heal = player.Heal();
            if (heal)
            {
                view.UseHeal(player.Health);
            }
            else
            {
                view.NotEnoughItems();
            }
        }

        /// <summary>
        /// Tells the player that the option picked, is invalid
        /// </summary>
        private void InvalidOption()
        {
            view.InvalidOption();
        }
    }
}