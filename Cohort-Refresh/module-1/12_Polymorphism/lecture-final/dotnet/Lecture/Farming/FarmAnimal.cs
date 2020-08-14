using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Farming
{
    public class FarmAnimal : ISingable
    {
        public string Name { get; }

        public FarmAnimal(string name)
        {
            this.Name = name;
        }

        public virtual string MakeSoundOnce()
        {
            return "";
        }

        public virtual string MakeSoundTwice()
        {
            return "";
        }


    }
}
