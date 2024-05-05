using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DndFightManagerMobileApp.Models;
using DndFightManagerMobileApp.Utils;
using DndFightManagerMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Xml.Linq;
using Xamarin.Forms;

namespace DndFightManagerMobileApp.ViewModels
{
    public enum LocalNavigation
    {
        Left,
        Right
    }
    
    public partial class CreateEditBeastNoteMainViewModel : BaseViewModel, IQueryAttributable
    {
        #region IncomingParametres

        private string _beastNoteId;
        private bool _isEditing;

        #endregion

        #region ObservableProperties

        [ObservableProperty] 
        private string _saveButtonText;

        [ObservableProperty] 
        private string _currentViewName;

        [ObservableProperty] 
        private ContentView _currentView;

        [ObservableProperty] 
        private bool _isToLeftVisible;

        [ObservableProperty] 
        private bool _isToRightVisible;

        [ObservableProperty] 
        private BeastNoteModel _beastNote;

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
                    ),
                    (
                        v: new CreateEditBeastNoteSpellingView(),
                        vm: CreateEditBeastNoteSpellingView._vm,
                        vname: "Заклинания"
                    ),
                    (
                        v: new CreateEditBeastNoteCommonView(),
                        vm: CreateEditBeastNoteCommonView._vm,
                        vname: "Общая информация"
                    ),
                    (
                        v: new CreateEditBeastNoteResultView(),
                        vm: CreateEditBeastNoteResultView._vm,
                        vname: "Просмотр результата"
                    ),
                ];
        }

        #region Navigation

        private void LocalNavigateTo(LocalNavigation localNavigation)
        {
            if (_crudViews[CurrentViewIndex].vm.OnNavigateFrom() is BeastNoteModel bm)
                BeastNote = bm;

            if (localNavigation == LocalNavigation.Left)
                CurrentViewIndex--;
            else if (localNavigation == LocalNavigation.Right)
                CurrentViewIndex++;

            _crudViews[CurrentViewIndex].vm.OnNavigateTo(BeastNote);
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

        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            if (query == null)
                return;

            string param1 = "beastNoteId";
            string param2 = "isEditing";

            if (query.ContainsKey(param1))
            {
                _beastNoteId = NavigationParameterConverter.
                    ObjectFromPairKeyValue<string>(HttpUtility.UrlDecode(query[param1]));
            }
            else
                _beastNoteId = "";

            if (query.ContainsKey(param2))
            {
                _isEditing = NavigationParameterConverter.
                    ObjectFromPairKeyValue<bool>(HttpUtility.UrlDecode(query[param2]));
            }
            else
                _isEditing = false;

            if (_isEditing)
            {
                SaveButtonText = "Подтвердить\nизменения";
                BeastNote = dataStore.BeastNote.GetById(_beastNoteId).Result;
                if (BeastNote == null)
                    _isEditing = true;
            }

            if (!_isEditing)
            {
                SaveButtonText = "Создать моба";
                BeastNote = new BeastNoteModel
                {
                    Id = Guid.NewGuid().ToString(),
                    HitPoitsDice = "2d6+2",
                    InitiativeBonus = 0,
                    ArmorClass = 10,
                    SpecialBonus = 2,
                    //Image = [],
                    Title = "",
                    Alignment = dataStore.Alignment.GetByTitle("Без мировоззрения").Result,
                    Size = dataStore.Size.GetByTitle("Средний").Result,
                    BeastType = dataStore.BeastType.GetByTitle("Гуманоид").Result,
                    ChallengeRating = 0.25,
                    Description = "",
                    CreationDate = DateTime.Now,
                    LastEditingDate = DateTime.Now,
                    AbilityList = [.. dataStore.Ability.GetDefaultList().Result],
                    SkillList = [.. dataStore.Skill.GetDefaultList().Result]
                };
            }

            CurrentViewIndex = 0;
            CurrentView = _crudViews[CurrentViewIndex].v;
            CurrentViewName = _crudViews[CurrentViewIndex].vname;
            _crudViews[CurrentViewIndex].vm.OnNavigateTo(BeastNote);
        }

        [RelayCommand]
        private void SaveAndNavigateBackTo()
        {
            if (_isEditing)
            {
                if (_crudViews[CurrentViewIndex].vm.OnNavigateFrom() is BeastNoteModel beast)
                {
                    if (dataStore.BeastNote.Update(beast).Result)
                    {
                        bool isNeedRefresh = true;
                        string parameter = NavigationParameterConverter.
                            ObjectToPairKeyValue(isNeedRefresh, nameof(isNeedRefresh));
                        Shell.Current.GoToAsync($"..?{parameter}");
                    }
                }
            }
            else
            {
                if (_crudViews[CurrentViewIndex].vm.OnNavigateFrom() is BeastNoteModel beast)
                {
                    if (dataStore.BeastNote.Create(beast).Result)
                    {
                        bool isNeedRefresh = true;
                        string parameter = NavigationParameterConverter.
                            ObjectToPairKeyValue(isNeedRefresh, nameof(isNeedRefresh));
                        Shell.Current.GoToAsync($"..?{parameter}");
                    }
                }
            }
        }

        #endregion
    }
}
