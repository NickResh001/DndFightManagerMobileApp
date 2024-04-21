using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DndFightManagerMobileApp.ViewModels
{
    public partial class CreateEditBeastNoteDamageViewModel : BaseViewModelHandNavigation
    {
        [ObservableProperty] private string _header;

        public CreateEditBeastNoteDamageViewModel()
        {
            Header = "Damage";
        }
        public override void OnNavigate(object parameter)
        {
            //throw new NotImplementedException();
        }
    }
}
