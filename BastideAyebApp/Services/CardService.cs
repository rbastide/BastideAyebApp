using System.Net.Http.Json;
using BastideAyebApp.Models;

namespace BastideAyebApp.Services;

public class CardService
{
    
    private readonly HttpClient _httpClient;

    public CardService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<List<CardModels>> GetCardsAsync(int count = 10)
    {
        try
        {
            var url = $"https://deckofcardsapi.com/api/deck/new/draw/?count={count}";
            
            var response = await _httpClient.GetFromJsonAsync<DeckResponse>(url);

            if (response != null && response.Success)
            {
                return response.Cards;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de l'appel API : {ex.Message}");
        }

        return new List<CardModels>();
    }
    
}