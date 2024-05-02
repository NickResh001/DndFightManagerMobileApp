using DndFightManagerMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DndFightManagerMobileApp.Controls.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OneCrudPicker : ContentView
    {
        public static readonly BindableProperty HeaderTextProperty = BindableProperty.Create(
            nameof(HeaderText),
            typeof(string),
            typeof(OneCrudPicker),
            string.Empty);

        public static readonly BindableProperty InfoCommandProperty = BindableProperty.Create(
            nameof(InfoCommand),
            typeof(Command),
            typeof(OneCrudPicker),
            null);

        public static readonly BindableProperty InfoCommandParameterProperty = BindableProperty.Create(
            nameof(InfoCommandParameter),
            typeof(string),
            typeof(OneCrudPicker),
            string.Empty);

        public static readonly BindableProperty ItemsForPickerProperty = BindableProperty.Create(
            nameof(ItemsForPicker),
            typeof(object),
            typeof(OneCrudPicker),
            null);

        public static readonly BindableProperty PickerSelectedItemProperty = BindableProperty.Create(
            nameof(PickerSelectedItem),
            typeof(object),
            typeof(OneCrudPicker),
            null);

        public static readonly BindableProperty PickerSelectedItemTitleProperty = BindableProperty.Create(
            nameof(PickerSelectedItemTitle),
            typeof(string),
            typeof(OneCrudPicker),
            null);

        public string HeaderText
        {
            get => (string)GetValue(HeaderTextProperty);
            set => SetValue(HeaderTextProperty, value);
        }
        public object ItemsForPicker
        {
            get => (object)GetValue(ItemsForPickerProperty);
            set => SetValue(ItemsForPickerProperty, value);
        }
        public object PickerSelectedItem
        {
            get => (object)GetValue(PickerSelectedItemProperty);
            set => SetValue(PickerSelectedItemProperty, value);
        }
        public string PickerSelectedItemTitle
        {
            get => (string)GetValue(PickerSelectedItemTitleProperty);
            set => SetValue(PickerSelectedItemTitleProperty, value);
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

        public OneCrudPicker()
        {
            InitializeComponent();
        }
    }
}