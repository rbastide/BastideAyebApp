namespace BastideAyebApp.Views;

public partial class NumberGuessPage : ContentPage
{
    private readonly Random _random = new();
    private int _secretNumber;
    private int _attempts;

    public NumberGuessPage()
    {
        InitializeComponent();
        StartNewGame();
    }

    private void StartNewGame()
    {
        _secretNumber = _random.Next(1, 101);
        _attempts = 0;
        AttemptsLabel.Text = "Tentatives : 0";
        HintLabel.Text = "";
        GuessEntry.Text = "";
        GuessEntry.IsEnabled = true;
    }

    private void OnGuessClicked(object sender, EventArgs e)
    {
        if (!int.TryParse(GuessEntry.Text, out int guess) || guess < 1 || guess > 100)
        {
            HintLabel.Text = "Entrez un nombre entre 1 et 100";
            HintLabel.TextColor = Colors.Orange;
            return;
        }

        _attempts++;
        AttemptsLabel.Text = $"Tentatives : {_attempts}";
        GuessEntry.Text = "";

        if (guess < _secretNumber)
        {
            HintLabel.Text = "⬆ C'est plus !";
            HintLabel.TextColor = Colors.IndianRed;
        }
        else if (guess > _secretNumber)
        {
            HintLabel.Text = "⬇ C'est moins !";
            HintLabel.TextColor = Colors.LightBlue;
        }
        else
        {
            HintLabel.Text = $"🎉 Bravo ! C'était {_secretNumber} !\nTrouvé en {_attempts} tentatives";
            HintLabel.TextColor = Colors.Gold;
            GuessEntry.IsEnabled = false;
        }
    }

    private void OnNewGameClicked(object sender, EventArgs e)
    {
        StartNewGame();
    }
}