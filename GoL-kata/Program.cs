using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace GoL_kata
{
    class Program
    {
        private static IInput _inputSystem;
        
        static void Main(string[] args)
        {
            Initialise();
            
            var userInput = _inputSystem.ReadUserInput();
            
            var gameOfLife = new Game(userInput);
            
            gameOfLife.Print();
            Console.Write("\nPress ANY KEY to end game...");
            
            bool run = true;
            while (run)
            { 
                gameOfLife.Iterate();
                gameOfLife.Print();

                Console.Write("\nPress ANY KEY to end game...");
                run = !Console.KeyAvailable;
            }
        }

        static void Initialise()
        {
            Console.WriteLine("Welcome to Conway's Game of Life!\n");

            var key = ConsoleIO.GetUserSelectInputType();
            var type = "default";

            switch (key)
            {
                case ConsoleKey.A:
                    _inputSystem = new UserInput();
                    type = "Console Input";
                    break;
                case ConsoleKey.B:
                    _inputSystem = new MenuInput();
                    type = "Menu Input";
                    break;
            }

            Console.WriteLine("\n\nYou have selected " + type + "\n");
        }
    }
}