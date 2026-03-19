using BastideAyebApp.Views;

namespace BastideAyebApp;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
    }
    
    private void LoadCarouselData()
    {
        var suits = new List<SuitInfo>
        {
            new SuitInfo { Symbol = "♠️", Name = "Pique",   Description = "L'enseigne de la sagesse et de la mort" },
            new SuitInfo { Symbol = "♥️", Name = "Cœur",    Description = "L'enseigne de l'amour et du clergé" },
            new SuitInfo { Symbol = "♦️", Name = "Carreau", Description = "L'enseigne de la richesse et des marchands" },
            new SuitInfo { Symbol = "♣️", Name = "Trèfle",  Description = "L'enseigne de la chance et de l'agriculture" }
        };

        SuitCarousel.ItemsSource = suits;
        SuitCarousel.IndicatorView = SuitIndicator;
    }

    private async void OnShowGifClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(GifPage));
    }
    
}

public class SuitInfo
{
    public string Symbol { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}