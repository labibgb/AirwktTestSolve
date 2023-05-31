using System.Net;
using Microsoft.AspNetCore.Mvc;
using TextAnalytics.Api.Models;
using TextAnalytics.Api.Services;

namespace TextAnalytics.Api.Controllers;

public class TextAnalyticsController : Controller
{
    private readonly ITextAnalyticsService _textAnalyticsService;

    public TextAnalyticsController(ITextAnalyticsService textAnalyticsService)
    {
        _textAnalyticsService = textAnalyticsService;
    }
    
    [HttpPost("/analyze")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(AnalyzeViewModel))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(string))]
    public IActionResult Analyze([FromBody]AnalyzeRequestModel model)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState.Values);
        }

        var data = new AnalyzeViewModel
        {
            CharCount = _textAnalyticsService.GetNumberOfCharacters(model.Text),
            WordCount = _textAnalyticsService.GetNumberOfWords(model.Text),
            SentenceCount = _textAnalyticsService.GetNumberOfSentences(model.Text),
            MostFrequentWord = _textAnalyticsService.GetWordWithFrequency(model.Text),
            LongestWord = _textAnalyticsService.GetLongestWordWithLength(model.Text)
        };
        
        return Ok(data);
    }
    
    [HttpPost("/similarities")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(AnalyzeViewModel))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(string))]
    public IActionResult GetSimilarities([FromBody] SimilarityRequestModel model)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState.Values);
        }

        var data = new SimilarityViewModel()
        {
            Similarity = _textAnalyticsService.CalculateSimilarities(model.Text1, model.Text2)
        };
        
        return Ok(data);
    }
}