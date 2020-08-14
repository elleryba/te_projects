using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    /// <summary>
    /// A singable item.
    /// </summary>
    public interface ISingable
    {
        /// <summary>
        /// The singable item's name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The single sound the item makes.
        /// </summary>
        /// <returns></returns>
        string MakeSoundOnce();

        /// <summary>
        /// The double sound the item makes.
        /// </summary>
        /// <returns></returns>
        string MakeSoundTwice();
    }
}
