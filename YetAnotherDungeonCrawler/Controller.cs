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
                        view.EndMessage();
                        break;
                    default:
                        InvalidOption();
                        break;
                }

                view.AfterMenu();

                // Keeps the loop going until player chooses 0
            } while (option != 0 && playerDead == false);
        }
        
        /// <summary>
        /// Method to read the provided enemy file line by line
        /// Will split the input to get each variable for the enemy
        /// </summary>
        private void ReadEnemyFile()
        {
            //Change this to relative path.
            string s;
            char sep = Path.DirectorySeparatorChar;
            using StreamReader r =
                new StreamReader
                ($".{sep}YetAnotherDungeonCrawler{sep}Enemies.txt");

            while ((s = r.ReadLine()) != null)
            {
                string[] enemySpecs = s.Split(',');
                string enemyName = enemySpecs[0];
                int enemyHealth = int.Parse(enemySpecs[1]);
                int enemyAttack = int.Parse(enemySpecs[2]);

                //Creates a new enemy using the file's information and
                // adds it to the enemy HashSet
                Enemy enemy = new Enemy(enemyName, enemyHealth, enemyAttack);
                enemies.Add(enemy);
            }
        }

        /// <summary>
        /// Method to read the provided room file to create each room
        /// according to each line in the file.
        /// </summary>
        private void ReadRoomFile()
        {
            string s;
            char sep = Path.DirectorySeparatorChar;
            using StreamReader r =
                new StreamReader
                ($".{sep}YetAnotherDungeonCrawler{sep}Rooms.txt");

            while ((s = r.ReadLine()) != null)
            {
                //Split each line into the necessary variables for the room
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
                    //Checks if the necessary enemy for the room, exists in the
                    //existing enemies provided by the enemy file
                    if (enemyName == enemy.Name)
                    {
                        //Clones the enemy stats from the enemy in the HashSet
                        roomEnemy = Enemy.Clone(enemy);
                    }
                }

                IItem roomItem = null;

                //Checks if the item in the room is a HealthPotion
                if (item == "HealthPotion")
                {
                    //Creates a new HealthPotion for that room
                    roomItem = new HealthPotion();
                }

                int[] exits = new int[4] { north, south, west, east };

                //Creates a new room and adds it to the room list
                rooms.Add(new Room(id, roomEnemy, roomItem, exits));
            }
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
                return view.ShowActions(player);
            }
            else if (roomEnemy == null)
            {
                return view.ShowActions(player, roomItem);
            }
            else if (roomItem == null)
            {
                return view.ShowActions(player, roomEnemy);
            }
            else
            {
                return view.ShowActions(player, roomItem, roomEnemy);
            }
        }

        /// <summary>
        /// Method to parse the provided room IDs into valid ints
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
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
        /// Checks if enemy is defeated and handles the player movement
        /// </summary>
        private void Move()
        {
            Enemy roomEnemy = player.CurrentRoom.Enemy;
            int[] exits = player.CurrentRoom.Exits;
            bool north;
            bool south;
            bool west;
            bool east;
            (north, south, west, east) = GetAvailableExits(exits);

            //check if the enemy is defeated first
            //if its not, shows a message and return to menu
            if (roomEnemy != null)
            {
                view.AttackBeforeMove();
                return;
            }

            int exitOption;

            do
            {
                //Shows the valid exits and returns the input from the player
                exitOption = view.ShowDirections(north, south, west, east);

                // Determine the option specified by the user and act on it
                // If the player wants to go to an invalid direction, shows
                // a message saying that they can't
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

                // Keeps the loop going until player chooses 0
            } while (exitOption != 0);
        }

        /// <summary>
        /// Method to get booleans that represent the available exits of the
        /// current room
        /// </summary>
        /// <param name="exits"></param>
        /// <returns></returns>
        private (bool, bool, bool, bool) GetAvailableExits(int[] exits){
            bool north = true;
            bool south = true;
            bool west = true;
            bool east = true;

            if (exits[0] == 0){
                north = false;
            }

            if (exits[1] == 0){
                south = false;
            }

            if (exits[2] == 0){
                west = false;
            }

            if (exits[3] == 0){
                east = false;
            }

            return (north, south, west, east);
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
            //Message to tell the player to which direction they moved
            view.MoveDirection(direction);
            foreach (Room room in rooms)
            {
                //Moves the player to the correct room, using roomId
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
            //Checks if there is an item to pick
            if (player.CurrentRoom.Item != null)
            {
                //Player adds the item to the inventory
                player.PickUpItem(player.CurrentRoom.Item);
                //Removes the item fro the room
                player.CurrentRoom.ItemPickup();
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

            //initializing a variable to check if player is dead
            bool playerDead = false;

            //Making sure the enemy exists
            if (enemy != null)
            {
                //Attack the enemy
                view.Attack(player.AttackPower);
                player.Attack(enemy);

                //Check if enemy died and remove it from the room if it did
                if (enemy.Health == 0)
                {
                    player.CurrentRoom.Enemy = null;
                }
                else
                {
                    //enemy attacks player if it didn't die when player attacked
                    view.EnemyAttack(enemy.AttackPower);
                    enemy.Attack(player);
                }

                //checks if the player died after the fight
                //changes the playerDead variable to true which will end the game
                if (player.Health == 0)
                {
                    playerDead = true;
                    view.DeadMessage();
                }
            }
            else
            {
                //Tells the player that they picked an invalid option
                InvalidOption();
            }

            return playerDead;
        }

        /// <summary>
        /// Method that calls player's Heal method that return a bool depending
        /// on if there was enough potions to heal or not
        /// </summary>
        private void Heal()
        {
            //Heals the player if they have enough potions, returning true if
            // player had enough potions and false if they didn't
            bool heal = player.Heal();
            if (heal)
            {
                //Will show the player their health after healing
                view.UseHeal(player.Health);
            }
            else
            {
                //Will tell the player that they don't have enough items
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