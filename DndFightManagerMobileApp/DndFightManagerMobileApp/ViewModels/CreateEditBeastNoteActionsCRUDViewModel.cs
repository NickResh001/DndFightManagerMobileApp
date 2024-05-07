using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DndFightManagerMobileApp.Controls.ViewModels;
using DndFightManagerMobileApp.Models;
using DndFightManagerMobileApp.Models.ModelHelpers;
using DndFightManagerMobileApp.Utils;
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
        private DiceRoller diceRoller = new DiceRoller();

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


        private string _howManyTimes;
        public string HowManyTimes
        {
            get { return _howManyTimes; }
            set
            {
                if (value == null)
                    return;

                if (new Regex(@"^0+$", RegexOptions.Compiled).IsMatch(value))
                    value = "1";

                if (new Regex(@"^\d*$", RegexOptions.Compiled).IsMatch(value))
                {
                    int buffer;
                    if (int.TryParse(value, out buffer))
                    {
                        _howManyTimes = buffer.ToString();
                        OnPropertyChanged(nameof(HowManyTimes));
                    }
                }
                else
                {
                    OnPropertyChanged(nameof(HowManyTimes));
                }
            }
        }


        private string _measureMultiply;
        public string MeasureMultiply
        {
            get { return _measureMultiply; }
            set
            {
                if (value == null)
                    return;

                if (new Regex(@"^0+$", RegexOptions.Compiled).IsMatch(value))
                    value = "1";

                if (new Regex(@"^\d*$", RegexOptions.Compiled).IsMatch(value))
                {
                    int buffer;
                    if (int.TryParse(value, out buffer))
                    {
                        _measureMultiply = buffer.ToString();
                        OnPropertyChanged(nameof(MeasureMultiply));
                    }
                }
                else
                {
                    OnPropertyChanged(nameof(MeasureMultiply));
                }
            }
        }

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

        #region ActionResource

        [ObservableProperty]
        private ObservableCollection<ActionResourceModel> _allActionResources;

        // Обычные: Основное, бонусное, свободное, пассивное, легендарное
        
        private ActionResourceModel _selectedActionResource;
        public ActionResourceModel SelectedActionResource
        {
            get { return _selectedActionResource; }
            set
            {
                if (value != null || value != _selectedActionResource) 
                    _selectedActionResource = value;

                OnPropertyChanged(nameof(SelectedActionResource));
                OnPropertyChanged(nameof(IsLairActionResource));
                OnPropertyChanged(nameof(IsReactionActionResource));
            }
        }

        // Реакцией
        public bool IsReactionActionResource
        {
            get
            {
                if (SelectedActionResource == null)
                    return false;
                else
                    return SelectedActionResource.Title == "Реакцией";
            }
        }

        [ObservableProperty]
        private string _reactionCondition;
        // Логова
        public bool IsLairActionResource
        {
            get
            {
                if (SelectedActionResource == null)
                    return false;
                else
                    return SelectedActionResource.Title == "Логова";
            }
        }


        private string _lairInitiative;
        public string LairInitiative
        {
            get { return _lairInitiative; }
            set
            {
                if (value == null)
                    return;

                if (new Regex(@"^0+$", RegexOptions.Compiled).IsMatch(value))
                    value = "1";

                if (new Regex(@"^\d*$", RegexOptions.Compiled).IsMatch(value))
                {
                    int buffer;
                    if (int.TryParse(value, out buffer))
                    {
                        _lairInitiative = buffer.ToString();
                        OnPropertyChanged(nameof(LairInitiative));
                    }
                }
                else
                {
                    OnPropertyChanged(nameof(LairInitiative));
                }
            }
        }
        #endregion

        #region ActionType

        [ObservableProperty]
        private ObservableCollection<string> _allActionTypes;


        private string _selectedActionType;
        public string SelectedActionType
        {
            get { return _selectedActionType; }
            set
            {
                if (value == null)
                    return;

                _selectedActionType = value;
                OnPropertyChanged(nameof(SelectedActionType));
                OnPropertyChanged(nameof(IsCommonActionType));
                OnPropertyChanged(nameof(IsMultiActionType));
            }
        }

        #endregion

        #region CommonAction

        public bool IsCommonActionType
        {
            get
            {
                if (SelectedActionType == null)
                    return false;
                else
                    return SelectedActionType == "Действие";
            }
        }

        [ObservableProperty]
        private string _actionDescription;

        [ObservableProperty]
        private ObservableCollection<ActionThrowModel> _actionThrows;

        public bool IsActionThrowExist 
        { 
            get
            {
                if (ActionThrows == null)
                    return false;
                else
                    return ActionThrows.Count > 0;
            }
        }

        #endregion

        #region MultiAction
        public bool IsMultiActionType
        {
            get
            {
                if (SelectedActionType == null)
                    return false;
                else
                    return SelectedActionType == "Мультидействие";
            }
        }

        [ObservableProperty]
        private CrudMultiSelectVM _multiActionMS;

        #endregion

        #endregion

        private ActionModel _action;

        public CreateEditBeastNoteActionsCRUDViewModel()
        {
            AllTimeMeasures = new(dataStore.TimeMeasure.GetAll().Result);
            AllActionResources = new(dataStore.ActionResource.GetAll().Result);

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
                Cooldown3_MeasureMultiply = 1,
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

            // Откат
            AllCooldownTypes = new(dataStore.CooldownType.GetAll().Result);
            if (_spellSlots == null || _spellSlots.Count == 0)
            {
                AllCooldownTypes.Remove(AllCooldownTypes.FirstOrDefault(x => x.Title == "Ячейки заклинаний"));
            }

            SelectedCooldown = AllCooldownTypes.FirstOrDefault(x => x.Id == _action.CooldownType.Id);
            SelectedCooldown ??= AllCooldownTypes[0];

            // Откат: Ячейки
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

            // Откат: Перезарядка
            LowerRangeLimit = _action.Cooldown2_LowerRangeLimit.ToString();
            UpperRangeLimit = _action.Cooldown2_UpperRangeLimit.ToString();
            DiceSize = _action.Cooldown2_DiceSize.ToString();

            // Откат: Время
            SelectedTimeMeasure = _action.Cooldown3_TimeMeasure;
            SelectedTimeMeasure ??= AllTimeMeasures[0];
            HowManyTimes = _action.Cooldown3_HowManyTimes.ToString();
            MeasureMultiply = _action.Cooldown3_MeasureMultiply.ToString();

            // Ресурс
            SelectedActionResource = _action.ActionResource;
            SelectedActionResource ??= AllActionResources[0];

            // Ресурс: Реакция
            ReactionCondition = _action.Reaction_Condition;

            // Ресурс: Логова
            LairInitiative = _action.Lair_InitiativeBonus.ToString();

            // Тип действия
            AllActionTypes = ["Действие"];
            if (_actions != null && _actions.Count > 0)
                AllActionTypes.Add("Мультидействие");

            var actionTypeTitle = _action.ChildActions == null || _action.ChildActions.Count == 0 ?
                "Действие" : "Мультидействие";

            SelectedActionType = AllActionTypes.FirstOrDefault(x => x == actionTypeTitle);

            // Тип действия: действие
            ActionDescription = _action.Description;
            ActionThrows = new(_action.ActionThrows);

            // Тип действия: мультидействие

            ObservableCollection<MultiSelectCRUDHelper> actionsMS = [];
            foreach (var justAction in _actions)
            {
                bool selected = false;

                foreach (var childAction in _action.ChildActions)
                {
                    if(childAction.Id == justAction.Id)
                    {
                        selected = true; 
                        break;
                    }
                }

                var multiaction = new MultiActionList 
                { 
                    Id = Guid.NewGuid().ToString(),
                    ChildAction = justAction,
                    SequenceNumber = actionsMS.Count,
                    RepititionNumber = 1
                };

                actionsMS.Add(new MultiSelectCRUDHelper(multiaction, multiaction.RepititionNumber.ToString(), selected));
            }

            MultiActionMS = new CrudMultiSelectVM
            (
                header: "Содержит действия",
                infoCommandParameter: "",
                allItems: actionsMS,
                haveValue: true
            );
        }
        private void AssembleAction()
        {
            _action.Title = ActionTitle;
            _action.CooldownType = SelectedCooldown;

            _action.Cooldown1_SpellSlotLevel = int.Parse(SelectedSpellSlot);
            _action.Cooldown2_LowerRangeLimit = int.Parse(LowerRangeLimit);
            _action.Cooldown2_UpperRangeLimit = int.Parse(UpperRangeLimit);
            _action.Cooldown2_DiceSize = int.Parse(DiceSize);
            _action.Cooldown3_TimeMeasure = SelectedTimeMeasure;
            _action.Cooldown3_HowManyTimes = int.Parse(HowManyTimes);
            _action.Cooldown3_MeasureMultiply = int.Parse(MeasureMultiply);

            _action.ActionResource = SelectedActionResource;
            _action.Reaction_Condition = ReactionCondition;
            _action.Lair_InitiativeBonus = int.Parse(LairInitiative);

            _action.Description = ActionDescription;
            _action.ActionThrows = [.. ActionThrows];

            List<MultiActionList> childActions = [];
            foreach(var helper in MultiActionMS.SelectedItems)
            {
                if (helper.DirectoryModel is MultiActionList multiAction)
                {
                    multiAction.RepititionNumber = int.Parse(helper.Value);
                    childActions.Add(multiAction);
                }
            }
            _action.ChildActions = childActions;
        }

        [RelayCommand]
        private void MaintainActionThrows()
        {
            // пока тесты

            var matches = new Regex(@"\s*[\d\s-+\\*\\^\\(\\)кd#]{2,}\s*").Matches(ActionDescription);

            List<string> strThrows = [];
            foreach (Match match in matches)
            {
                if (diceRoller.IsCorrect(match.Value))
                {
                    string buffer = match.Value.Replace(" ", "");
                    strThrows.Add(buffer);
                }
            }

            int extraCount = ActionThrows.Count - strThrows.Count;
            for (int i = 0; i < extraCount; i++)
            {
                ActionThrows.RemoveAt(ActionThrows.Count - 1);
            }
            extraCount *= -1;
            for (int i = 0; i < extraCount; i++)
            {
                ActionThrows.Add(new ActionThrowModel
                {
                    Id = Guid.NewGuid().ToString(),
                });
            }

            for(int i = 0; i < ActionThrows.Count; i++)
            {
                ActionThrows[i].Throw = strThrows[i];
            }

            OnPropertyChanged(nameof(IsActionThrowExist));
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
