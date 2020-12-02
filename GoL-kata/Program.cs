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

            var board = new Board(userInput);
            
            int iteration = 0;
            ConsoleIO.PrintGameBoard(board, iteration);
            
            while (!Console.KeyAvailable)
            {
                board = Game.Iterate(board);
                iteration++;
                
                ConsoleIO.PrintGameBoard(board, iteration);

                Console.Write("\nPress ANY KEY to end game...");
                Thread.Sleep(1000);
            }
        }

        static void Initialise()
        {
            Console.WriteLine("Welcome to Conway's Game of Life!\n");

            var key = ConsoleIO.GetUserSelection();
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