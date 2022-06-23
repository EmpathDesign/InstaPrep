using System;
using System.ComponentModel;
using System.Linq;
using CoreGraphics;
using InstaPrep.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("InstaPrepApp")]
[assembly: ExportEffect(typeof(SearchBarEffect), nameof(SearchBarEffect))]
namespace InstaPrep.iOS
{
	public class SearchBarEffect : PlatformEffect
    {
        UIColor backgroundColor;

        private UISearchBar NativeSearchBar => (UISearchBar)Control;
        private SearchBar XamarinSearchBar => (SearchBar)Element;

        protected override void OnAttached()
        {
            try
            {
                var effect = (InstaPrep.Effects.SearchBarEffect)Element.Effects.FirstOrDefault(e => e is InstaPrep.Effects.SearchBarEffect);
                if (effect != null)
                {
                    if (UIDevice.CurrentDevice.CheckSystemVersion(13, 0))
                        NativeSearchBar.SearchTextField.BackgroundColor = effect.SearchBackgroundColor.ToUIColor();

                    NativeSearchBar.SearchBarStyle = UISearchBarStyle.Prominent;
                    NativeSearchBar.Layer.ShadowColor = effect.ShadowColor.ToCGColor();
                    NativeSearchBar.Layer.ShadowRadius = effect.ShadowRadius;
                    NativeSearchBar.Layer.ShadowOffset = new CGSize(effect.ShadowDistanceX, effect.ShadowDistanceY);
                    NativeSearchBar.Layer.ShadowOpacity = effect.ShadowUnfocusOpacity;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }

        protected override void OnDetached()
        {
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);

            try
            {
                if (args.PropertyName == "IsFocused")
                {
                    var effect = (InstaPrep.Effects.SearchBarEffect)Element.Effects.FirstOrDefault(e => e is InstaPrep.Effects.SearchBarEffect);
                    if (effect != null)
                    {
                        if (NativeSearchBar.Layer.ShadowOpacity == effect.ShadowUnfocusOpacity)
                        {
                            NativeSearchBar.Layer.ShadowOpacity = effect.ShadowFocusOpacity;
                        }
                        else
                        {
                            NativeSearchBar.Layer.ShadowOpacity = effect.ShadowUnfocusOpacity;
                        }
                    }
               
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }
    }
}

