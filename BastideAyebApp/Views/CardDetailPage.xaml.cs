using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BastideAyebApp.ViewModels;

namespace BastideAyebApp.Views;

public partial class CardDetailPage : ContentPage
{
    public CardDetailPage(CardDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}