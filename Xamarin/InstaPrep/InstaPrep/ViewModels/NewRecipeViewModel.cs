using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using InstaPrep.Models;
using Xamarin.Forms;

namespace InstaPrep.ViewModels
{
    public class NewRecipeViewModel : BaseViewModel
    {
        private string text;
        private string description;

        public NewRecipeViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged += 
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(text)
                && !String.IsNullOrWhiteSpace(description);
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Recipe newItem = new Recipe()
            {
                Id = Guid.NewGuid().ToString(),
                Title = Text,
                Description = Description
            };
            
            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}

