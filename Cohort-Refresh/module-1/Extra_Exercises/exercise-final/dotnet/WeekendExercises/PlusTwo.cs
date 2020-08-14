using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class Exercises
    {
        /*
         Given 2 int arrays, each length 2, return a new array length 4 containing all their elements.
         plusTwo([1, 2], [3, 4]) → [1, 2, 3, 4]
         plusTwo([4, 4], [2, 2]) → [4, 4, 2, 2]
         plusTwo([9, 2], [3, 4]) → [9, 2, 3, 4]
         */
        public int[] PlusTwo(int[] a, int[] b)
        {
            int[] newArray = new int[a.Length * 2];

            // Get all items from a
            for (int i = 0; i < a.Length; i++)
            {
                newArray[i] = a[i];
            }

            // Get all items from b
            for (int i = 0; i < b.Length; i++)
            {
                newArray[b.Length + i] = b[i];
            }

            return newArray;
        }


    }
}
