using System;
using System.Windows.Input;
using InstaPrep.Models;
using Xamarin.Forms;

namespace InstaPrep.Behaviors
{
	public class SelectableButtonBehavorBehavior : Behavior<Button>
    {

        public static readonly BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(ICommand), typeof(SelectableButtonBehavorBehavior), null);
        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create("CommandParameter", typeof(object), typeof(SelectableButtonBehavorBehavior), null);
        public static readonly BindableProperty CurrentIdentifierProperty = BindableProperty.Create("CurrentIdentifier", typeof(object), typeof(SelectableButtonBehavorBehavior), null);
        public static readonly BindableProperty SelectedIdentifierProperty = BindableProperty.Create("SelectedIdentifier", typeof(object), typeof(SelectableButtonBehavorBehavior), null, BindingMode.OneTime, propertyChanged: (b, o, n) =>
        {
            var behavor = (SelectableButtonBehavorBehavior)b;
            behavor.CheckIfCurrent();
        });

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public object SelectedIdentifier
        {
            get { return GetValue(SelectedIdentifierProperty); }
            set
            {
                SetValue(SelectedIdentifierProperty, value);
            }
        }

        public object CurrentIdentifier
        {
            get { return GetValue(CurrentIdentifierProperty); }
            set { SetValue(CurrentIdentifierProperty, value); }
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

        void CheckIfCurrent()
        {
            if (CurrentIdentifier.Equals(SelectedIdentifier))
            {
                SelectableButton.Background = Color.Red;
            }
            else
            {
                SelectableButton.Background = Color.Blue;
            }
               
        }
    }
}

