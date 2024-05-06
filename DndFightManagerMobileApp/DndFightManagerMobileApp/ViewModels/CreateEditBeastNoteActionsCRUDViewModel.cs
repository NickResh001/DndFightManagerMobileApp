using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DndFightManagerMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using NPConv = DndFightManagerMobileApp.Utils.NavigationParameterConverter;

namespace DndFightManagerMobileApp.ViewModels
{
    public partial class CreateEditBeastNoteActionsCRUDViewModel : BaseViewModel, IQueryAttributable
    {
        #region IncomigParametres

        private NavigationCondition _navigationCondition;
        private List<SpellSlotModel> _spellSlots;
        private List<ActionModel> _actions;
        private string _actionId;

        #endregion

        #region ObservableProperties

        // Название
        [ObservableProperty]
        private string _actionTitle;

        #region CooldownType
        // Откат       "Время", "Ячейки заклинаний", "Перезарядка"
        [ObservableProperty]
        private ObservableCollection<CooldownTypeModel> _allCooldownTypes;


        private CooldownTypeModel _selectedCooldown;
        public CooldownTypeModel SelectedCooldown
        {
            get { return _selectedCooldown; }
            set
            {
                if (value != null || value != _selectedCooldown) 
                    _selectedCooldown = value;

                OnPropertyChanged(nameof(SelectedCooldown));
                OnPropertyChanged(nameof(IsTimeSeqActive));
                OnPropertyChanged(nameof(IsRechargeSeqActive));
                OnPropertyChanged(nameof(IsSpellSlotSeqActive)); 
            }
        }

        // Откат 2 - время

        public bool IsTimeSeqActive
        {
            get 
            { 
                if (SelectedCooldown == null)
                    return false;
                else
                    return SelectedCooldown.Title == "Время"; 
            }
        }

        [ObservableProperty]
        private ObservableCollection<TimeMeasureModel> _allTimeMeasures;

        [ObservableProperty]
        private TimeMeasureModel _selectedTimeMeasure;

        [ObservableProperty]
        private string _howManyTimes;

        [ObservableProperty]
        private string _measureMultiply;

        // Откат 3 - перезарядка
        public bool IsRechargeSeqActive
        {
            get
            {
                if (SelectedCooldown == null)
                    return false;
                else
                    return SelectedCooldown.Title == "Перезарядка"; 
            }
        }

        private string _lowerRangeLimit;
        public string LowerRangeLimit
        {
            get { return _lowerRangeLimit; }
            set
            {
                if (value == null)
                    return;

                if (new Regex(@"^\d*$", RegexOptions.Compiled).IsMatch(value))
                {
                    int buffer;
                    if (value != "" && int.TryParse(value, out buffer))
                    {
                        buffer = buffer < 1 ? 1 : buffer;
                        int upperRangeLimitBuffer;
                        if (int.TryParse(UpperRangeLimit, out upperRangeLimitBuffer) && upperRangeLimitBuffer < buffer)
                        {
                            UpperRangeLimit = buffer.ToString();
                        }
                        _lowerRangeLimit = buffer.ToString();
                        OnPropertyChanged(nameof(LowerRangeLimit));
                    }
                }
                else
                {
                    OnPropertyChanged(nameof(LowerRangeLimit));
                }
            }
        }

        private string _upperRangeLimit;
        public string UpperRangeLimit
        {
            get { return _upperRangeLimit; }
            set
            {
                if (value == null)
                    return;

                if (new Regex(@"^\d*$", RegexOptions.Compiled).IsMatch(value))
                {
                    int buffer;
                    if (value != "" && int.TryParse(value, out buffer))
                    {
                        int lowerRangeLimitBuffer;
                        if (int.TryParse(LowerRangeLimit, out lowerRangeLimitBuffer) && buffer < lowerRangeLimitBuffer)
                        {
                            buffer = lowerRangeLimitBuffer;
                            _upperRangeLimit = buffer.ToString();
                            return;
                        }
                        int diceSizeBuffer;
                        if (int.TryParse(DiceSize, out diceSizeBuffer) && diceSizeBuffer < buffer)
                        {
                            DiceSize = buffer.ToString();
                        }
                        _upperRangeLimit = buffer.ToString();
                        OnPropertyChanged(nameof(UpperRangeLimit));
                    }
                }
                else
                {
                    OnPropertyChanged(nameof(UpperRangeLimit));
                }
            }
        }

        private string _diceSize;
        public string DiceSize
        {
            get { return _diceSize; }
            set
            {
                if (value == null)
                    return;

                if (new Regex(@"^\d*$", RegexOptions.Compiled).IsMatch(value))
                {
                    int buffer;
                    if (value != "" && int.TryParse(value, out buffer))
                    {
                        int upperRangeLimitBuffer;
                        if (int.TryParse(UpperRangeLimit, out upperRangeLimitBuffer) && buffer < upperRangeLimitBuffer)
                        {
                            buffer = upperRangeLimitBuffer;
                            _diceSize = buffer.ToString();
                            return;
                        }
                        _diceSize = buffer.ToString();
                        OnPropertyChanged(nameof(DiceSize));
                    }
                }
                else
                {
                    OnPropertyChanged(nameof(DiceSize));
                }
            }
        }

        // Откат 4 - ячейки
        public bool IsSpellSlotSeqActive
        {
            get 
            { 
                if (SelectedCooldown == null)
                    return false;
                else
                    return SelectedCooldown.Title == "Ячейки заклинаний"; 
            }
        }

