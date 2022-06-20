using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using InstaPrep.Models;
using InstaPrep.Views;
using InstaPrep.ViewModels;

namespace InstaPrep.Views
{
    public partial class RecipesPage : ContentPage
    {
        RecipesViewModel _viewModel;

        public RecipesPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new RecipesViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}
