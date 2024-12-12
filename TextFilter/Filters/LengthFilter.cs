using System;
using TextFilter.Interfaces;

namespace TextFilter.Filters{
    public class LengthFilter : IFilter
    {
        /// <summary>
        /// Filter out word shorter than three.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool Match(string word)
        {
            return word.Length < 3;
        }
    }
}