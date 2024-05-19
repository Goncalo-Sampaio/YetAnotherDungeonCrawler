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
        List<Room> rooms = new List<Room>();
        HashSet<Enemy> enemies = new HashSet<Enemy>();

        /// <summary>
        /// Method to start the game. The game loop will be here.
        /// </summary>
        public void Start()
        {
            ReadRoomFile();
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
                int enemyHealth = int.Parse(roomSpecs[2]);
                int enemyDamage = int.Parse(roomSpecs[3]);
                //foreach (Enemy enemy in enemies){}
                Enemy enemy = new Enemy(enemyName, enemyHealth, enemyDamage);
                string item = roomSpecs[4];
                int north = RoomExit(roomSpecs[5]);
                int south = RoomExit(roomSpecs[6]);
                int west = RoomExit(roomSpecs[7]);
                int east = RoomExit(roomSpecs[8]);
                int[] exits = new int[4] { north, south, west, east };
                //rooms.Add(new Room(id,enemy,item,exits));
            }
        }

        private void ReadEnemyFile()
        {
            string s;
            using StreamReader r =
                new StreamReader("./YetAnotherDungeonCrawler/Rooms.txt");

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