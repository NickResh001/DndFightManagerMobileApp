using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DndFightManagerMobileApp.ViewModels
{
    public partial class CreateEditBeastNoteStatsViewModel : BaseViewModel
    {
        public CreateEditBeastNoteStatsViewModel() { }

        [RelayCommand]
        private async Task NavigateBackTo(object parameter)
        {
            await Shell.Current.GoToAsync($"..");
        }
    }
}
