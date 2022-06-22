using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using InstaPrep.Models;
using InstaPrep.Views;

namespace InstaPrep.ViewModels
{
    public class RecipesViewModel : BaseViewModel
    {
        private Recipe _selectedItem;

        public ObservableCollection<Recipe> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get;  }
        public Command<Recipe> ItemTapped { get; }
        private ObservableCollection<RecipeCategory> categories;

        public ObservableCollection<RecipeCategory> Categories
        {
            get => categories;
            set => SetProperty(ref categories, value);
        }

        public RecipesViewModel()
        {
            Title = "Recipe";
            Items = new ObservableCollection<Recipe>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Recipe>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);

            LoadCategories();
        }

        void LoadCategories()
        {
            Categories = new ObservableCollection<RecipeCategory>()
            {
                new RecipeCategory()
                {
                    Name = "All"
                },
                new RecipeCategory()
                {
                    Name = "Dinner"
                },
                new RecipeCategory()
                {
                    Name = "Lunch"
                },
                new RecipeCategory()
                {
                    Name = "Breakfast"
                },
                new RecipeCategory()
                {
                    Name = "Dessert"
                }
            };
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Recipe SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewRecipePage));
        }

        async void OnItemSelected(Recipe item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(RecipeDetailPage)}?{nameof(RecipeDetailViewModel.RecipeId)}={item.Id}");
        }
    }
}
