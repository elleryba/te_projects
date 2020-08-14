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
         Given an array of ints, return true if the number of 1's is greater than the number of 4's
         more14([1, 4, 1]) → true
         more14([1, 4, 1, 4]) → false
         more14([1, 1]) → true
         */
        public bool More14(int[] nums)
        {
            int number1s = 0;
            int number4s = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    number1s++;
                }
                if (nums[i] == 4)
                {
                    number4s++;
                }
            }

            return number1s > number4s;
        }


    }
}
