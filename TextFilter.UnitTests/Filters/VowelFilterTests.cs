using System;
using TextFilter.Filters;

namespace TextFilter.UnitTests.Filters{

    [TestClass]
    public class VowelFilterTests
    {
        [TestMethod]
        public void Match_Word_When_Length_Shorter_Than_Three_Chars_Returns_False(){
            var vowelFilter = new VowelFilter();

            var result = vowelFilter.Match("AA");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Match_Word_When_Length_Is_Even_And_One_Letter_In_The_Middle_Is_Vowels_Returns_True(){
            var vowelFilter = new VowelFilter();

            var result = vowelFilter.Match("BACB");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Match_Word_When_Length_Is_Even_And_Two_Letters_In_The_Middle_Is_Vowels_Returns_True(){
            var vowelFilter = new VowelFilter();

            var result = vowelFilter.Match("KAED");

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Match_Word_When_Length_Is_Even_And_One_Or_Two_Letters_In_The_Middle_Are_Not_Vowels_Returns_False(){
            var vowelFilter = new VowelFilter();

            var result = vowelFilter.Match("KPQD");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Match_Word_When_Length_Is_Odd_And_One_Letters_In_The_Middle_Is_Vowel_Returns_True(){
            var vowelFilter = new VowelFilter();

            var result = vowelFilter.Match("AQEFG");

            Assert.IsTrue(result);
        }

         [TestMethod]
        public void Match_Word_When_Length_Is_Odd_And_One_Letters_In_The_Middle_Is_Not_Vowel_Returns_False(){
            var vowelFilter = new VowelFilter();

            var result = vowelFilter.Match("AQPFG");

            Assert.IsFalse(result);
        }
         
    }

}