using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Farming
{
    public class Cow : FarmAnimal
    {
        public Cow() : base("COW")
        {
        }

        public override string MakeSoundOnce()
        {
            return "MOO";
        }

        public override string MakeSoundTwice()
        {
            return "MOO MOO";
        }


        public void Graze()
        {
            /// The cow grazes
        }

    }
}
