using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter the Fibonacci number: ");
            int limit = int.Parse(Console.ReadLine());
            int previous = 0;

            Console.Write("0");

            for (int next = 1; next < limit;)
            {
                // the first and last section of the for loop are optional.  Here, we do not do anything at the end of each iteration.
                Console.Write(", " + next);

                int temp = previous + next;
                previous = next;
                next = temp;
            }

            Console.WriteLine();
            Console.ReadLine();

        }
    }
}
