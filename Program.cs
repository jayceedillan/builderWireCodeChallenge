using System;
using System.IO;
using BuilderWireChallenge.Utilities;

IService service = new Service();

string[] articles = service.readFiles("Article.txt");
string[] words = service.readFiles("Words.txt");
var listOfResults = new List<string>();
int alphabetIdx = 0;
int addAlphabet = 1;

foreach (string word in words)
{

    string alphabetChar = service.getAlphabet(ref alphabetIdx, ref addAlphabet);
    List<int> listOfParagraphIdx = new List<int>();

    int findWords = service.matchWords(articles, word);

    int articleIdx = 1;
    foreach (var article in articles)
    {

        int matchWordsCount = service.matchWords(article, word);
        if (matchWordsCount != 0)
        {
            if (matchWordsCount != 1)
            {
                for (var i = 0; i < matchWordsCount; i++)
                {
                    listOfParagraphIdx.Add(articleIdx);
                }
            }
            else
            {
                listOfParagraphIdx.Add(articleIdx);
            }
        }
        articleIdx++;
    }


    string output = $"{alphabetChar.ToString().ToLower()}. {word} {{{findWords}:";
    string separateCommaByIdx = string.Join(",", listOfParagraphIdx);
    output += $"{separateCommaByIdx}}}";
    listOfResults.Add(output);
}

if (service.writeTextFile(listOfResults))
{
    Console.WriteLine("Theres ann error while writing the files");
}

