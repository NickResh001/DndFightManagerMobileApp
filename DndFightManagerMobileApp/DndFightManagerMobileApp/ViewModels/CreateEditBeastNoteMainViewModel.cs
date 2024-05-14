using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DndFightManagerMobileApp.Models;
using DndFightManagerMobileApp.Utils;
using DndFightManagerMobileApp.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Linq;
using Xamarin.Forms;
using NPConv = DndFightManagerMobileApp.Utils.NavigationParameterConverter;

namespace DndFightManagerMobileApp.ViewModels
{
    public enum LocalNavigation
    {
        Left,
        Right
    }

    public enum NavigationCondition
    {
        Nothing,
        Create,
        Edit,
        Returning,
        Refreshing
    }
    
    public partial class CreateEditBeastNoteMainViewModel : BaseViewModel, IQueryAttributable
    {
        #region IncomingParametres

        private string _beastNoteId;

        private NavigationCondition _navigationCondition;

        ActionModel _action;

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

        public bool _isActionChanged;
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
                        v: new CreateEditBeastNoteActionsView(),
                        vm: CreateEditBeastNoteActionsView._vm,
                        vname: "Действия"
                    ),
                    (
                        v: new CreateEditBeastNoteResultView(),
                        vm: CreateEditBeastNoteResultView._vm,
                        vname: "Просмотр результата"
                    ),
                ];
        }
        private void ArrivalFromBestiaryToCreate()
        {
            _navigationCondition = NavigationCondition.Create;
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
        private void ArrivalFromBestiaryToEdit()
        {
            _navigationCondition = NavigationCondition.Edit;
            SaveButtonText = "Подтвердить\nизменения";
            BeastNote = dataStore.BeastNote.GetById(_beastNoteId).Result;
            if (BeastNote == null)
            {
                _navigationCondition = NavigationCondition.Create;
                ArrivalFromBestiaryToCreate();
            }
        }
        private void ArrivalFromActionCRUD()
        {
            var oldAction = BeastNote.Actions.FirstOrDefault(x => x.Id == _action.Id);
            if (oldAction != null)
            {
                BeastNote.Actions.Remove(oldAction);
            }
            BeastNote.Actions.Add(_action);
            BeastNote.LairInitiative = (int)_action.Lair_InitiativeBonus;
            foreach(var action in BeastNote.Actions)
            {
                action.Lair_InitiativeBonus = BeastNote.LairInitiative;
            }
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

            string beastNoteIdParam =           "beastNoteId";
            string navigationConditionParam =   "navigationCondition";
            string currentViewIndexParam =      "currentViewIndex";
            string actionParam =                "action";

            _beastNoteId = "";
            var navigationCondition = NavigationCondition.Nothing;
            CurrentViewIndex = 0;
            _action = null;
            _isActionChanged = false;
            
            if (query.ContainsKey(beastNoteIdParam)) 
                _beastNoteId = NPConv.ObjectFromUrl<string>(query[beastNoteIdParam]);

            if (query.ContainsKey(navigationConditionParam))
                navigationCondition = NPConv.ObjectFromUrl<NavigationCondition>(query[navigationConditionParam]);

            if (query.ContainsKey(currentViewIndexParam))
                CurrentViewIndex = NPConv.ObjectFromUrl<int>(query[currentViewIndexParam]);

            if (query.ContainsKey(actionParam))
                _action = NPConv.ObjectFromUrl<ActionModel>(query[actionParam]);

            switch (navigationCondition)
            {
                case NavigationCondition.Create:
                    ArrivalFromBestiaryToCreate();
                    break;
                case NavigationCondition.Edit:
                    ArrivalFromBestiaryToEdit();
                    break;
                case NavigationCondition.Returning:
                    ArrivalFromActionCRUD();
                    break;
                default: 
                    break;
            }            

            // настройка текущего crud-view
            CurrentView = _crudViews[CurrentViewIndex].v;
            CurrentViewName = _crudViews[CurrentViewIndex].vname;
            _crudViews[CurrentViewIndex].vm.OnNavigateTo(BeastNote);
        }

        [RelayCommand]
        private void SaveAndNavigateBackTo()
        {
            if (_crudViews[CurrentViewIndex].vm.OnNavigateFrom() is BeastNoteModel beast)
            {
                bool success;
                if (_navigationCondition == NavigationCondition.Edit)
                    success = dataStore.BeastNote.Update(beast).Result;
                else if (_navigationCondition == NavigationCondition.Create)
                    success = dataStore.BeastNote.Create(beast).Result;
                else
                    success = false;

                if (success)
                {
                    bool isNeedRefresh = true;
                    string parameter = NPConv.ObjectToPairKeyValue(isNeedRefresh, nameof(isNeedRefresh));
                    Shell.Current.GoToAsync($"..?{parameter}");

                    // Временное решение для быстрого заполнения начальной библиотеки
                    if (false)
                    {
                        string jsonBackup = JsonConvert.SerializeObject(beast);
                        string results = Regex.Replace(jsonBackup, "(.{1,100})", "\"$1\"\n");
                        Console.WriteLine($" =====> you need new mob =====> ");
                        Console.WriteLine(results);
                        Console.WriteLine($" <===== thats all <===== ");
                        int a = 0;
                    }
                    
                }
                else
                {
                    throw new Exception("Ошибка записи");
                }
            }
            else
            {
                throw new Exception("Из крада передался сломанный моб");
            }
        }

        #endregion
    }
}
