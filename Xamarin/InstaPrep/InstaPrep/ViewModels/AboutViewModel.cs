using System;
using System.Windows.Input;
using InstaPrep.DeviceServices;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace InstaPrep.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () =>
            {
                IShare shareDependency = DependencyService.Get<IShare>();
                await Browser.OpenAsync("https://adamlepley.io/assets/pdf/adam_resume.pdf");


                //await shareDependency.Show("Adam Lepley Resume.pdf", "adam_resume.pdf");
            });
        }

        public ICommand OpenWebCommand { get; }
    }
}
