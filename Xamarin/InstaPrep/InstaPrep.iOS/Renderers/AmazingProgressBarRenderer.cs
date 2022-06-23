using System;
using InstaPrep.iOS.Renderers;
using InstaPrep.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(AmazingProgressBar), typeof(AmazingProgressBarRenderer))]
namespace InstaPrep.iOS.Renderers
{
    public class AmazingProgressBarRenderer : ProgressBarRenderer
    {
        public Animation PulseInAnimation;
        public Animation PulseOutAnimation;

        protected override void OnElementChanged(ElementChangedEventArgs<ProgressBar> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                if (PulseInAnimation is null)
                {
                    PulseInAnimation = new Animation(v =>
                        Control.ProgressTintColor = Control.ProgressTintColor.ColorWithAlpha((float)v), 0, 1);

                    PulseOutAnimation = new Animation(v =>
                        Control.ProgressTintColor = Control.ProgressTintColor.ColorWithAlpha((float)v), 1, 0);

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

