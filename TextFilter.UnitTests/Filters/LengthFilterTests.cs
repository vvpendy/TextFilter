using System;
using TextFilter.Filters;

namespace TextFilter.UnitTests.Filters{
    [TestClass]
    public class LengthFilterTests
    {
        [TestMethod]
        public void Match_Word_Of_Length_Less_Than_Three_Returns_True(){
           
            var lengthFilter = new LengthFilter();

            var result = lengthFilter.Match("AA");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Match_Word_Of_Length_Greater_Than_Or_Equal_To_Three_Returns_False(){
           
            var lengthFilter = new LengthFilter();

            var result = lengthFilter.Match("BBB");

            Assert.IsFalse(result);
        }

    }
}