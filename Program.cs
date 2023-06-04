using MovieHandler.Controller;
using System;

namespace MovieHandler
{
    public class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("You need to use at least one input parameter with the url of the movie database website");
                return;
            }

            new MovieHandlerApp(args[0]).Execute();
        }
    }
}
