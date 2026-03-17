using System.Text.Json.Serialization;

namespace BastideAyebApp.Models;

public class CardModels
{
    [JsonPropertyName("code")]
    public string Code { get; set; }

    [JsonPropertyName("image")]
    public string Image { get; set; }

    [JsonPropertyName("value")]
    public string Value { get; set; }

    [JsonPropertyName("suit")]
    public string Suit { get; set; }
    
}

public class DeckResponse
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("cards")]
    public List<CardModels> Cards { get; set; }
}