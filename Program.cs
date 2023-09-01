using System;
using System.Collections.Generic;

namespace MapGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            char[,] map =
            {
                // Your map definition here
            };

            int userX = 6, userY = 6;
            List<char> bag = new List<char>();

            int totalItems = CountItems(map); // Function to count total 'X' items on the map

            while (true)
            {
                Console.SetCursorPosition(0, 20);
                Console.Write("BAG: " + string.Join(" ", bag));

                Console.SetCursorPosition(0, 0);
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        Console.Write(map[i, j]);
                    }
                    Console.WriteLine();
                }

                Console.SetCursorPosition(userY, userX);
                Console.Write('@');
                ConsoleKeyInfo charKey = Console.ReadKey();

                // Handle player movement
                switch (charKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (map[userX - 1, userY] != '#')
                        {
                            userX--;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (map[userX + 1, userY] != '#')
                        {
                            userX++;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (map[userX, userY - 1] != '#')
                        {
                            userY--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (map[userX, userY + 1] != '#')
                        {
                            userY++;
                        }
                        break;
                }

                // Check if the player collects an item
                if (map[userX, userY] == 'X')
                {
                    map[userX, userY] = ' '; // Remove the item from the map
                    bag.Add('X'); // Add the item to the bag
                }

                // Check if the player has collected all items
                if (bag.Count == totalItems)
                {
                    Console.Clear();
                    Console.WriteLine("Congratulations! You have collected all items.");
                    break; // Exit the game
                }

                Console.Clear();
            }
        }

        // Function to count total 'X' items on the map
        static int CountItems(char[,] map)
        {
            int count = 0;
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == 'X')
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
