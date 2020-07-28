using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentSystem.Core
{
    /// <summary>
    /// The basic array extension methods.
    /// </summary>
    public static class ArrayExtensions
    {

        /// <summary>
        /// Prepends the 'toAdd' array to the 'source' array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="source">The source array that is to be changed.</param>
        /// <param name="toAdd">The array to be prepended.</param>
        public static T[] Prepend<T>(this T[] source, params T[] toAdd)
        {
            return toAdd.Append(source);
        }

        /// <summary>
        /// Appends the 'toAdd' array to the 'source' array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="source">The source array that is to be changed.</param>
        /// <param name="toAdd">The array to be appended.</param>
        public static T[] Append<T>(this T[] source, params T[] toAdd)
        {
            return source.Concat(toAdd).ToArray();
        }
    }
}
