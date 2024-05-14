using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DndFightManagerMobileApp.Models;
using DndFightManagerMobileApp.Utils;
using DndFightManagerMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

using NPConv = DndFightManagerMobileApp.Utils.NavigationParameterConverter;

namespace DndFightManagerMobileApp.ViewModels
{
    public partial class CreateEditBeastNoteActionsViewModel : BaseViewModelHandNavigation
    {
        private BeastNoteModel _beastNote;

        #region ObservablePropeties

        [ObservableProperty]
        private ObservableCollection<ActionModel> _allActions = [];

        #endregion

        public CreateEditBeastNoteActionsViewModel() 
        { 
            
        }
        private void MoreMenusClosing()
        {
            foreach (var action in AllActions)
            {
                action.IsMoreMenuOpened = false;
            }
        }

        [RelayCommand]
        private void MoreMenuOpenClose(string id)
        {
            foreach (var action in AllActions)
            {
                if (action.Id == id)
                    action.IsMoreMenuOpened = !action.IsMoreMenuOpened;
                else
                    action.IsMoreMenuOpened = false;
            }
        }

        [RelayCommand]
        private void DeleteAction(string id)
        {
            AllActions.Remove(AllActions.FirstOrDefault(x => x.Id == id));
        }

        #region Navigation

        [RelayCommand]
        private async Task CreateAction()
        {
            string navigationCondition = NPConv.ObjectToPairKeyValue(NavigationCondition.Create, nameof(navigationCondition));
            string spellSlots = NPConv.ObjectToPairKeyValue(_beastNote.SpellSlots, nameof(spellSlots));
            string actions = NPConv.ObjectToPairKeyValue(_beastNote.Actions, nameof(actions));
            string incomingLairInitiative = NPConv.ObjectToPairKeyValue(_beastNote.LairInitiative, nameof(incomingLairInitiative));

            MoreMenusClosing();
            await Shell.Current.GoToAsync($"{nameof(CreateEditBeastNoteActionsCRUDPage)}?{navigationCondition}&{spellSlots}&{actions}&{incomingLairInitiative}");
        }

        [RelayCommand]
        private async Task UpdateAction(string id)
        {
            string navigationCondition = NPConv.ObjectToPairKeyValue(NavigationCondition.Edit, nameof(navigationCondition));
            string spellSlots = NPConv.ObjectToPairKeyValue(_beastNote.SpellSlots, nameof(spellSlots));
            string actions = NPConv.ObjectToPairKeyValue(_beastNote.Actions, nameof(actions));
            string actionId = NPConv.ObjectToPairKeyValue(id, nameof(actionId));
            string incomingLairInitiative = NPConv.ObjectToPairKeyValue(_beastNote.LairInitiative, nameof(incomingLairInitiative));

            MoreMenusClosing();
            await Shell.Current.GoToAsync($"{nameof(CreateEditBeastNoteActionsCRUDPage)}?{navigationCondition}&{spellSlots}&{actions}&{actionId}&{incomingLairInitiative}");
        }

        public override void OnNavigateTo(object parameter)
        {
            if (parameter is BeastNoteModel incomeBeast)
            {
                _beastNote = incomeBeast;
                AllActions = [.. _beastNote.Actions];
            }
        }

        public override object OnNavigateFrom()
        {
            MoreMenusClosing();
            _beastNote.Actions = [.. AllActions];
            return _beastNote;
        }

        #endregion

    }
}
