namespace BastideAyebApp.Views;

public partial class CoinFlipPage : ContentPage
{
    private readonly Random _random = new();
    private int _pileCount = 0;
    private int _faceCount = 0;

    public CoinFlipPage()
    {
        InitializeComponent();
    }

    private async void OnCoinFlipClicked(object sender, EventArgs e)
    {
        CoinResultLabel.Text = "🪙";
        CoinTextLabel.Text = "...";

        await CoinResultLabel.RotateYTo(1800, 800, Easing.CubicOut);
        CoinResultLabel.RotationY = 0;

        bool isPile = _random.Next(2) == 0;

        if (isPile)
        {
            _pileCount++;
            CoinResultLabel.Text = "🟡";
            CoinTextLabel.Text = "PILE !";
            CoinTextLabel.TextColor = Colors.Gold;
        }
        else
        {
            _faceCount++;
            CoinResultLabel.Text = "🔵";
            CoinTextLabel.Text = "FACE !";
            CoinTextLabel.TextColor = Colors.LightBlue;
        }

        PileScoreLabel.Text = $"Pile : {_pileCount}";
        FaceScoreLabel.Text = $"Face : {_faceCount}";
    }
}