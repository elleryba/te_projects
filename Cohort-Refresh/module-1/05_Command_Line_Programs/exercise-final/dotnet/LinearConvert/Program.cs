using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter the length: ");
            string lengthInput = Console.ReadLine();
            int length = int.Parse(lengthInput);

            Console.Write("Is the measurement in (m)eters, or (f)eet?: ");
            string unitInput = Console.ReadLine();

            if ("f" == unitInput)
            {
                int meterLength = (int)(length * .3048);
                Console.WriteLine(length + "f is " + meterLength + "m.");
            }
            else if ("m" == unitInput)
            {
                int feetLength = (int)(length * 3.2808399);
                Console.WriteLine(length + "m is " + feetLength + "f.");
            }
            else
            {
                Console.WriteLine(unitInput + " is an invalid choice.");
            }

            Console.ReadLine();
        }
    }
}
