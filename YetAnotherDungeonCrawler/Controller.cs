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

            do
            {
                // Show menu and get user option
                option = DifferentMenu(player);

                // Determine the option specified by the user and act on it
                switch (option)
                {
                    case 1:
                        //Move
                        break;
                    case 2:
                        //Pick Item
                        break;
                    case 3:
                        //Fight
                        break;
                    case 4:
                        //Heal
                        break;
                    case 0:
                        //End Game
                        break;
                    default:
                        //Invalid Option
                        break;
                }

                //After Menu message

                // Keeps the loop going until player chooses 0
            } while (option != 0);
        }

        private int DifferentMenu(Player player){
            Enemy roomEnemy = player.CurrentRoom.Enemy;
            IItem roomItem = player.CurrentRoom.Item;

            if (roomEnemy == null && roomItem == null){
                return view.ShowActions();
            }
            else if (roomEnemy == null){
                return view.ShowActions(roomItem);
            }
            else if (roomItem == null){
                return view.ShowActions(roomEnemy);
            }
            else {
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
    }
}