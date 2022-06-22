using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace InstaPrep.Behaviors
{
	public class SearchTextChangedBehavior : Behavior<SearchBar>
    {

        public SearchBar SearchEntry { get; private set; }

        public static readonly BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(ICommand), typeof(SearchTextChangedBehavior), null);
        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create("CommandParameter", typeof(object), typeof(SearchTextChangedBehavior), null);


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

        protected override void OnAttachedTo(SearchBar bindable)
        {
            SearchEntry = bindable;

            if (bindable.BindingContext != null)
            {
                BindingContext = bindable.BindingContext;
            }

            bindable.BindingContextChanged += OnBindingContextChanged;
            bindable.TextChanged += OnEntryTextChangedEvent;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(SearchBar bindable)
        {
            bindable.TextChanged -= OnEntryTextChangedEvent;
            bindable.BindingContextChanged -= OnBindingContextChanged;
            bindable = null;
            base.OnDetachingFrom(bindable);
        }

        public void OnEntryTextChangedEvent(object sender, TextChangedEventArgs args)
        {
            if (Command == null)
            {
                return;
            }
            if (Command.CanExecute(args.NewTextValue))
            {
                Command.Execute(args.NewTextValue);
            }
        }

        void OnBindingContextChanged(object sender, EventArgs e)
        {
            OnBindingContextChanged();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            BindingContext = SearchEntry.BindingContext;
        }
    }
}

