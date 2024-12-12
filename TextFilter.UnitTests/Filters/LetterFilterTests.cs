using System;
using TextFilter.Filters;

namespace TextFilter.UnitTests.Filters{
    [TestClass]
    public class LetterFilterTests
    {
        [TestMethod]
        public void Match_Word_That_Contain_Char_T_Returns_True(){
           var letterTFilter = new LetterFilter();

            var result = letterTFilter.Match("AAsfTSs");

            Assert.IsTrue(result);
        }

        public void Match_Word_That_Contain_Char_t_Returns_True(){
           var letterTFilter = new LetterFilter();

            var result = letterTFilter.Match("AAtsfSs");

            Assert.IsTrue(result);
        }
        public void Match_Word_That_Does_Not_Contain_Char_T_Or_t_Returns_False(){
           var letterTFilter = new LetterFilter();

            var result = letterTFilter.Match("AAsfSs");

            Assert.IsFalse(result);
        }
    }
}