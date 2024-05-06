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

        #region Navigation

        [RelayCommand]
        private async Task CreateAction()
        {
            string navigationCondition = NPConv.ObjectToPairKeyValue(NavigationCondition.Create, nameof(navigationCondition));
            string spellSlots = NPConv.ObjectToPairKeyValue(_beastNote.SpellSlots, nameof(spellSlots));
            string actions = NPConv.ObjectToPairKeyValue(_beastNote.Actions, nameof(actions));

            await Shell.Current.GoToAsync($"{nameof(CreateEditBeastNoteActionsCRUDPage)}?{navigationCondition}&{spellSlots}&{actions}");
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
            _beastNote.Actions = [.. AllActions];

            return _beastNote;
        }

        #endregion

    }
}
