using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DndFightManagerMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using NPConv = DndFightManagerMobileApp.Utils.NavigationParameterConverter;

namespace DndFightManagerMobileApp.ViewModels
{
    public partial class ManagerCRUDMainViewModel : BaseViewModel, IQueryAttributable
    {
        #region IncomingParams
        private string _sceneSaveId;
        #endregion

        #region ObservableProperties

        [ObservableProperty]
        private ContentView _currentView;

        [ObservableProperty]
        private ObservableCollection<TabHelper> _crudViews;

        #endregion

        #region LogicProperties

        private int currentTabIndex;

        #endregion

        public ManagerCRUDMainViewModel()
        {
            _crudViews =
                [
                    new TabHelper
                    {
                        View = new ManagerCRUDFightTeamView(),
                        ViewModel = ManagerCRUDFightTeamView._vm,
                        IsEnable = true,
                        TabIndex = 0,
                        TabTitle = "Команды"
                    },
                    new TabHelper
                    {
                        View = new ManagerCRUDBeastView(),
                        ViewModel = ManagerCRUDBeastView._vm,
                        IsEnable = true,
                        TabIndex = 1,
                        TabTitle = "Мобы"
                    }
                ];

            currentTabIndex = 0;
            SwitchTab(0);
        }

        #region Navigation

        [RelayCommand]
        private void NavigateBackTo()
        {
            string sceneSaveId = NPConv.ObjectToPairKeyValue(_sceneSaveId, nameof(sceneSaveId));
            string navigationCondition = NPConv.ObjectToPairKeyValue(NavigationCondition.Refreshing, nameof(navigationCondition));
            Shell.Current.GoToAsync($"..?{sceneSaveId}&{navigationCondition}");
        }

        [RelayCommand]
        private void SwitchTab(int newTabIndex)
        {
            for (int i = 0; i < CrudViews.Count; i++)
            {
                CrudViews[i].IsEnable = true;
            }
            currentTabIndex = newTabIndex;
            CrudViews[currentTabIndex].IsEnable = false;
            CurrentView = CrudViews[currentTabIndex].View;
            CrudViews[currentTabIndex].ViewModel.OnNavigateTo(_sceneSaveId);
        }

        public async void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            if (query == null)
                return;

            string sceneSaveIdParam = "sceneSaveId";

            _sceneSaveId = null;

            if (query.ContainsKey(sceneSaveIdParam))
                _sceneSaveId = NPConv.ObjectFromUrl<string>(query[sceneSaveIdParam]);
            
            currentTabIndex = 0;
            SwitchTab(0);
        }
        #endregion
    }
}
