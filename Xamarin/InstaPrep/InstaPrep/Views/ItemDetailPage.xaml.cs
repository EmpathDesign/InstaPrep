using System.ComponentModel;
using Xamarin.Forms;
using InstaPrep.ViewModels;

namespace InstaPrep.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
