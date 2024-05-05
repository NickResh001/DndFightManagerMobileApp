using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DndFightManagerMobileApp.Models.ModelHelpers;
using DndFightManagerMobileApp.Utils;
using DndFightManagerMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Forms;
using NavParamConv = DndFightManagerMobileApp.Utils.NavigationParameterConverter;

namespace DndFightManagerMobileApp.ViewModels
{
    public partial class BestiaryViewModel : BaseViewModel, IQueryAttributable
    {
        #region IncomingParametres

        private bool _isNeedRefresh;

        #endregion


        #region ObservableProperties

        [ObservableProperty]
        private ObservableCollection<BestiaryBeastNoteHelper> _beasts = [];

        [ObservableProperty]
        private BestiaryBeastNoteHelper _choosenBeastNote;

        [ObservableProperty]
        private bool _isMoreActionsMenuActive;

        #endregion

        public BestiaryViewModel() 
        {
            RefreshCollection();
            IsMoreActionsMenuActive = false;
        }
        public async void RefreshCollection()
        {
            var collection = await dataStore.BeastNote.GetAll();
            Beasts = collection.ToObservableCollection().Projection(x => new BestiaryBeastNoteHelper(x));
        }

        #region Commands

        [RelayCommand]
        private async Task CreateBeastNote()
        {
            string beastNoteId = NavParamConv.ObjectToPairKeyValue("", nameof(beastNoteId));
            string isEditing = NavParamConv.ObjectToPairKeyValue(false, nameof(isEditing));
            await NavigateToCRUD($"{beastNoteId}&{isEditing}");
        }

        [RelayCommand]
        private void OpenMoreActionsMenu(string id)
        {
            ChoosenBeastNote = Beasts.FirstOrDefault(x => x.Id == id);
            if (ChoosenBeastNote != null)
                IsMoreActionsMenuActive = true; 
        }

        [RelayCommand]
        private void CloseMoreActionsMenu()
        {
            IsMoreActionsMenuActive = false;
        }


        [RelayCommand]
        private async Task WatchBeastNote(string id)
        {
            CloseMoreActionsMenu();
        }

        [RelayCommand]
        private void CopyBeastNote(string id)
        {
            CloseMoreActionsMenu();
        }

        [RelayCommand]
        private async Task UpdateBeastNote(string id)
        {
            string beastNoteId = NavParamConv.ObjectToPairKeyValue(id, nameof(beastNoteId));
            string isEditing = NavParamConv.ObjectToPairKeyValue(true, nameof(isEditing));
            CloseMoreActionsMenu();
            await NavigateToCRUD($"{beastNoteId}&{isEditing}");
        }

        [RelayCommand]
        private void DeleteBeastNote(string id)
        {
            if(!string.IsNullOrEmpty(id) && dataStore.BeastNote.Delete(id).Result)
            {
                RefreshCollection();
                CloseMoreActionsMenu();
            }
        }

        #endregion


        #region Navigation

        private async Task NavigateToCRUD(string parametres)
        {
            await Shell.Current.GoToAsync($"{nameof(CreateEditBeastNoteMainPage)}?{parametres}");
        }

        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            if (query == null)
                return;

            string param1 = "isNeedRefresh";

            if (query.ContainsKey(param1))
            {
                _isNeedRefresh = NavParamConv.ObjectFromPairKeyValue<bool>(HttpUtility.UrlDecode(query[param1]));
            }
            else
                _isNeedRefresh = false;

            if(_isNeedRefresh)
            {
                RefreshCollection();
            }
        }

        #endregion
    }
}
