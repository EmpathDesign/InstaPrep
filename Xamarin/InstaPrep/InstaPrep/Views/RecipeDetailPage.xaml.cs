using System.ComponentModel;
using Xamarin.Forms;
using InstaPrep.ViewModels;

namespace InstaPrep.Views
{
    public partial class RecipeDetailPage : ContentPage
    {
        public RecipeDetailPage()
        {
            InitializeComponent();
            BindingContext = new RecipeDetailViewModel();
        }
    }
}
