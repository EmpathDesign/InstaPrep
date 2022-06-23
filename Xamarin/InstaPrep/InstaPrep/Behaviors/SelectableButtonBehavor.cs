using System;
using System.Windows.Input;
using InstaPrep.Models;
using Xamarin.Forms;

namespace InstaPrep.Behaviors
{
	public class SelectableButtonBehavorBehavior : Behavior<Button>
    {
        // Command trigger when button is clicked
        public static readonly BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(ICommand), typeof(SelectableButtonBehavorBehavior), null);
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        // Selected button indentifier
        public static readonly BindableProperty SelectedIdentifierProperty = BindableProperty.Create("SelectedIdentifier", typeof(object), typeof(SelectableButtonBehavorBehavior), null, BindingMode.OneTime, propertyChanged: (b, o, n) =>
        {
            var behavor = (SelectableButtonBehavorBehavior)b;
            behavor.CheckIfCurrent();
        });

        public object SelectedIdentifier
        {
            get { return GetValue(SelectedIdentifierProperty); }
            set
            {
                SetValue(SelectedIdentifierProperty, value);
            }
        }

        // Current button indentifier
        public static readonly BindableProperty CurrentIdentifierProperty = BindableProperty.Create("CurrentIdentifier", typeof(object), typeof(SelectableButtonBehavorBehavior), null, BindingMode.OneTime, propertyChanged: (b, o, n) =>
        {
            var behavor = (SelectableButtonBehavorBehavior)b;
            behavor.CheckIfCurrent();
        });

        public object CurrentIdentifier
        {
            get { return GetValue(CurrentIdentifierProperty); }
            set { SetValue(CurrentIdentifierProperty, value); }
        }


        public static readonly BindableProperty SelectedColorProperty = BindableProperty.Create("SelectedColor", typeof(Color), typeof(SelectableButtonBehavorBehavior), Color.Red, BindingMode.OneTime, propertyChanged: (b, o, n) =>
        {
            var behavor = (SelectableButtonBehavorBehavior)b;
            behavor.CheckIfCurrent();

        });

        public Color SelectedColor
        {
            get { return (Color)GetValue(SelectedColorProperty); }
            set { SetValue(SelectedColorProperty, value); }
        }

        public static readonly BindableProperty UnSelectedColorProperty = BindableProperty.Create("UnSelectedColor", typeof(Color), typeof(SelectableButtonBehavorBehavior), Color.LightGray, BindingMode.OneTime, propertyChanged: (b, o, n) =>
        {
            var behavor = (SelectableButtonBehavorBehavior)b;
            behavor.CheckIfCurrent();
        });

        public Color UnSelectedColor
        {
            get { return (Color)GetValue(UnSelectedColorProperty); }
            set { SetValue(UnSelectedColorProperty, value); }
        }

        public Button SelectableButton { get; private set; }


        protected override void OnAttachedTo(Button bindable)
        {
            SelectableButton = bindable;

            if (bindable.BindingContext != null)
            {
                BindingContext = bindable.BindingContext;
            }

            bindable.BindingContextChanged += OnBindingContextChanged;
            bindable.Clicked += OnClicked;
            SelectableButton.Background = UnSelectedColor;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Button bindable)
        {
            bindable.Clicked -= OnClicked;
            bindable.BindingContextChanged -= OnBindingContextChanged;
            bindable = null;
            base.OnDetachingFrom(bindable);
        }

        void OnBindingContextChanged(object sender, EventArgs e)
        {
            OnBindingContextChanged();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            BindingContext = SelectableButton.BindingContext;
        }

        /// <summary>
        /// Triggered when button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void OnClicked(object sender, EventArgs args)
        {
            if (Command == null)
            {
                return;
            }

            if (Command.CanExecute(CurrentIdentifier))
            {
                Command.Execute(CurrentIdentifier);
            }
        }

        /// <summary>
        /// Check if current button is the selected button. Called when Selected Identifier changes
        /// </summary>
        void CheckIfCurrent()
        {
            if (SelectableButton == null)
                return;

            if (CurrentIdentifier.Equals(SelectedIdentifier))
            {
                SelectableButton.Background = SelectedColor;
            }
            else
            {
                SelectableButton.Background = UnSelectedColor;
            }
               
        }
    }
}

