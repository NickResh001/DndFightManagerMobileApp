using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DndFightManagerMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using NPConv = DndFightManagerMobileApp.Utils.NavigationParameterConverter;

namespace DndFightManagerMobileApp.ViewModels
{
    public partial class BeastNoteWatchingViewModel : BaseViewModel, IQueryAttributable
    {
        #region IncomeParametres

        private string _beastNoteId;

        #endregion

        #region ObservableProperties

        [ObservableProperty]
        private BaseViewModelHandNavigation _innerViewModel;

        [ObservableProperty]
        private ContentView _innerView;

        #endregion

        public BeastNoteWatchingViewModel() 
        {
            InnerView = new CreateEditBeastNoteResultView();
            InnerViewModel = CreateEditBeastNoteResultView._vm;
        }

        #region Navigation

        [RelayCommand]
        private void NavigateBackTo()
        {
            Shell.Current.GoToAsync("..");
        }

        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            if (query == null)
                return;

            string beastNoteIdParam = "beastNoteId";

            _beastNoteId = "";

            if (query.ContainsKey(beastNoteIdParam))
                _beastNoteId = NPConv.ObjectFromUrl<string>(query[beastNoteIdParam]);

            if (_beastNoteId != "")
            {
                var beastNote = dataStore.BeastNote.GetById(_beastNoteId).Result;
                InnerViewModel.OnNavigateTo(beastNote);
            }
        }

        #endregion
    }
}
