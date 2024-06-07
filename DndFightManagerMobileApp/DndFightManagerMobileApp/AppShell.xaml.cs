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
            Routing.RegisterRoute(nameof(BeastNoteWatchingPage), typeof(BeastNoteWatchingPage));
            Routing.RegisterRoute(nameof(ScenesListMainPage), typeof(ScenesListMainPage));
            Routing.RegisterRoute(nameof(SceneSavesListPage), typeof(SceneSavesListPage));
            Routing.RegisterRoute(nameof(ManagerListPage), typeof(ManagerListPage));
            Routing.RegisterRoute(nameof(ManagerCRUDMainPage), typeof(ManagerCRUDMainPage));

            Routing.RegisterRoute(nameof(RegistrationPage), typeof(RegistrationPage));
            Routing.RegisterRoute(nameof(AuthorisationPage), typeof(AuthorisationPage));
            Routing.RegisterRoute(nameof(BeastStatblockHitsView), typeof(BeastStatblockHitsView));
            Routing.RegisterRoute(nameof(BeastStatblockAbilitiesView), typeof(BeastStatblockAbilitiesView));
            Routing.RegisterRoute(nameof(BeastStatblockActionsView), typeof(BeastStatblockActionsView));
            Routing.RegisterRoute(nameof(BeastActionViewPage), typeof(BeastActionViewPage));
            Routing.RegisterRoute(nameof(BeastActionReadyPage), typeof(BeastActionReadyPage));
            Routing.RegisterRoute(nameof(BeastMultiactionViewPage), typeof(BeastMultiactionViewPage));

        }
    }
}