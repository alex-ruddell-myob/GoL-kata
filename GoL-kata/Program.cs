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

            // TODO: could get rid of this and put it in "game.Run" if really want to :)
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
            
            _inputSystem = ConsoleIO.GetUserSelectInputType();
        }
    }
}