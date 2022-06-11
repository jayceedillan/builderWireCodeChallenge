namespace BuilderWireChallenge.Utilities
{
    public interface IService
    {
        IEnumerable<char>? getAllAlphabet();
        string getAlphabet(ref int idx, ref int needToAdd);
        string[] readFiles(string fileName);

        int matchWords(string article, string searchWord);
        int matchWords(string[] articles, string searchWord);
        bool writeTextFile(List<string> listOfResults);
    }
}