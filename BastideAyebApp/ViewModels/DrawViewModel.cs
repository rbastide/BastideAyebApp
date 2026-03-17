using System.Collections.ObjectModel;
using BastideAyebApp.Models;
using BastideAyebApp.Services;
using BastideAyebApp.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BastideAyebApp.ViewModels;

public partial class DrawViewModel : ObservableObject{
    private readonly CardService _cardService;

    // ObservableProperty génère automatiquement la propriété publique 'Cards' pour le XAML
    [ObservableProperty]
    private ObservableCollection<CardModels> cards;

    // On injecte notre CardService via le constructeur
    public DrawViewModel(CardService cardService)
    {
        _cardService = cardService;
        Cards = new ObservableCollection<CardModels>();
    }

    // RelayCommand génère automatiquement 'LoadCardsCommand' pour notre bouton
    [RelayCommand]
    public async Task LoadCardsAsync()
    {
        // On récupère 10 cartes depuis l'API
        var drawnCards = await _cardService.GetCardsAsync(10);
        
        Cards.Clear();
        foreach (var card in drawnCards)
        {
            Cards.Add(card);
        }
    }

    [RelayCommand]
    public async Task GoToDetailsAsync(CardModels selectedCard)
    {
        if (selectedCard == null)
            return;

        var navigationParameter = new Dictionary<string, object>()
        {
            { "Card", selectedCard }
        };

        await Shell.Current.GoToAsync(nameof(CardDetailPage), navigationParameter);

    }
    
    
}