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
        Given 2 ints, a and b, return true if one if them is 10 or if their sum is 10.
        Makes10(9, 10) → true
        Makes10(9, 9) → false
        Makes10(1, 9) → true
        */
        public bool Makes10(int a, int b)
        {
            // You can put expressions that span multiple lines
            // This can make it easier to read
            bool Makes10 = ((a + b) == 10) ||
                ((a == 10) || (b == 10));

            return Makes10;
        }

    }
}
