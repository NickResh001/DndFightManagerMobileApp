using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DndFightManagerMobileApp.Controls.Views
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

        public static readonly BindableProperty EntryMaxLengthProperty = BindableProperty.Create(
            nameof(EntryMaxLength),
            typeof(int),
            typeof(OneCrudField),
            50);

        public static readonly BindableProperty InfoCommandProperty = BindableProperty.Create(
            nameof(InfoCommand),
            typeof(Command),
            typeof(OneCrudField),
            null);

        public static readonly BindableProperty InfoCommandParameterProperty = BindableProperty.Create(
            nameof(InfoCommandParameter),
            typeof(string),
            typeof(OneCrudField),
            string.Empty);

        public static readonly BindableProperty AutoValueCommandProperty = BindableProperty.Create(
            nameof(AutoValueCommand),
            typeof(Command),
            typeof(OneCrudField),
            null);

        public static readonly BindableProperty EntryUnfocusedCommandProperty = BindableProperty.Create(
            nameof(EntryUnfocusedCommand),
            typeof(Command),
            typeof(OneCrudField),
            null);

        public static readonly BindableProperty EntryUnfocusedCommandParameterProperty = BindableProperty.Create(
            nameof(EntryUnfocusedCommandParameter),
            typeof(string),
            typeof(OneCrudField),
            string.Empty);

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
        public int EntryMaxLength
        {
            get => (int)GetValue(EntryMaxLengthProperty);
            set => SetValue(EntryMaxLengthProperty, value);
        }
        public Command InfoCommand
        {
            get => (Command)GetValue(InfoCommandProperty);
            set => SetValue(InfoCommandProperty, value);
        }
        public string InfoCommandParameter
        {
            get => (string)GetValue(InfoCommandParameterProperty);
            set => SetValue(InfoCommandParameterProperty, value);
        }
        public Command AutoValueCommand
        {
            get => (Command)GetValue(AutoValueCommandProperty);
            set 
            { 
                SetValue(AutoValueCommandProperty, value); 
            }
        }
        public Command EntryUnfocusedCommand
        {
            get => (Command)GetValue(EntryUnfocusedCommandProperty);
            set => SetValue(EntryUnfocusedCommandProperty, value);
        }
        public string EntryUnfocusedCommandParameter
        {
            get => (string)GetValue(EntryUnfocusedCommandParameterProperty);
            set => SetValue(EntryUnfocusedCommandParameterProperty, value);
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