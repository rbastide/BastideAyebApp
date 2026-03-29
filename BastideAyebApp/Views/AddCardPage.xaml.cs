using BastideAyebApp.ViewModels;

namespace BastideAyebApp.Views;

public partial class AddCardPage : ContentPage
{
    public AddCardPage(AddCardViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}