using System;
using System.Collections.Generic;

namespace GoL_kata
{
    class MenuInput : IInput
    {
        // TODO: TEST ALL OF THESE INPUTS TO SEE IF THEY BREAK.
        
        public InputData ReadUserInput()
        {
            var keyDictionary = GetKeyDictionary();
            var seedDictionary = GetDataDictionary();
            
            Console.WriteLine("Which pattern would you like to input?");
            
            foreach (var item in keyDictionary)
            {
                Console.WriteLine("[{0}]: {1}", item.Key, item.Value);
            }
            
            var found = false;
            string seedReference = "null";
            InputData input = new InputData();

            while (!found)
            {
                Console.Write("Enter a letter:  ");
                seedReference = Console.ReadLine();
                if (keyDictionary.ContainsKey(seedReference))
                {
                    input = seedDictionary[keyDictionary[seedReference]];
                    found = true;
                }
            }

            Console.WriteLine("\nYou have chosen " + seedReference + " as your pattern.");
            
            return input;
        }

        private Dictionary<string, string> GetKeyDictionary()
        {
            return new Dictionary<string, string>()
            {
                { "A", "Beehive" },
                { "B", "Blinker" },
                { "C", "Beacon" },
                { "D", "Pulsar" },
                { "E", "Penta-decathlon" },
                { "F", "Glider" },
                { "H", "Middle-weight spaceship"}
            };
        }

        private Dictionary<string, InputData> GetDataDictionary()
        {
            return new Dictionary<string, InputData>()
            {
                { "Beehive", new InputData {
                    boardHeight = 5, boardWidth = 6, seedHeight = 3, seedWidth = 4, seedString = new[] {"-XX-", "X--X", "-XX-"}
                } },
                { "Blinker", new InputData
                {
                    boardHeight = 5, boardWidth = 5, seedHeight = 3, seedWidth = 3, seedString = new[] {"---", "XXX", "---"}
                } },
                { "Beacon", new InputData
                {
                    boardHeight = 6, boardWidth = 6, seedHeight = 4, seedWidth = 4, seedString = new[] {"XX--", "XX--", "--XX", "--XX"}
                } },
                { "Pulsar", new InputData
                {
                    boardHeight = 17, boardWidth = 17, seedHeight = 13, seedWidth = 13, 
                    seedString = new[] {
                        "--XXX---XXX--", "-------------", "X----X-X----X", "X----X-X----X", "X----X-X----X", "--XXX---XXX--",
                        "--XXX---XXX--", "X----X-X----X", "X----X-X----X", "X----X-X----X", "-------------", "--XXX---XXX--"
                    }
                } },
                { "Penta-decathlon", new InputData
                {
                    boardHeight = 17, boardWidth = 17, seedHeight = 3, seedWidth = 10, seedString = new[] {"--X----X--", "XX-XXXX-XX", "--X----X--"}
                } },
                { "Glider", new InputData
                {
                    boardHeight = 6, boardWidth = 6, seedHeight = 3, seedWidth = 3, seedString = new[] {"-X-", "--X", "XXX"}
                } },
                { "Middle-weight spaceship", new InputData
                {
                    boardHeight = 25, boardWidth = 25, seedHeight = 5, seedWidth = 6, seedString = new[] {"--X---", "X---X-", "-----X", "X----X", "-XXXXX"}
                } }
            };
        }
    }
}