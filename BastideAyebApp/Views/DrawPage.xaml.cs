using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BastideAyebApp.ViewModels;

namespace BastideAyebApp;

public partial class DrawPage : ContentPage
{
    public DrawPage(DrawViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}