using System.ComponentModel.DataAnnotations;

namespace TextAnalytics.Api.Models;

public class AnalyzeRequestModel
{
    [Required]
    public string Text { get; set; }
}