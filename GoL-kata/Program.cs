using System;

namespace GoL_kata
{
    class Program
    {
        static void Main(string[] args)
        {
            Initialise();
            InputData input = ConsoleIO.ReadUserInput();
            
            // board = Adapter(data), or something similar
            
        }

        static void Initialise()
        {
            Console.WriteLine("Welcome to Conway's Game of Life!\n");
        }
    }
}