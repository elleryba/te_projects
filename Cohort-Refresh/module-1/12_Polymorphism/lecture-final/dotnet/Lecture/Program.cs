using Lecture.Farming;
using System;
using System.Collections.Generic;

namespace Lecture
{
    class Program
    {
        static void Main(string[] args)
        {
           //
            // OLD MACDONALD
            //

            List<ISingable> singables = new List<ISingable>();

            singables.Add(new Cow());
            singables.Add(new Duck());
            singables.Add(new Chicken());
            singables.Add(new Tractor());

            Console.WriteLine("Old MacDonald had a farm ee ay ee ay oh");

            foreach(ISingable singable in singables)
            {                
                Console.WriteLine("And on his farm there was a " + singable.Name + " ee ay ee ay oh");
                Console.WriteLine("With a " + singable.MakeSoundTwice() + " here and a " + singable.MakeSoundTwice() + " there");
                Console.WriteLine("Here a " + singable.MakeSoundOnce() + ", there a " + singable.MakeSoundOnce() + " everywhere a " + singable.MakeSoundTwice());
                Console.WriteLine("Old Macdonald had a farm, ee ay ee ay oh");
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}