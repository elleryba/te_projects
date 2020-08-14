using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Farming
{
    public class Cow : FarmAnimal
    {
        public Cow(bool isAwake) : base("COW", isAwake)
        {
        }

        protected override string MakeAwakeSoundOnce()
        {
            return "MOO";
        }

        protected override string MakeAwakeSoundTwice()
        {
            return "MOO MOO";
        }


        public void Graze()
        {
            /// The cow grazes
        }

    }
}
