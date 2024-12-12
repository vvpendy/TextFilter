using System;

namespace TextFilter.Interfaces{
    public interface IProcessor
    {
        public IEnumerable<string> Process();
    }
}