        [ObservableProperty]
        private string _selectedSpellSlot;

        [ObservableProperty]
        private ObservableCollection<string> _allowedSpellSlots;

        #endregion



        //

        // Ресурс

        // Содержание

        // Броски


        #endregion

        private ActionModel _action;

        public CreateEditBeastNoteActionsCRUDViewModel()
        {
            //AllCooldownTypes = new(dataStore.CooldownType.GetAll().Result);
        }
        private async void ArrivalToCreate()
        {
            _action = new ActionModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "",
                CooldownType = await dataStore.CooldownType.GetByTitle("Нет"),
                ActionResource = await dataStore.ActionResource.GetByTitle("Основное"),

                Cooldown1_SpellSlotLevel = 1,
                Cooldown2_LowerRangeLimit = 5,
                Cooldown2_UpperRangeLimit = 6,
                Cooldown2_DiceSize = 6,
                Cooldown3_TimeMeasure = await dataStore.TimeMeasure.GetByTitle("Раунд"),
                Cooldown3_HowManyTimes = 1,
                Reaction_Condition = "",
                Lair_InitiativeBonus = 20,
            };
            _actionId = _action.Id;
        }
        private void ArrivalToEdit()
        {
            _action = _actions.FirstOrDefault(x => x.Id == _actionId);
        }
        private void ArrivalInitialize()
        {
            ActionTitle = _action.Title;

            AllCooldownTypes = new(dataStore.CooldownType.GetAll().Result);
            if (_spellSlots == null || _spellSlots.Count == 0)
            {
                AllCooldownTypes.Remove(AllCooldownTypes.FirstOrDefault(x => x.Title == "Ячейки заклинаний"));
            }

            SelectedCooldown = AllCooldownTypes.FirstOrDefault(x => x.Id == _action.CooldownType.Id);
            SelectedCooldown ??= AllCooldownTypes[0];

            // Ячейки
            if (_spellSlots != null && _spellSlots.Count > 0)
            {
                AllowedSpellSlots = [];
                foreach (var spellSlot in _spellSlots)
                {
                    AllowedSpellSlots.Add(spellSlot.Level.ToString());
                }

                SelectedSpellSlot = AllowedSpellSlots.FirstOrDefault(x => x == _action.Cooldown1_SpellSlotLevel.ToString());
                SelectedSpellSlot ??= AllowedSpellSlots[0];
            }

            // Перезарядка
            LowerRangeLimit = _action.Cooldown2_LowerRangeLimit.ToString();
            UpperRangeLimit = _action.Cooldown2_UpperRangeLimit.ToString();
            DiceSize = _action.Cooldown2_DiceSize.ToString();


        }
        private void AssembleAction()
        {
            _action.Title = ActionTitle;
            _action.CooldownType = SelectedCooldown;

            _action.Cooldown1_SpellSlotLevel = int.Parse(SelectedSpellSlot);

            _action.Cooldown2_LowerRangeLimit = int.Parse(LowerRangeLimit);
            _action.Cooldown2_UpperRangeLimit = int.Parse(UpperRangeLimit);
            _action.Cooldown2_DiceSize = int.Parse(DiceSize);
        }

        #region Navigation

        [RelayCommand]
        private void SaveAndNavigateBackTo()
        {
            AssembleAction();
            string action = NPConv.ObjectToPairKeyValue(_action, nameof(action));
            string currentViewIndex = NPConv.ObjectToPairKeyValue(4, nameof(currentViewIndex));
            string navigationCondition = NPConv.ObjectToPairKeyValue(NavigationCondition.Returning, nameof(navigationCondition));
            Shell.Current.GoToAsync($"..?{currentViewIndex}&{navigationCondition}&{action}");
        }

        [RelayCommand]
        private void NavigateBackTo()
        {
            string currentViewIndex = NPConv.ObjectToPairKeyValue(4, nameof(currentViewIndex));
            string navigationCondition = NPConv.ObjectToPairKeyValue(NavigationCondition.Nothing, nameof(navigationCondition));
            Shell.Current.GoToAsync($"..?{currentViewIndex}&{navigationCondition}");
        }

        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            if (query == null)
                return;

            string navigationConditionParam =   "navigationCondition";
            string spellSlotsParam =            "spellSlots";
            string actionsParam =               "actions";
            string actionIdParam =              "actionId";

            _navigationCondition = NavigationCondition.Nothing;
            _spellSlots = [];
            _actions = [];
            _actionId = "";

            if (query.ContainsKey(navigationConditionParam))
                _navigationCondition = NPConv.ObjectFromUrl<NavigationCondition>(query[navigationConditionParam]);

            if (query.ContainsKey(spellSlotsParam))
                _spellSlots = NPConv.ObjectFromUrl<List<SpellSlotModel>>(query[spellSlotsParam]);

            if (query.ContainsKey(actionsParam))
                _actions = NPConv.ObjectFromUrl<List<ActionModel>>(query[actionsParam]);

            if (query.ContainsKey(actionIdParam))
                _actionId = NPConv.ObjectFromUrl<string>(query[actionIdParam]);


            if (_navigationCondition == NavigationCondition.Create)
                ArrivalToCreate();
            else if (_navigationCondition == NavigationCondition.Edit)
                ArrivalToEdit();

            ArrivalInitialize();
        }

        #endregion
    }
}
