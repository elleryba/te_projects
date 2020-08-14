using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Farming
{
    public class Duck : FarmAnimal
    {
        public Duck(bool isAwake) : base("DUCK", isAwake)
        {            
        }

        protected override string MakeAwakeSoundOnce()
        {
            return "QUACK";
        }

        protected override string MakeAwakeSoundTwice()
        {
            return "QUACK QUACK";
        }
    }
}
