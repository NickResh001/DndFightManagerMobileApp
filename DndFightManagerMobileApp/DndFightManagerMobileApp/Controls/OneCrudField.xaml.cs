using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DndFightManagerMobileApp.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OneCrudField : ContentView
    {
        public static readonly BindableProperty HeaderTextProperty = BindableProperty.Create(
            nameof(HeaderText),
            typeof(string),
            typeof(OneCrudField),
            string.Empty);

        public static readonly BindableProperty EntryTextProperty = BindableProperty.Create(
            nameof(EntryText),
            typeof(string),
            typeof(OneCrudField),
            string.Empty);

        public static readonly BindableProperty InfoCommandProperty = BindableProperty.Create(
            nameof(InfoCommand),
            typeof(Command),
            typeof(OneCrudField),
            null);

        public static readonly BindableProperty AutoValueCommandProperty = BindableProperty.Create(
            nameof(AutoValueCommand),
            typeof(Command),
            typeof(OneCrudField),
            null);

        public static readonly BindableProperty IsAutoValueButtonVisibleProperty = BindableProperty.Create(
            nameof(IsAutoValueButtonVisible),
            typeof(bool),
            typeof(OneCrudField),
            false);

        public string HeaderText
        {
            get => (string)GetValue(HeaderTextProperty);
            set => SetValue(HeaderTextProperty, value);
        }
        public string EntryText
        {
            get => (string)GetValue(EntryTextProperty);
            set => SetValue(EntryTextProperty, value);
        }
        public Command InfoCommand
        {
            get => (Command)GetValue(InfoCommandProperty);
            set => SetValue(InfoCommandProperty, value);
        }
        public Command AutoValueCommand
        {
            get => (Command)GetValue(AutoValueCommandProperty);
            set => SetValue(AutoValueCommandProperty, value);
        }
        public bool IsAutoValueButtonVisible
        {
            get => (bool)GetValue(IsAutoValueButtonVisibleProperty);
            set => SetValue(IsAutoValueButtonVisibleProperty, value);
        }

        public OneCrudField()
        {
            InitializeComponent();
        }
    }
}