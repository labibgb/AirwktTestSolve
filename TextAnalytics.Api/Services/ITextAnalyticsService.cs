using TextAnalytics.Api.Models;

namespace TextAnalytics.Api.Services;

public interface ITextAnalyticsService
{
    int GetNumberOfCharacters(string text);
    int GetNumberOfWords(string text);
    int GetNumberOfSentences(string text);
    WordData GetWordWithFrequency(string text);
    WordData GetLongestWordWithLength(string text);
    float CalculateSimilarities(string textA, string textB);
}