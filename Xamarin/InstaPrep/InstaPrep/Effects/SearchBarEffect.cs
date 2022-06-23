using System;
using Xamarin.Forms;
namespace InstaPrep.Effects
{
	public class SearchBarEffect : RoutingEffect
    {
        public float ShadowRadius { get; set; }

        public Color ShadowColor { get; set; }

        public float ShadowDistanceX { get; set; }

        public float ShadowDistanceY { get; set; }

        public float ShadowFocusOpacity { get; set; }

        public float ShadowUnfocusOpacity { get; set; }

        public Color SearchBackgroundColor { get; set; }

        public SearchBarEffect() : base("InstaPrepApp.SearchBarEffect")
        {
        
        }
	}
}

