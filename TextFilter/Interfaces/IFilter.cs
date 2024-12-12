using System;

namespace TextFilter.Interfaces{

    public interface IFilter
    {
        public bool Match(string word);
    }

}