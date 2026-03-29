using System.Collections.ObjectModel;
using BastideAyebApp.Messages;
using BastideAyebApp.Models;
using BastideAyebApp.Services;
using BastideAyebApp.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace BastideAyebApp.ViewModels;

public partial class DrawViewModel : ObservableObject{
    
    private readonly CardService _cardService;
    private readonly DatabaseService _databaseService;

    [ObservableProperty]
    private ObservableCollection<CardModels> cards;

    public DrawViewModel(CardService cardService, DatabaseService databaseService)
    {
        _cardService = cardService;
        _databaseService = databaseService;
        Cards = new ObservableCollection<CardModels>();
        
        WeakReferenceMessenger.Default.Register<AddCardMessage>(this,(recipient, message) =>
            Cards.Add(message.Value));
        
        Task.Run(async () => await LoadSavedCardsAsync());
        
    }
    
    private async Task LoadSavedCardsAsync()
    {
        var savedCards = await _databaseService.GetSavedCardsAsync();
        MainThread.BeginInvokeOnMainThread(() =>
        {
            foreach (var card in savedCards)
            {
                Cards.Add(card);
            }
        });
    }

    [RelayCommand]
    public async Task LoadCardsAsync()
    {
        var drawnCards = await _cardService.GetCardsAsync(10);

        Cards.Clear();

        var savedCards = await _databaseService.GetSavedCardsAsync();
        foreach (var card in savedCards)
        {
            Cards.Add(card);
        }

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