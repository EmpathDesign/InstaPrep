using System;
using System.Collections.Generic;
using InstaPrep.ViewModels;
using InstaPrep.Views;
using Xamarin.Forms;

namespace InstaPrep
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(RecipeDetailPage), typeof(RecipeDetailPage));
            Routing.RegisterRoute(nameof(NewRecipePage), typeof(NewRecipePage));
        }

    }
}

