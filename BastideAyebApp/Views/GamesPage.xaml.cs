namespace BastideAyebApp.Views;

public partial class GamesPage : ContentPage
{
    public GamesPage()
    {
        InitializeComponent();
    }

    private async void OnCoinFlipClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(CoinFlipPage));
    }

    private async void OnNumberGuessClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(NumberGuessPage));
    }
}