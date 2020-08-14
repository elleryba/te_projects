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
         Given an array of ints of even length, return a new array length 2 containing the middle two elements from 
         the original array. The original array will be length 2 or more.
         makeMiddle([1, 2, 3, 4]) → [2, 3]
         makeMiddle([7, 1, 2, 3, 4, 9]) → [2, 3]
         makeMiddle([1, 2]) → [1, 2]
         */
        public int[] MakeMiddle(int[] nums)
        {
            int middleFirst = (nums.Length / 2) - 1;
            int middlelast = (nums.Length / 2);

            return new int[] { nums[middleFirst], nums[middlelast] };
        }
    }
}
