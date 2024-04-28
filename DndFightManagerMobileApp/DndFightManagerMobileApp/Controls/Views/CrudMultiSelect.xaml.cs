using DndFightManagerMobileApp.Controls.ViewModels;
using DndFightManagerMobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DndFightManagerMobileApp.Controls.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CrudMultiSelect : ContentView
    {
        public static readonly BindableProperty MultiSelectVMProperty = BindableProperty.Create(
            nameof(MultiSelectVM),
            typeof(CrudMultiSelectVM),
            typeof(OneCrudField),
            null);

        public CrudMultiSelectVM MultiSelectVM
        {
            get => (CrudMultiSelectVM)GetValue(MultiSelectVMProperty);
            set => SetValue(MultiSelectVMProperty, value);
        }

        public CrudMultiSelect()
        {
            InitializeComponent();
        }
    }
}