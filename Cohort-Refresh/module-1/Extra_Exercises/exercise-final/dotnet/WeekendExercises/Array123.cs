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
         Given an array of ints, return true if .. 1, 2, 3, .. appears in the array somewhere.
         array123([1, 1, 2, 3, 1]) → true
         array123([1, 1, 2, 4, 1]) → false
         array123([1, 1, 2, 1, 2, 3]) → true
         */
        public bool Array123(int[] nums)
        {
            // We go to the array but only up until 2 from the end
            // If the array is 1 or 2 items we don't look
            for (int i = 0; i < nums.Length - 2; i++)
            {
                // first will be a 1, 2nd a 2, 3rd a 3
                if (nums[i] == 1 && nums[i + 1] == 2 && nums[i + 2] == 3)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
