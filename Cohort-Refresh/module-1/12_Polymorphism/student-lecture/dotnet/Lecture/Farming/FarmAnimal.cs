using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Farming
{
    /// <summary>
    /// A base farm animal class.
    /// </summary>
    public class FarmAnimal
    {       
        /// <summary>
        /// The farm animal's name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Creates a new farm animal.
        /// </summary>
        /// <param name="name">The name which the animal goes by.</param>
        public FarmAnimal(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// The noise made when the farm animal makes a sound.
        /// </summary>
        /// <returns></returns>
        public virtual string MakeSoundOnce()
        {
            return "";
        }

        /// <summary>
        /// The noise made when the farm animal makes its sound twice.
        /// </summary>
        /// <returns></returns>
        public virtual string MakeSoundTwice()
        {
            return "";
        }


    }
}
