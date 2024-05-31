using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DndFightManagerMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace DndFightManagerMobileApp.ViewModels
{
    public partial class TabHelper : ObservableObject
    {
        [ObservableProperty]
        private ContentView view;

        [ObservableProperty]
        private BaseViewModelHandNavigation viewModel;

        [ObservableProperty]
        private bool isEnable;

        [ObservableProperty]
        private int tabIndex;

        [ObservableProperty]
        private string tabTitle;
    }

    public partial class ScenesListMainViewModel : BaseViewModel, IQueryAttributable
    {
        #region ObservableProperties

        [ObservableProperty]
        private ContentView _currentView;

        [ObservableProperty]
        private ObservableCollection<TabHelper> _crudViews;

        #endregion

        #region LogicProperties

        private int currentTabIndex;

        #endregion

        public ScenesListMainViewModel()
        {
            _crudViews =
                [
                    new TabHelper 
                    {
                        View = new ScenesListView(),
                        ViewModel = ScenesListView._vm,
                        IsEnable = true,
                        TabIndex = 0,
                        TabTitle = "Сцены"
                    },
                    new TabHelper
                    {
                        View = new CampaignsListView(),
                        ViewModel = CampaignsListView._vm,
                        IsEnable = true,
                        TabIndex = 1,
                        TabTitle = "Кампании"
                    },
                    new TabHelper
                    {
                        View = new SettingsListView(),
                        ViewModel = SettingsListView._vm,
                        IsEnable = true,
                        TabIndex = 2,
                        TabTitle = "Сеттинги"
                    },
                ];

            currentTabIndex = 0;
            SwitchTab(0);
        }

        #region Navigation

        [RelayCommand]
        private void NavigateBackTo()
        {
            Shell.Current.GoToAsync("..");
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
            CrudViews[currentTabIndex].ViewModel.OnNavigateTo(null);
        }

        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            currentTabIndex = 0;
            SwitchTab(0);
        }
        #endregion
    }
}
