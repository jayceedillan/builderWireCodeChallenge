using BuilderWireChallenge.Utilities;
using Xunit;

namespace BuilderWireChallenge.UnitTest
{
    public class ServiceTest
    {
        readonly IService service = new Service();

        [Fact]
        public void is26Alphabet()
        {
            int alphabetCount = service.getAllAlphabet()!.Count();
            Assert.Equal(26, alphabetCount);
        }

        [Fact]
        public void getFirstAlphabet()
        {
            int alphabetIdx = 0;
            int addAlphabet = 1;

            string alphabetChar = service.getAlphabet(ref alphabetIdx, ref addAlphabet);
            Assert.Equal("a", alphabetChar);
        }

        [Fact]
        public void getLastAlphabet()
        {
            int alphabetIdx = 25;
            int addAlphabet = 1;
            
            string alphabetChar = service.getAlphabet(ref alphabetIdx, ref addAlphabet);
            Assert.Equal("z", alphabetChar);
        }

        [Fact]
        public void getDoubleAndFirstAlphabet()
        {
            int alphabetIdx = 0;
            int addAlphabet = 2;
            
            string alphabetChar = service.getAlphabet(ref alphabetIdx, ref addAlphabet);
            Assert.Equal("aa", alphabetChar);
        }

        [Fact]
        public void getDoubleAndLastAlphabet()
        {
            int alphabetIdx = 25;
            int addAlphabet = 2;
            
            string alphabetChar = service.getAlphabet(ref alphabetIdx, ref addAlphabet);
            Assert.Equal("zz", alphabetChar);
        }

        [Fact]
        public void getThirdAndFirstAlphabet()
        {
            int alphabetIdx = 0;
            int addAlphabet = 3;
            
            string alphabetChar = service.getAlphabet(ref alphabetIdx, ref addAlphabet);
            Assert.Equal("aaa", alphabetChar);
        }

        [Fact]
        public void getThirdAndLastAlphabet()
        {
            int alphabetIdx = 25;
            int addAlphabet = 3;
            
            string alphabetChar = service.getAlphabet(ref alphabetIdx, ref addAlphabet);
            Assert.Equal("zzz", alphabetChar);
        }

        [Fact]
        public void matchWordForThis()
        {
            string[] articles = service.readFiles("Article.txt");
            
            int findWords = service.matchWords(articles, "this");
            Assert.Equal(3, findWords);
        }

        [Fact]
        public void matchWordForMr()
        {
            string[] articles = service.readFiles("Article.txt");
            
            int findWords = service.matchWords(articles, "mr.");
            Assert.Equal(1, findWords);
        }

        [Fact]
        public void matchWordForMrNotEquatlZero()
        {
            string[] articles = service.readFiles("Article.txt");
            
            int findWords = service.matchWords(articles, "mr.");
            Assert.NotEqual(0, findWords);
        }

        [Fact]
        public void matchWordForThisAndSingle()
        {
            string[] articles = service.readFiles("Article.txt");
           string article = "This is what I learned from Mr. Jones about a paragraph.";
            int findWords = service.matchWords(article, "this");
            Assert.Equal(1, findWords);
        }

        [Fact]
        public void matchWordForParagraphSingle()
        {
            string[] articles = service.readFiles("Article.txt");
           string article = @"This is what I learned from Mr. Jones about a paragraph." +
                            @"A paragraph is a group of words put together to form a group that is usually longer than a sentence. ";
            
            int findWords = service.matchWords(article, "paragraph");
            Assert.Equal(2, findWords);
        }

        [Fact]
        public void isSuccessWriteTextFile()
        {
            string[] outputs = service.readFiles("Output.txt");
            var listOfResults = new List<string>();
            
            foreach (var output in outputs)
            {
                listOfResults.Add(output);
            }
            bool isSuccess = service.writeTextFile(listOfResults);
            Assert.True(isSuccess);
        }
    }
}
