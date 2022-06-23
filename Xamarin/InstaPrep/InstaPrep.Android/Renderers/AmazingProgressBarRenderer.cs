using System;
using Android.Content;
using Android.OS;
using InstaPrep.Droid.Renderers;
using InstaPrep.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(AmazingProgressBar), typeof(AmazingProgressBarRenderer))]
namespace InstaPrep.Droid.Renderers
{
    public class AmazingProgressBarRenderer : ProgressBarRenderer
    {
        public Animation PulseInAnimation;
        public Animation PulseOutAnimation;

        public AmazingProgressBarRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<ProgressBar> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                if (PulseInAnimation is null)
                {

                    Color color = Element.ProgressColor;

                    PulseInAnimation = new Animation(v =>
                        Control.ProgressTintList = Android.Content.Res.ColorStateList.ValueOf(color.MultiplyAlpha(v).ToAndroid()),0,1);

                    PulseOutAnimation = new Animation(v =>
                        Control.ProgressTintList = Android.Content.Res.ColorStateList.ValueOf(color.MultiplyAlpha(v).ToAndroid()), 1, 0);

                    Action pulseInAnimation, pulseOutAnimation = new Action(() => { });

                    pulseInAnimation = () => PulseInAnimation.Commit(
                        owner: Element,
                        name:"SimpleAnimation",
                        rate: 16,
                        length: 2000,
                        easing: Easing.Linear,
                        finished: (v, c) => pulseOutAnimation.Invoke(),
                        repeat: () => false);

                    pulseOutAnimation = () => PulseOutAnimation.Commit(
                        owner: Element,
                        name: "SimpleAnimation",
                        rate: 16,
                        length: 2000,
                        easing: Easing.Linear,
                        finished: (v, c) => pulseInAnimation.Invoke(),
                        repeat: () => false);

                    pulseInAnimation.Invoke();
                }

            }
        }
    }
}

