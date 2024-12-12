using System;
using TextFilter.Interfaces;

namespace TextFilter.Filters{
    public class LetterFilter : IFilter
    {
        /// <summary>
        /// Filter word with matching letter T|t.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool Match(string word)
        {
            return word.ToLower().Contains('t');
        }
    }
}