using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using InstaPrep.Models;
using Xamarin.Forms;

namespace InstaPrep.ViewModels
{
    [QueryProperty(nameof(RecipeId), nameof(RecipeId))]
    public class RecipeDetailViewModel : BaseViewModel
    {
        private string recipeId;
        private Recipe selectedRecipe;

        public Command BackCommand { get; }

        public Recipe SelectedRecipe
        {
            get => selectedRecipe;
            set => SetProperty(ref selectedRecipe, value);
        }

        ObservableCollection<Ingredient> recipeIngredients;
        public ObservableCollection<Ingredient> RecipeIngredients
        {
            get => recipeIngredients;
            set => SetProperty(ref recipeIngredients, value);
        }

        public string RecipeId
        {
            get
            {
                return recipeId;
            }
            set
            {
                recipeId = value;
                LoadRecipeId(value);
            }
        }

        public RecipeDetailViewModel()
        {
            BackCommand = new Command(() => Shell.Current.SendBackButtonPressed());
        }

        public async void LoadRecipeId(string itemId)
        {
            try
            {
                var recipe = await DataStore.GetItemAsync(itemId);
                SelectedRecipe = recipe;
                RecipeIngredients = recipe.Ingredients;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

    }
}

