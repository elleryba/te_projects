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
         Given an array of ints, return true if it contains no 1's or it contains no 4's.
         no14([1, 2, 3]) → true
         no14([1, 2, 3, 4]) → false
         no14([2, 3, 4]) → true
         */
        public bool No14(int[] nums)
        {
            bool contains1 = false;
            bool contains4 = false;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    contains1 = true;
                }

                if (nums[i] == 4)
                {
                    contains4 = true;
                }
            }

            //return does not contain 1s or does not contain 4s
            return !contains1 || !contains4;
        }
    }
}
