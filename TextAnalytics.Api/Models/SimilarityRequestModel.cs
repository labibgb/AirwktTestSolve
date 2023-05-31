using System.ComponentModel.DataAnnotations;

namespace TextAnalytics.Api.Models;

public class SimilarityRequestModel
{
    [Required]
    public string Text1 { get; set; }
    [Required]
    public string Text2 { get; set; }
}