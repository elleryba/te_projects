using System;
using System.Collections.Generic;

namespace CollectionsLectureNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            // LIST<T>
            //
            // Lists allow us to hold collections of data. They are declared with a type of data that they hold
            // only allowing items of that type to go inside of them.
            //
            // The syntax used for declaring a new list of type T is
            //      List<T> list = new List<T>();
            //
            //

            // Creating lists of integers
            List<int> numbersList = new List<int>();
            List<int> numbersList2 = new List<int>();

            // Creating lists of strings
            List<string> wordsList = new List<string>();


            /////////////////
            Console.WriteLine(numbersList);
            Console.WriteLine(wordsList);

            //////////////////
            // OBJECT EQUALITY
            //////////////////

            if (numbersList == numbersList2)
            {
                Console.WriteLine("The two lists are the same");
            }

            numbersList = numbersList2;
            if (numbersList == numbersList2)
            {
                Console.WriteLine("The two lists are the same");
            }

            Console.WriteLine();

            /////////////////
            // ADDING ITEMS
            /////////////////

            // Adding items one at a time to each list
            numbersList.Add(2);
            numbersList.Add(20);
            numbersList.Add(200);
            //numbersList.Add("Two"); //<-- compile error, try uncommenting the code

            wordsList.Add("Blue");
            wordsList.Add("Grey");
            wordsList.Add("Green");
            wordsList.Add("Green");
            //wordsList.Add(5); //<-- compile error, try uncommenting the code

            /////////////////
            // ADDING MULTIPLE ITEMS
            /////////////////

            int[] numbersArray = { 2000, 20000 };
            numbersList.AddRange(numbersArray);

            string[] wordsArray = { "Red", "Yellow" };
            wordsList.AddRange(wordsArray);



            //////////////////
            // ACCESSING BY INDEX
            //////////////////

            // Use .Count to get the number of items
            for (int i = 0; i < numbersList.Count; i++)
            {
                Console.WriteLine($"Index {i} is {numbersList[i]}");
            }


            ///////////////////
            // ACCESSING WITH FOR-EACH
            ///////////////////
            Console.WriteLine();
            foreach (string word in wordsList)
            {
                Console.WriteLine(word);
            }

            ////////////////////
            // ADDITIONAL LIST<T> METHODS
            ////////////////////
            bool containsNumber = numbersList.Contains(2);
            Console.WriteLine("List contains 2 - " + containsNumber);

            int index = wordsList.IndexOf("Yellow");
            Console.WriteLine("Yellow is at " + index);

            index = wordsList.IndexOf("yellow");
            Console.WriteLine("yellow is at " + index);

            numbersList.Insert(0, 0);
            Console.WriteLine($"Numbers List has {numbersList.Count} items in it");

            numbersList.Remove(0);
            Console.WriteLine($"Numbers List has {numbersList.Count} items in it");

            wordsList.Remove("Green");

            string[] words = wordsList.ToArray();
            //int[] words1 = wordsList.ToArray(); //<-- try removing, this wont compile

            ////////////////////////
            // SORT and PRINT A LIST
            ////////////////////////

            wordsList.Sort();
            Console.WriteLine(String.Join(", ", wordsList));

            wordsList.Reverse();
            Console.WriteLine(String.Join(", ", wordsList));

            Console.WriteLine();


            // QUEUE <T>
            //
            // Queues are a special type of data structure that follow First-In First-Out (FIFO).
            // With Queues, we Enqueue (add) and Dequeue (remove) items.
            Queue<string> priorities = new Queue<string>();

            priorities.Enqueue("Clean the dishes");
            priorities.Enqueue("Wash the counters");
            priorities.Enqueue("Sweep the floor");
            priorities.Enqueue("Scrub the floor");

            /////////////////////
            // PROCESSING ITEMS IN A QUEUE
            /////////////////////
            while (priorities.Count > 0)
            {
                string nextPriority = priorities.Dequeue();
                Console.WriteLine("NEXT PRIORITY " + nextPriority);
            }


            // STACK <T>
            //
            // Stacks are another type of data structure that follow Last-In First-Out (LIFO).
            // With Stacks, we Push (add) and Pop (remove) items. 
            Stack<string> browserStack = new Stack<string>();

            ////////////////////
            // PUSHING ITEMS TO THE STACK
            //////////////////// 
            browserStack.Push("http://www.google.com");
            browserStack.Push("http://www.cnn.com");
            browserStack.Push("http://www.google.com");
            browserStack.Push("http://www.techelevator.com");
            browserStack.Push("http://www.si.com");

            ////////////////////
            // POPPING THE STACK
            ////////////////////
            while (browserStack.Count > 0)
            {
                string previousPage = browserStack.Pop();
                Console.WriteLine("PREVIOUS PAGE: " + previousPage);
            }

            Console.ReadLine();

        }
    }
}
