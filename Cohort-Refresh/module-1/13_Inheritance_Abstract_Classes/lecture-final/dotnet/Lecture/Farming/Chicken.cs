
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Farming
{
    public class Chicken : FarmAnimal
    {        
        public Chicken(bool isAwake) : base("CHICKEN", isAwake)
        {
        }

        protected override string MakeAwakeSoundOnce()
        {
            return "CLUCK";
        }

        protected override string MakeAwakeSoundTwice()
        {
            return "CLUCK CLUCK";
        }

    }
}
