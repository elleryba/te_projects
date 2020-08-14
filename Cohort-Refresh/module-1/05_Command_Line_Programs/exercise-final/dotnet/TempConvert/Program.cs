using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter the temperature: ");
            string tempInput = Console.ReadLine();
            int temp = int.Parse(tempInput);

            Console.Write("Is the temperature in (C)elcius, or (F)arenheit?: ");
            string scaleInput = Console.ReadLine();

            if ("F" == scaleInput)
            {
                int celciusTemp = (int)((temp - 32) / 1.8);
                Console.WriteLine(temp + "F is " + celciusTemp + "C.");
            }
            else if ("C" == scaleInput)
            {
                int fahrenheitTemp = (int)((temp * 1.8) + 32);
                Console.WriteLine(temp + "C is " + fahrenheitTemp + "F.");
            }
            else
            {
                Console.WriteLine(scaleInput + " is an invalid choice.");
            }

            Console.ReadLine();
        }
    }
}
