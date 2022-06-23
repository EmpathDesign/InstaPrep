using System;
using System.Threading.Tasks;
using Android.Content;
using AndroidX.Core.Content;
using InstaPrep.DeviceServices;
using InstaPrep.Droid.DeviceServices;
using Xamarin.Forms;

[assembly: Dependency(typeof(Share))]
namespace InstaPrep.Droid.DeviceServices
{
    public class Share : IShare
    {
        public Task Show(string title, string message, string filePath)
        {
            var intent = new Intent(Intent.ActionSend);
            intent.SetType("application/pdf");
            var fileUri = FileProvider.GetUriForFile(Forms.Context.ApplicationContext, "com.empathdesign.instaprep", new Java.IO.File(filePath));

            intent.PutExtra(Intent.ExtraStream, fileUri);
            intent.PutExtra(Intent.ExtraTitle, title);
            intent.PutExtra(Intent.ExtraText, message);

            var chooser = Intent.CreateChooser(intent, title);
            chooser.SetFlags(ActivityFlags.GrantReadUriPermission);
            Android.App.Application.Context.StartActivity(chooser);

            return Task.FromResult(true);
        }
    }
}

