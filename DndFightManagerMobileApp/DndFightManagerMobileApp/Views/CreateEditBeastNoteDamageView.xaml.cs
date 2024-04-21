using DndFightManagerMobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DndFightManagerMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateEditBeastNoteDamageView : ContentView
    {
        public static BaseViewModelHandNavigation _vm = new CreateEditBeastNoteDamageViewModel();
        public CreateEditBeastNoteDamageView()
        {
            InitializeComponent();
            BindingContext = _vm;
        }
    }
}