using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DndFightManagerMobileApp.Models.ModelHelpers;
using DndFightManagerMobileApp.Utils;
using DndFightManagerMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using NavParamConv = DndFightManagerMobileApp.Utils.NavigationParameterConverter;

namespace DndFightManagerMobileApp.ViewModels
{
    public partial class BestiaryViewModel : BaseViewModel
    {
        [ObservableProperty]
        private ObservableCollection<BestiaryBeastNoteHelper> _beasts = new();

        

        public BestiaryViewModel() 
        {
            Beasts = dataStore.BeastNote.GetAll().Result.ToObservableCollection().
                Projection(x => new BestiaryBeastNoteHelper(x));

        }

        [RelayCommand]
        private async Task CreateBeastNote()
        {
            string beastNoteId = NavParamConv.ObjectToPairKeyValue("", nameof(beastNoteId));
            string isEditing = NavParamConv.ObjectToPairKeyValue(false, nameof(isEditing));
            await NavigateToCRUD($"{beastNoteId}&{isEditing}"); 
        }

        [RelayCommand]
        private async Task UpdateBeastNote(string id)
        {
            string beastNoteId = NavParamConv.ObjectToPairKeyValue(id, nameof(beastNoteId));
            string isEditing = NavParamConv.ObjectToPairKeyValue(true, nameof(isEditing));
            await NavigateToCRUD($"{beastNoteId}&{isEditing}");
        }

        [RelayCommand]
        private void DeleteBeastNote(string id)
        {
            int a = 0;
        }

        [RelayCommand]
        private void CopyBeastNote(string id)
        {

        }


        #region Navigation

        private async Task NavigateToCRUD(string parametres)
        {
            await Shell.Current.GoToAsync($"{nameof(CreateEditBeastNoteMainPage)}?{parametres}");
        }

        #endregion
    }
}
