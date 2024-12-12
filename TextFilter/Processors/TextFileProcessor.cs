using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using TextFilter.Interfaces;

namespace TextFilter.Processors
{
    public class TextFileProcessor : IProcessor
    {
        private readonly IEnumerable<IFilter> _filters;
        private readonly StreamReader _streamReader;
        private readonly Regex _regex= new(@"\w+");// Match words
        public TextFileProcessor(IEnumerable<IFilter> filters, StreamReader streamReader)
        {
            _filters = filters;
            _streamReader = streamReader;
        }

        /// <summary>
        /// Process the text through the filters.
        /// </summary>
        /// <returns>Filtered Words List</returns>
        public IEnumerable<string> Process()
        {
            List<string> filteredWords= new List<string>();
            string? lineStr;
            while ((lineStr = _streamReader.ReadLine()) != null)
            {
                var words = _regex.Matches(lineStr).Select(m=>m.Value);
        
                var unMatchedWords = words.Where(word=>
                                                    !string.IsNullOrEmpty(word) 
                                                        && !_filters.Any(f=>f.Match(word)));
                filteredWords.AddRange(unMatchedWords);          
            }
            return filteredWords;
        }
    }
}