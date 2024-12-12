using System.Text;
using System.Text.RegularExpressions;
using Moq;
using TextFilter.Interfaces;
using TextFilter.Processors;

namespace TextFilter.UnitTests.Processors;
[TestClass]
public class TextFileProcessorTests
{
    private List<IFilter>? _mockFilters;
    private StreamReader? _mockStreamReader;
    private IEnumerable<string>? _expectedWords;


       [TestInitialize]
        public void Setup()
        {

            // Create mock dependencies
            _mockFilters = new List<IFilter>();
           
           // Create mock StreamReader
            string textContent = "This is a test line";
            var memStream = new MemoryStream(Encoding.UTF8.GetBytes(textContent));
            _mockStreamReader = new StreamReader(memStream);

            //mock words list
            _expectedWords = Regex.Matches(textContent, @"\w+").Select(m=>m.Value);
            
        }

        [TestMethod]
        public void Process_Should_Return_EmptyCollection_When_Stream_Is_Empty(){
            
            string textContent = string.Empty;
            var memStream = new MemoryStream(Encoding.UTF8.GetBytes(textContent));
            _mockStreamReader = new StreamReader(memStream);

            var textfileProcessor = new TextFileProcessor(_mockFilters, _mockStreamReader);

            var result = textfileProcessor.Process();

            Assert.AreEqual(0,result.Count());

        }
        [TestMethod]
        public void Process_Should_Return_All_Words_When_No_Match_Exist(){
            
            var mockFilter1 = new Mock<IFilter>();
            mockFilter1.Setup(f => f.Match(It.IsAny<string>())).Returns(false); // No words filtered by this filter
            _mockFilters.Add(mockFilter1.Object);

            var mockFilter2 = new Mock<IFilter>();
            mockFilter2.Setup(f =>  f.Match(It.IsAny<string>())).Returns(false); // No words filtered by this filter
            _mockFilters.Add(mockFilter2.Object);

            var textfileProcessor = new TextFileProcessor(_mockFilters, _mockStreamReader);

            var result = textfileProcessor.Process();

            Assert.AreEqual(_expectedWords.Count(),result.Count());

        }

        [TestMethod]
        public void Process_Should_Filter_The_Matched_Words(){
            
            var expectedMatchedWord ="test";
            var mockFilter1 = new Mock<IFilter>();
            mockFilter1.Setup(f => f.Match(It.Is<string>(s => s.Equals(expectedMatchedWord)))).Returns(true); // Match of the word occurs in this filter
            _mockFilters.Add(mockFilter1.Object);

            var mockFilter2 = new Mock<IFilter>();
            mockFilter2.Setup(f =>  f.Match(It.IsAny<string>())).Returns(false); // No words filtered by this filter
            _mockFilters.Add(mockFilter2.Object);

            var textfileProcessor = new TextFileProcessor(_mockFilters, _mockStreamReader);

            var result = textfileProcessor.Process();

            Assert.IsFalse(result.Contains(expectedMatchedWord));

        }

        

        [TestCleanup]
        public void TearDown(){
            _mockFilters.Clear();
            _mockStreamReader.Close();           
        }
}
