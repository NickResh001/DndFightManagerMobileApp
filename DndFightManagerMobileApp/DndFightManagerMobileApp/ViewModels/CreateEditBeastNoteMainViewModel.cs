using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DndFightManagerMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Linq;
using Xamarin.Forms;

namespace DndFightManagerMobileApp.ViewModels
{
    public enum LocalNavigation
    {
        Left,
        Right
    }
    public partial class CreateEditBeastNoteMainViewModel : BaseViewModel
    {
        #region IncomingParametres

        private string _beastNoteId;
        public string BeastNoteId
        {
            get { return _beastNoteId; }
            set
            {
                _beastNoteId = value;
                if (value == string.Empty)
                {
                    // this is Creation act
                }
                else
                {
                    // Getting beastNote by id (this is Edit act)
                }
            }
        }

        #endregion

        #region ObservableProperties

        [ObservableProperty] private string _pageHeader;
        [ObservableProperty] private string _teamName;
        [ObservableProperty] private string _currentViewName;
        [ObservableProperty] private ContentView _currentView;

        [ObservableProperty] private bool _isToLeftVisible;
        [ObservableProperty] private bool _isToRightVisible;

        #endregion

        #region LogicProperties

        private List<(ContentView v, BaseViewModelHandNavigation vm, string vname)> _crudViews;

        private int _currentViewIndex;
        public int CurrentViewIndex
        {
            get { return _currentViewIndex; }
            set
            {
                _currentViewIndex = value;
                IsToLeftVisible = value == 0 ? false : true;
                IsToRightVisible = value == _crudViews.Count - 1 ? false : true;
            }
        }

        #endregion

        public CreateEditBeastNoteMainViewModel()
        {
            _crudViews =
                [
                    (
                        v: new CreateEditBeastNoteStatsView(),
                        vm: CreateEditBeastNoteStatsView._vm,
                        vname: "Характеристики"
                    ),
                    (
                        v: new CreateEditBeastNoteDamageView(),
                        vm: CreateEditBeastNoteDamageView._vm,
                        vname: "Урон и состояния"
                    )
                ];
            PageHeader = "Создание моба";

            CurrentViewIndex = 0;
            CurrentView = _crudViews[CurrentViewIndex].v;
            CurrentViewName = _crudViews[CurrentViewIndex].vname;
        }
        private void LocalNavigateTo(LocalNavigation localNavigation)
        {
            // Take parametres from view I left

            if (localNavigation == LocalNavigation.Left)
                CurrentViewIndex--;
            else if (localNavigation == LocalNavigation.Right)
                CurrentViewIndex++;

            _crudViews[CurrentViewIndex].vm.OnNavigateTo(null);
            CurrentView = _crudViews[CurrentViewIndex].v;
            CurrentViewName = _crudViews[CurrentViewIndex].vname;
        }

        [RelayCommand]
        public void ToLeftView() 
        { 
            if (CurrentViewIndex > 0) 
                LocalNavigateTo(LocalNavigation.Left); 
        }

        [RelayCommand]
        private void ToRightView()
        {
            if (CurrentViewIndex < _crudViews.Count - 1)
                LocalNavigateTo(LocalNavigation.Right);
        }
        
        [RelayCommand]
        private void NavigateBackTo() 
        {
            Shell.Current.GoToAsync("..");
        }
    }
}
