namespace TextAnalytics.Api.Models;

public class AnalyzeViewModel
{
    public int CharCount { get; set; }
    public int WordCount { get; set; }
    public int SentenceCount { get; set; }
    public WordData MostFrequentWord { get; set; }
    public WordData LongestWord { get; set; }
}

public class WordData
{
    public string Word { get; set; }
    public int Count { get; set; }
}