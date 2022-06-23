using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;

using Xamarin.Forms;

using InstaPrep.Models;
using InstaPrep.Views;

namespace InstaPrep.ViewModels
{
    public class RecipesViewModel : BaseViewModel
    {

        public ObservableCollection<Recipe> AllRecipes { get; }

        private Recipe _selectedItem;

        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get;  }
        public Command<Recipe> ItemTapped { get; }
        public Command<string> SearchTextChanged { get; }

        public Command<string> CategoryChanged { get; }

        private ObservableCollection<Recipe> filterRecipes;
        public ObservableCollection<Recipe> FilteredRecipes
        {
            get => filterRecipes;
            set => SetProperty(ref filterRecipes, value);
        }

        private ObservableCollection<RecipeCategory> categories;
        public ObservableCollection<RecipeCategory> Categories
        {
            get => categories;
            set => SetProperty(ref categories, value);
        }

        private RecipeCategory selectedCategory;
        public RecipeCategory SelectedCategory
        {
            get => selectedCategory;
            set => SetProperty(ref selectedCategory, value);
        }

        public RecipesViewModel()
        {
            Title = "Recipe";
            AllRecipes = new ObservableCollection<Recipe>();
            FilteredRecipes = new ObservableCollection<Recipe>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Recipe>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);

            SearchTextChanged = new Command<string>(async (searchTerm) => await SearchRecipes(searchTerm));

            CategoryChanged = new Command<string>((categoryChanged) => FilterByCategory(categoryChanged));

            LoadCategories();
        }

        private void FilterByCategory(string categoryChanged)
        {
            SelectedCategory = categories.FirstOrDefault(a => a.Id == categoryChanged);

        }

        private async Task SearchRecipes(object searchTerm)
        {
            string term = searchTerm as string;

            if (!string.IsNullOrEmpty(term))
                FilteredRecipes = new ObservableCollection<Recipe>(FilteredRecipes.Where(item => item.Title.ToLower().Contains(term.ToLower())));
            else
            {
                await ExecuteLoadItemsCommand();
            }
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
                AllRecipes.Clear();
                FilteredRecipes.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    AllRecipes.Add(item);
                    FilteredRecipes.Add(item);
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
