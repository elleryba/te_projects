using System;
using System.Collections.Generic;

namespace DictionaryCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            // Display a greeting
            Console.WriteLine(@"     _       _        _                    ");
            Console.WriteLine(@"    | |     | |      | |                   ");
            Console.WriteLine(@"  __| | __ _| |_ __ _| |__   __ _ ___  ___ ");
            Console.WriteLine(@" / _` |/ _` | __/ _` | '_ \ / _` / __|/ _ \");
            Console.WriteLine(@"| (_| | (_| | || (_| | |_) | (_| \__ \  __/");
            Console.WriteLine(@" \__,_|\__,_|\__\__,_|_.__/ \__,_|___/\___|");
            Console.WriteLine(@"                                           ");

            // Prompt the user to make a choise
            Console.Write("Would you like to enter a(nother) person (y/n)? ");
            string input = Console.ReadLine().ToLower();

            // 1. Create a new Dictionary that could hold string, ints
            //      and practice adding items to it.
            Dictionary<string, int> database = new Dictionary<string, int>();
            database.Add("Josh", 70);

            // Infinitely repeat while the user provides yes or y
            while (input == "yes" || input == "y")
            {
                // Get the next name
                Console.Write("What is the person's name?: ");
                string name = Console.ReadLine();

                // Get the next height
                Console.Write("What is the person's height (in inches)?: ");
                int height = int.Parse(Console.ReadLine());

                // 2. Check to see if a name is in the dictionary
                //      bool exists = dictionaryVariable.ContainsKey(key)
                bool exists = database.ContainsKey(name.ToLower());    // <-- change this

                if (!exists)
                {
                    // Add the new name/height
                    Console.WriteLine($"Adding {name} with new value.");
                    // 3. Put the name and height into the dictionary
                    //      dictionaryVariable[key] = value;
                    //      OR dictionaryVariable.Add(key, value);
                    database[name.ToLower()] = height;

                }
                else
                {
                    // Update the existing name with new height
                    Console.WriteLine($"Overwriting {name} with new value.");
                    // 4. Overwrite the current key with a new value
                    //      dictionaryVariable[key] = value;
                    database[name.ToLower()] = height;
                }

                // Prompt to repeat
                Console.WriteLine();
                Console.Write("Would you like to enter another person (yes/no)? ");
                input = Console.ReadLine().ToLower();
            }

            // Ask what to do next
            Console.Write("Type \"all\" to print all names OR \"search\" to print out single name: ");
            input = Console.ReadLine().ToLower();


            if (input == "search")
            {
                // Prompt the user for a name to search by
                Console.Write("Which name are you looking for? ");
                input = Console.ReadLine();

                //5. Get a specific name from the dictionary
                if (database.ContainsKey(input.ToLower()))
                {
                    int height = database[input.ToLower()];
                    Console.WriteLine($"{input}'s height is {height} inches.");
                }
                else
                {
                    Console.WriteLine($"Could not find {input} in database.");
                }

            }
            else if (input == "all")
            {
                // Loop through the dictionary and display all items
                Console.WriteLine();
                Console.WriteLine(".... printing ...");

                //6. Print each item in the dictionary
                double total = 0.0;
                foreach (KeyValuePair<string, int> kvp in database)
                {
                    string key = kvp.Key;
                    int value = kvp.Value;
                    Console.WriteLine($"{key}-{value}");
                    total += value;
                }

                //7. Print the average height of the ppl in the dictionary
                double averageHeight = total / database.Count;
                Console.WriteLine($"The average height is {averageHeight:N2} inches tall.");
            }

            Console.WriteLine();
            Console.WriteLine("Done...");

            Console.ReadLine();
        }


    }
}
