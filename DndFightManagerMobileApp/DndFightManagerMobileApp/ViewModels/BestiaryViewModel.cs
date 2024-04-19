using CommunityToolkit.Mvvm.Input;
using DndFightManagerMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DndFightManagerMobileApp.ViewModels
{
    public partial class BestiaryViewModel : BaseViewModel
    {
        public BestiaryViewModel() { }
        
        [RelayCommand]
        private async Task NavigateToCreateEditBeastNoteStats(object parameter)
        {
            await Shell.Current.GoToAsync($"{nameof(CreateEditBeastNoteStatsPage)}");
        }
    }
}
