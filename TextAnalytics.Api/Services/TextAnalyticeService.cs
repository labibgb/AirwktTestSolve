using TextAnalytics.Api.Models;

namespace TextAnalytics.Api.Services;

public class TextAnalyticeService : ITextAnalyticsService
{
    public int GetNumberOfCharacters(string text)
    {
        var ignore = " .?,!".ToCharArray();
        var filteredChars = text.Where(x => !ignore.Contains(x)).ToList();
        return filteredChars?.Count ?? 0;
    }

    public int GetNumberOfWords(string text)
    {
        return GetWords(text).Length;
    }

    public int GetNumberOfSentences(string text)
    {
        var sentences = text.Split('.', '?', '!').Where(x => x.Length > 0);
        return sentences.Count();
    }

    public WordData GetWordWithFrequency(string text)
    {
        var words = GetWords(text).GroupBy(x => x, StringComparer.CurrentCultureIgnoreCase).Select(x =>
            new WordData
            {
                Word = x.First(),
                Count = x.Count()
            }
        ).ToList();

        var data = words.First(x => x.Count == words.Max(y => y.Count));
        return data;

    }

    public WordData GetLongestWordWithLength(string text)
    {
        var words = GetWords(text);
        var maxLength = words.Max(x => x.Length);
        var longestWord = words.First(x => x.Length == maxLength);
        return new WordData
        {
            Word = longestWord,
            Count = maxLength
        };
    }

    public float CalculateSimilarities(string textA, string textB)
    {
        var words1 = GetWords(textA).Select(x => x.ToLower());
        var words2 = GetWords(textB).Select(x => x.ToLower());
        var similar = words1.Count(x => words2.Contains(x));
        var res = ((float)similar / (float)words1.Count()) * 100;
        return res;
    }

    private string[] GetWords(string text)
    {
        return text.Split(' ');
    }
}