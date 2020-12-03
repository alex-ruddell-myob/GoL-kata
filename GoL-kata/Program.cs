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
            string endMessage = "default message";
            
            while (run)
            { 
                gameOfLife.Iterate();
                gameOfLife.Print();

                Console.Write("\nPress ANY KEY to end game...");

                if (Console.KeyAvailable)
                {
                    run = false;
                    endMessage = "Game stopped by user";
                }

                if (gameOfLife.NoLiveCells())
                {
                    run = false;
                    endMessage = "Game ended as no live cells are left";
                }
            }

            Console.WriteLine(endMessage);
        }

        static void Initialise()
        {
            Console.WriteLine("Welcome to Conway's Game of Life!\n");
            
            _inputSystem = ConsoleIO.GetUserSelectInputType();
        }
    }
}