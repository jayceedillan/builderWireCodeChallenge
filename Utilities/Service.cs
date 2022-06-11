namespace BuilderWireChallenge.Utilities
{
    public class Service : IService
    {
        string currentDirectory =
               Directory.GetCurrentDirectory() + "/Files/";

        public IEnumerable<char>? getAllAlphabet()
        {
            return Enumerable.Range(0, 26).Select(i => Convert.ToChar('A' + i));
        }

        public string getAlphabet(ref int idx, ref int needToAdd)
        {

            int tempIdx = idx >= 26 ? 0 : idx;
            string alphabet = this.getAllAlphabet()!.ElementAt(tempIdx).ToString().ToLower();


            if (idx >= 26)
            {
                needToAdd++;
                idx = 1;
            }
            else
            {
                idx++;
            }

            string alphabets = "";

            for (var i = 0; i < needToAdd; i++)
            {
                alphabets += alphabet;
            }

            return alphabets;

        }

        ///<summary>
        /// 
        ///</summary>
        public int matchWords(string article, string searchWord)
        {
            int matchWordsCount = searchingMatchWords(article, searchWord);

            return matchWordsCount;
        }
        public int matchWords(string[] articles, string searchWord)
        {
            string newArticles = String.Join(",", articles.Select(a => a.ToString()).ToArray()).ToLower();
            int matchWordsCount = searchingMatchWords(newArticles, searchWord);

            return matchWordsCount;
        }

        private int searchingMatchWords(string article, string searchWord)
        {
            string[] newArticles = article.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);

            var matchWords = from word in newArticles
                             where word.Equals(searchWord, StringComparison.InvariantCultureIgnoreCase)
                             select word;

            if (matchWords.Count() == 0 && searchWord.Contains("."))
            {
                string[] searchArticleAgain = article.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);

                matchWords = searchArticleAgain.Where(a => a.Contains(searchWord, StringComparison.InvariantCultureIgnoreCase)).AsEnumerable();
                return matchWords.Count();

            }

            return matchWords.Count();
        }
        public string[] readFiles(string fileName)
        {

            currentDirectory = currentDirectory.Contains("Debug") ? Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.Parent!.FullName + "/Files/" : currentDirectory;
            
            return File.ReadAllLines(currentDirectory + fileName);
        }
        public bool writeTextFile(List<string> listOfResults)
        {
            string writePathDir = currentDirectory + "Output.txt";

            try
            {
                using (StreamWriter sw = File.CreateText(writePathDir))
                {
                    foreach (var result in listOfResults)
                    {
                        sw.WriteLine(result);
                    }
                }

                return true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

    }

}