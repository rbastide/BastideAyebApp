using BastideAyebApp.Messages;
using BastideAyebApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Maui.Media; // Nécessaire pour MediaPicker

namespace BastideAyebApp.ViewModels;

public partial class AddCardViewModel : ObservableObject
{
    [ObservableProperty]
    private string titre;

    [ObservableProperty]
    private string description;

    [ObservableProperty]
    private string image;

    [RelayCommand]
    private async Task TakePhotoAsync()
    {
        if (MediaPicker.Default.IsCaptureSupported)
        {
            var photo = await MediaPicker.Default.CapturePhotoAsync();
            
            if (photo != null)
            {
                Image = photo.FullPath;
            }
        }
        else
        {
            await Application.Current.MainPage.DisplayAlert("Erreur", "Votre appareil ne supporte pas la prise de photo.", "OK");
        }
    }

    [RelayCommand]
    private async Task PickPhotoAsync()
    {
        var photo = await MediaPicker.Default.PickPhotoAsync();
        
        if (photo != null)
        {
            Image = photo.FullPath;
        }
    }

    [RelayCommand]
    private async Task AddCardAsync()
    {
        if (string.IsNullOrWhiteSpace(Titre) || string.IsNullOrWhiteSpace(Description))
        {
            await Application.Current.MainPage.DisplayAlert("Erreur", "Titre et description requis.", "OK");
            return;
        }

        var newCard = new CardModels
        {
            Value = Titre,        
            Suit = Description,   
            Image = string.IsNullOrWhiteSpace(Image) ? "add.png" : Image 
        };

        WeakReferenceMessenger.Default.Send(new AddCardMessage(newCard));

        await Application.Current.MainPage.DisplayAlert("Succès", "La carte a été ajoutée !", "OK");
        
        // Réinitialisation
        Titre = string.Empty;
        Description = string.Empty;
        Image = string.Empty;
    }
}