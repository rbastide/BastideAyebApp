using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BastideAyebApp.Models;

public class CardModels
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [JsonPropertyName("code")]
    public string Code { get; set; }

    [JsonPropertyName("image")]
    public string Image { get; set; }

    [JsonPropertyName("value")]
    public string Value { get; set; }

    [JsonPropertyName("suit")]
    public string Suit { get; set; }
    
    public DateTime SavedAt { get; set; } = DateTime.Now;
    
}

public class DeckResponse
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("cards")]
    public List<CardModels> Cards { get; set; }
}