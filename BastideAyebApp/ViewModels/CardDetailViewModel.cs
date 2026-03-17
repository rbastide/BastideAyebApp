using BastideAyebApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BastideAyebApp.ViewModels;


[QueryProperty(nameof(Card),"Card")]
public partial class CardDetailViewModel : ObservableObject
{

    [ObservableProperty] 
    private CardModels card;

}