using DndFightManagerMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DndFightManagerMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(BestiaryPage), typeof(BestiaryPage));
            Routing.RegisterRoute(nameof(CreateEditBeastNoteMainPage), typeof(CreateEditBeastNoteMainPage));
            Routing.RegisterRoute(nameof(CreateEditBeastNoteActionsCRUDPage), typeof(CreateEditBeastNoteActionsCRUDPage));
        }
    }
}