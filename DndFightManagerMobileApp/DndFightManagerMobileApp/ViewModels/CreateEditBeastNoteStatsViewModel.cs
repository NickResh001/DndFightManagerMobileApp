using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DndFightManagerMobileApp.ViewModels
{
    public partial class CreateEditBeastNoteStatsViewModel : BaseViewModelHandNavigation
    {
        [ObservableProperty] private string _header;

        public CreateEditBeastNoteStatsViewModel()
        {
            Header = "Stats";
        }

        public override void OnNavigateTo(object parameter)
        {
            //throw new NotImplementedException();
        }
    }
}
