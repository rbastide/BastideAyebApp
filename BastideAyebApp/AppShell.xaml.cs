using BastideAyebApp.Views;

namespace BastideAyebApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        
        Routing.RegisterRoute(nameof(DrawPage), typeof(DrawPage));
        Routing.RegisterRoute(nameof(CardDetailPage), typeof(CardDetailPage));
    }
}