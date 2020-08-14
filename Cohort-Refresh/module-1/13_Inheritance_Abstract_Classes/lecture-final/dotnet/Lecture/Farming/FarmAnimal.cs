using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Farming
{
    public abstract class FarmAnimal : ISingable
    {
        public string Name { get; }
        public bool IsAwake { get; }

        public FarmAnimal(string name, bool isAwake)
        {
            this.Name = name;
            this.IsAwake = isAwake;
        }

        public virtual string MakeSoundOnce()
        {
            string sound;

            if (this.IsAwake)
            {
                sound = this.MakeAwakeSoundOnce();
            }
            else
            {
                sound = "ZZZZ...";
            }

            return sound;
        }

        public virtual string MakeSoundTwice()
        {
            string sound;

            if (this.IsAwake)
            {
                sound = this.MakeAwakeSoundTwice();
            }
            else
            {
                sound = "ZZZZ... ZZZZ...";
            }

            return sound;
        }

        protected abstract string MakeAwakeSoundOnce();
        protected abstract string MakeAwakeSoundTwice();
    }
}
