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

        /// <summary>
        /// Method to start the game. The game loop will be here.
        /// </summary>
        public void Start()
        {
            ReadFile();
        }

        private void ReadFile()
        {
            string s;
            using StreamReader r =
                new StreamReader("./YetAnotherDungeonCrawler/Rooms.txt");

            while ((s = r.ReadLine()) != null)
            {
                string[] roomSpecs = s.Split(',');
                foreach (string i in roomSpecs){
                    Console.WriteLine(i);
                }
            }
        }
    }
}