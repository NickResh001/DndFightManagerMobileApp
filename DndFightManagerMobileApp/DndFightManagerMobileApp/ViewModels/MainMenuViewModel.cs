using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using DndFightManagerMobileApp.Views;

namespace DndFightManagerMobileApp.ViewModels
{
    public class MainMenuViewModel : BaseViewModel
    {
        public ICommand NavigateToBestiaryCommand { get; set; }

        public MainMenuViewModel()
        {
            NavigateToBestiaryCommand = new Command(NavigateToBestiary);
        }

        public void NavigateToBestiary(object parameter)
        {
            Shell.Current.GoToAsync($"{nameof(BestiaryPage)}");
        }
    }
}
