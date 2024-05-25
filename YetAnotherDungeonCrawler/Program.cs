using System;

namespace YetAnotherDungeonCrawler
{
    /// <summary>
    /// Starts the Game
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();

            IView view= new View();

            controller.Start(view);
        }
    }
}
