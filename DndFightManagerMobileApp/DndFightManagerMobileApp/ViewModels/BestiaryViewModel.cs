﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DndFightManagerMobileApp.Models.ModelHelpers;
using DndFightManagerMobileApp.Utils;
using DndFightManagerMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
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
            string navigationCondition = NavParamConv.ObjectToPairKeyValue(NavigationCondition.Create, nameof(navigationCondition));
            await NavigateToCRUD($"{navigationCondition}");
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
            string beastNoteId = NavParamConv.ObjectToPairKeyValue(id, nameof(beastNoteId));
            CloseMoreActionsMenu();
            await Shell.Current.GoToAsync($"{nameof(BeastNoteWatchingPage)}?{beastNoteId}");
        }

        [RelayCommand]
        private async Task UpdateBeastNote(string id)
        {
            string beastNoteId = NavParamConv.ObjectToPairKeyValue(id, nameof(beastNoteId));
            string navigationCondition = NavParamConv.ObjectToPairKeyValue(NavigationCondition.Edit, nameof(navigationCondition));
            CloseMoreActionsMenu();
            await NavigateToCRUD($"{beastNoteId}&{navigationCondition}");
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

        [RelayCommand]
        private async Task NavigateBackTo()
        {
            await Shell.Current.GoToAsync($"..");
        }
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
                _isNeedRefresh = NavParamConv.ObjectFromUriValue<bool>(HttpUtility.UrlDecode(query[param1]));
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
