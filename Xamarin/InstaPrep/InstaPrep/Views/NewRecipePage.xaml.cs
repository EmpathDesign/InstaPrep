using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using InstaPrep.Models;
using InstaPrep.ViewModels;

namespace InstaPrep.Views
{
    public partial class NewRecipePage : ContentPage
    {
        public Recipe Item { get; set; }

        public NewRecipePage()
        {
            InitializeComponent();
            BindingContext = new NewRecipeViewModel();
        }
    }
}
