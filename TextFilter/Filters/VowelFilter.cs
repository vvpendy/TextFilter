using System;
using TextFilter.Interfaces;

namespace TextFilter.Filters{
    public class VowelFilter : IFilter
    {
        /// <summary>
        /// Filter out word that contains a vowel in the middle.
        /// </summary>
        /// <param name="word"></param>
        /// <returns>true if matches else false</returns>
        public bool Match(string word)
        {
             int len = word.Length;
                //ignore word length less than 3
                if (len < 3) return false; 
                string middle = len % 2 == 0 
                //when the length is even and two letters in the middle to match
                    ? word.Substring(len / 2 - 1, 2) 
                //when the length is odd and one letter in the middle to match
                    : word.Substring(len / 2, 1);
                // return all words that do not match the vowel criteria
                return middle.Any(c => "aeiou".Contains(char.ToLower(c)));
        }
    }
}