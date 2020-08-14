using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Farming
{
    public class Duck : FarmAnimal
    {
        public Duck() : base("DUCK")
        {            
        }

        public override string MakeSoundOnce()
        {
            return "QUACK";
        }

        public override string MakeSoundTwice()
        {
            return "QUACK QUACK";
        }
    }
}
