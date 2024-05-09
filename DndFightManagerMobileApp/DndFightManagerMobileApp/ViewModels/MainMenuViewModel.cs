using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using DndFightManagerMobileApp.Views;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using DndFightManagerMobileApp.Utils;

namespace DndFightManagerMobileApp.ViewModels
{
    public partial class MainMenuViewModel : BaseViewModel
    {
        public MainMenuViewModel()
        {

        }

        [RelayCommand]
        private async Task NavigateToBestiary(object parameter)
        {
            await Shell.Current.GoToAsync($"{nameof(BestiaryPage)}");
        }
    }
}
