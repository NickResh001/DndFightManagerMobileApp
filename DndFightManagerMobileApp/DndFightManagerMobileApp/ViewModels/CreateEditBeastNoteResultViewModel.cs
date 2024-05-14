using CommunityToolkit.Mvvm.ComponentModel;
using DndFightManagerMobileApp.Models;
using DndFightManagerMobileApp.Models.ModelHelpers;
using DndFightManagerMobileApp.Services.MockData;
using DndFightManagerMobileApp.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DndFightManagerMobileApp.ViewModels
{
    public partial class CreateEditBeastNoteResultViewModel : BaseViewModelHandNavigation
    {
        private BeastNoteModel _beastNote;
        private DiceRoller _diceRoller = new();

        #region ObservableProperties

        [ObservableProperty] private string _title;
        [ObservableProperty] private string _sizeTypeAndAlignment;
        [ObservableProperty] private string _armorClass;
        [ObservableProperty] private string _hitPoints;
        [ObservableProperty] private string _speeds;
        [ObservableProperty] private ObservableCollection<AbilityListModel> _abilities;

        [ObservableProperty] private string _savethrows;
        [ObservableProperty] private string _skills;
        [ObservableProperty] private string _damageVulnerability;
        [ObservableProperty] private string _damageResistance;
        [ObservableProperty] private string _damageImmunity;
        [ObservableProperty] private string _conditionImmunity;
        public bool IsSavethrowsVisible
        {
            get
            {
                return Savethrows != null && Savethrows.Length > 0;
            }
        }
        public bool IsSkillsVisible
        {
            get
            {
                return Skills != null && Skills.Length > 0;
            }
        }
        public bool IsDamageVulnerabilityVisible
        {
            get
            {
                return DamageVulnerability != null && DamageVulnerability.Length > 0;
            }
        }
        public bool IsDamageResistanceVisible
        {
            get
            {
                return DamageResistance != null && DamageResistance.Length > 0;
            }
        }
        public bool IsDamageImmunityVisible
        {
            get
            {
                return DamageImmunity != null && DamageImmunity.Length > 0;
            }
        }
        public bool IsConditionImmunityVisible
        {
            get
            {
                return ConditionImmunity != null && ConditionImmunity.Length > 0;
            }
        }
        public bool IsVariableSequenceVisible
        {
            get
            {
                return IsSavethrowsVisible || IsSkillsVisible || IsDamageVulnerabilityVisible
                    || IsDamageResistanceVisible || IsDamageImmunityVisible || IsConditionImmunityVisible;
            }
        }

        [ObservableProperty] private string _senses;
        [ObservableProperty] private string _languages;
        [ObservableProperty] private string _specialBonus;
        [ObservableProperty] private string _challengeRating;

        [ObservableProperty] private ObservableCollection<SpellSlotModel> _spellSLots;
        public bool IsSpellSLotsVisible
        {
            get
            {
                return SpellSLots != null && SpellSLots.FirstOrDefault(x => x.Count > 0) != null;
            }
        }

        [ObservableProperty] private ObservableCollection<ActionWatchingHelper> _passiveActions;
        [ObservableProperty] private ObservableCollection<ActionWatchingHelper> _mainActions;
        [ObservableProperty] private ObservableCollection<ActionWatchingHelper> _bonusActions;
        [ObservableProperty] private ObservableCollection<ActionWatchingHelper> _freeActions;
        [ObservableProperty] private ObservableCollection<ActionWatchingHelper> _legendaryActions;
        [ObservableProperty] private ObservableCollection<ActionWatchingHelper> _lairActions;
        [ObservableProperty] private string _lairInitiative;
        [ObservableProperty] private ObservableCollection<ActionWatchingHelper> _reactionActions;
        public bool IsPassiveActionsVisible
        {
            get
            {
                return PassiveActions != null && PassiveActions.Count > 0;
            }
        }
        public bool IsMainActionsVisible
        {
            get
            {
                return MainActions != null && MainActions.Count > 0;
            }
        }
        public bool IsBonusActionsVisible
        {
            get
            {
                return BonusActions != null && BonusActions.Count > 0;
            }
        }
        public bool IsFreeActionsVisible
        {
            get
            {
                return FreeActions != null && FreeActions.Count > 0;
            }
        }
        public bool IsLegendaryActionsVisible
        {
            get
            {
                return LegendaryActions != null && LegendaryActions.Count > 0;
            }
        }
        public bool IsLairActionsVisible
        {
            get
            {
                return LairActions != null && LairActions.Count > 0;
            }
        }
        public bool IsReactionActionsVisible
        {
            get
            {
                return ReactionActions != null && ReactionActions.Count > 0;
            }
        }

        [ObservableProperty] private string _habitats;
        public bool IsHabitatsVisible
        {
            get
            {
                return Habitats != null && Habitats.Length > 0;
            }
        }

        [ObservableProperty] private string _description;
        #endregion

        public CreateEditBeastNoteResultViewModel()
        {

        }
        private void SetupAllProperties()
        {
            #region Title
            {
                Title = _beastNote.Title;
            }
            #endregion
            #region Size, BeastType and Alignment
            {
                string buffer = "";
                buffer += _beastNote.Size.Title + ", ";
                buffer += _beastNote.BeastType.Title + ", ";
                buffer += _beastNote.Alignment.Title;
                SizeTypeAndAlignment = buffer;
            }
            #endregion
            //Image
            #region ArmorClass, HitPoints and Speeds
            {
                ArmorClass = _beastNote.ArmorClass.ToString();

                string hpdices = _beastNote.HitPoitsDice;
                string hp = _diceRoller.GetAverageThrowResult(hpdices).GetResult().ToString();
                HitPoints = $"{hp} ({hpdices})";

                List<string> speeds = _beastNote.SpeedList.Select(s => $"{s.Speed.Title} {s.DistanceInFeet} фт.").ToList();
                string defaultSpeed = speeds.FirstOrDefault(s => s.Contains("Обычная"));
                if (defaultSpeed != null)
                {
                    speeds.Remove(defaultSpeed);
                    defaultSpeed = defaultSpeed.Replace("Обычная ", "");
                    speeds.Insert(0, defaultSpeed);
                }
                string allspeeds = "";
                for (int i = 0; i < speeds.Count; i++)
                {
                    speeds[i] = speeds[i].ToLower();
                    allspeeds += $" {speeds[i]}";
                    if (i != speeds.Count - 1)
                        allspeeds += ",";
                }
                Speeds = allspeeds;
            }
            #endregion
            #region Senses
            {
                string result = "";
                var senses = _beastNote.SenseList.ToList();

                for (int i = 0; i < senses.Count; i++)
                {
                    result += $"{senses[i].Sense.Title} {senses[i].DistanceInFeet} фт.";
                    if (i != senses.Count - 1)
                        result += ", ";
                }

                if (result == "")
                    result = "-";

                Senses = result;
            }
            #endregion
            #region Languages
            {
                string result = "";
                var languages = _beastNote.LanguageList.ToList();

                for (int i = 0; i < languages.Count; i++)
                {
                    result += $"{languages[i].Language.Title}";
                    if (i != languages.Count - 1)
                        result += ", ";
                }

                if (result == "")
                    result = "-";

                Languages = result;
            }
            #endregion
            #region SpecialBonus
            {
                string result = _beastNote.SpecialBonus.ToString();
                if (_beastNote.SpecialBonus >= 0)
                    result = "+" + result;
                SpecialBonus = result;
            }
            #endregion
            #region ChallengeRating
            {
                ChallengeRating = _beastNote.ChallangeRatingString();
            }
            #endregion
            #region Abilities
            {
                Abilities = [.. _beastNote.AbilityList];
            }
            #endregion

            #region Savethrows
            {
                string result = "";
                var abilitList = _beastNote.AbilityList.Where(x => x.SavingThrowProficiency).ToList();
                for (int i = 0; i < abilitList.Count; i++)
                {
                    string buffer = "";
                    buffer += $"{abilitList[i].ShortTitle}. ";

                    int savethrowValue = abilitList[i].Modifier + _beastNote.SpecialBonus;

                    if (savethrowValue >= 0)
                        buffer += "+";
                    buffer += $"{savethrowValue}";

                    result += $"{buffer}";
                    if (i != abilitList.Count)
                        result += ", ";                    
                }

                if (result != "")
                    result = "Спасброски: " + result;

                Savethrows = result;
                OnPropertyChanged(nameof(IsSavethrowsVisible));
            }
            #endregion
            #region Skills
            {
                string result = "";
                var skillCollection = _beastNote.SkillList.Where(x => x.Proficiency).ToList();
                for (int i = 0; i < skillCollection.Count; i++)
                {
                    int modifier = skillCollection[i].Value;

                    string buffer = "";
                    buffer += $"{skillCollection[i].Skill.Title} ";
                    if (modifier >= 0)
                        buffer += "+";
                    buffer += $"{modifier}";

                    result += $"{buffer}";
                    if (i != skillCollection.Count - 1)
                        result += ", ";
                }

                if (result != "")
                    result = "Навыки: " + result;

                Skills = result;

                OnPropertyChanged(nameof(IsSkillsVisible));
            }
            #endregion
            #region DamageVulnerability
            {
                string result = "";
                var damageTend = _beastNote.DamageTendencyList.Where(x => x.DamageTendencyType.Title == "Уязвимость").ToList();

                for (int i = 0; i < damageTend.Count; i++)
                {
                    result += $"{damageTend[i].DamageType.Title}";
                    if (i != damageTend.Count - 1)
                        result += ", ";
                }

                if (result != "")
                    result = "Уязвимость к урону: " + result;

                DamageVulnerability = result;

                OnPropertyChanged(nameof(IsDamageVulnerabilityVisible));
            }
            #endregion
            #region DamageResistance
            {
                string result = "";
                var damageTend = _beastNote.DamageTendencyList.Where(x => x.DamageTendencyType.Title == "Сопротивление").ToList();

                for (int i = 0; i < damageTend.Count; i++)
                {
                    result += $"{damageTend[i].DamageType.Title}";
                    if (i != damageTend.Count - 1)
                        result += ", ";
                }

                if (result != "")
                    result = "Сопротивление к урону: " + result;

                DamageResistance = result;

                OnPropertyChanged(nameof(IsDamageResistanceVisible));
            }
            #endregion
            #region DamageImmunity
            {
                string result = "";
                var damageTend = _beastNote.DamageTendencyList.Where(x => x.DamageTendencyType.Title == "Иммунитет").ToList();

                for (int i = 0; i < damageTend.Count; i++)
                {
                    result += $"{damageTend[i].DamageType.Title}";
                    if (i != damageTend.Count - 1)
                        result += ", ";
                }

                if (result != "")
                    result = "Иммунитет к урону: " + result;

                DamageImmunity = result;

                OnPropertyChanged(nameof(IsDamageImmunityVisible));
            }
            #endregion
            #region ConditionImmunity
            {
                string result = "";
                var condImmu = _beastNote.ConditionImmunitiesList.ToList();
                for (int i = 0; i < condImmu.Count; i++)
                {
                    result += $"{condImmu[i].Condition.Title}";
                    if (i != condImmu.Count - 1)
                        result += ", ";
                }

                if (result != "")
                    result = "Иммунитет к состояниям: " + result;

                ConditionImmunity = result;

                OnPropertyChanged(nameof(IsConditionImmunityVisible));
            }
            #endregion
            OnPropertyChanged(nameof(IsVariableSequenceVisible));
            #region SpellSlots
            {
                ObservableCollection<SpellSlotModel> emptySlots = [];
                for (int i = 1; i <= 9; i++)
                {
                    emptySlots.Add(new SpellSlotModel
                    {
                        Level = i,
                        Count = 0
                    });
                }

                ObservableCollection<SpellSlotModel> actualSlots = [.. _beastNote.SpellSlots];
                foreach (var slot in actualSlots)
                {
                    var emptySlot = emptySlots.FirstOrDefault(x => x.Level == slot.Level);
                    if (emptySlot != null)
                    {
                        emptySlots.Remove(emptySlot);
                        emptySlots.Add(slot);
                    }
                }

                SpellSLots = emptySlots.Sort((x, y) => x.Level - y.Level);
                OnPropertyChanged(nameof(IsSpellSLotsVisible));
            }
            #endregion
            #region PassiveActions
            {
                var passiveActions = _beastNote.Actions
                    .Where(x => x.ActionResource.Title == "Пассивное")
                    .Select(x => new ActionWatchingHelper(x))
                    .ToList();

                PassiveActions = [.. passiveActions];
                OnPropertyChanged(nameof(IsPassiveActionsVisible));
            }
            #endregion
            #region ReactionActions
            {
                var reactionActions = _beastNote.Actions
                    .Where(x => x.ActionResource.Title == "Реакцией")
                    .Select(x =>
                    {
                        string condition = $"Условие: {x.Reaction_Condition}";
                        return new ActionWatchingHelper(x, condition);
                    })
                    .ToList();

                reactionActions.Sort((x, y) =>
                {
                    int xValue = x.IsMultiaction ? 1 : 0;
                    int yValue = y.IsMultiaction ? 1 : 0;
                    return yValue - xValue;
                });

                ReactionActions = [.. reactionActions];
                OnPropertyChanged(nameof(IsReactionActionsVisible));
            }
            #endregion
            #region MainActions
            {
                var mainActions = _beastNote.Actions
                    .Where(x => x.ActionResource.Title == "Основное")
                    .Select(x => new ActionWatchingHelper(x))
                    .ToList();

                mainActions.Sort((x, y) =>
                {
                    int xValue = x.IsMultiaction ? 1 : 0;
                    int yValue = y.IsMultiaction ? 1 : 0;
                    return yValue - xValue;
                });

                MainActions = [ ..mainActions];
                OnPropertyChanged(nameof(IsMainActionsVisible));
            }
            #endregion
            #region BonusActions
            {
                var bonusActions = _beastNote.Actions
                    .Where(x => x.ActionResource.Title == "Бонусное")
                    .Select(x => new ActionWatchingHelper(x))
                    .ToList();

                bonusActions.Sort((x, y) =>
                {
                    int xValue = x.IsMultiaction ? 1 : 0;
                    int yValue = y.IsMultiaction ? 1 : 0;
                    return yValue - xValue;
                });

                BonusActions = [.. bonusActions];
                OnPropertyChanged(nameof(IsBonusActionsVisible));
            }
            #endregion
            #region FreeActions
            {
                var freeActions = _beastNote.Actions
                    .Where(x => x.ActionResource.Title == "Свободное") 
                    .Select(x => new ActionWatchingHelper(x))
                    .ToList();

                freeActions.Sort((x, y) =>
                {
                    int xValue = x.IsMultiaction ? 1 : 0;
                    int yValue = y.IsMultiaction ? 1 : 0;
                    return yValue - xValue;
                });

                FreeActions = [.. freeActions];
                OnPropertyChanged(nameof(IsFreeActionsVisible));
            }
            #endregion
            #region LegendaryActions
            {
                var legendaryActions = _beastNote.Actions
                    .Where(x => x.ActionResource.Title == "Легендарное")
                    .Select(x => new ActionWatchingHelper(x))
                    .ToList();

                legendaryActions.Sort((x, y) =>
                {
                    int xValue = x.IsMultiaction ? 1 : 0;
                    int yValue = y.IsMultiaction ? 1 : 0;
                    return yValue - xValue;
                });

                LegendaryActions = [.. legendaryActions];
                OnPropertyChanged(nameof(IsLegendaryActionsVisible));
            }
            #endregion
            #region LairActions
            {
                var lairActions = _beastNote.Actions
                    .Where(x => x.ActionResource.Title == "Логова")
                    .Select(x => new ActionWatchingHelper(x))
                    .ToList();

                lairActions.Sort((x, y) =>
                {
                    int xValue = x.IsMultiaction ? 1 : 0;
                    int yValue = y.IsMultiaction ? 1 : 0;
                    return yValue - xValue;
                });

                LairActions = [.. lairActions];
                if (LairActions != null && LairActions.Count > 0)
                    LairInitiative = "Инициатива логова: " + _beastNote.Actions[0].Lair_InitiativeBonus.ToString();
                else
                    LairInitiative = "";
                OnPropertyChanged(nameof(IsLairActionsVisible));
            }
            #endregion

            #region Habitats
            {
                List<string> habs = [.. _beastNote.HabitatList.Select(x => x.Habitat.Title)];
                string habitats = "";
                for (int i = 0; i < habs.Count; i++)
                {
                    habitats += habs[i];
                    if (i != habs.Count - 1)
                        habitats += ", ";
                }
                Habitats = habitats;
                OnPropertyChanged(nameof(IsHabitatsVisible));
            }
            #endregion
            #region Description
            {
                Description = _beastNote.Description;
            }
            #endregion

        }

        #region Navigation

        public override async void OnNavigateTo(object parameter)
        {
            if (parameter is BeastNoteModel incomeBeast)
            {
                _beastNote = incomeBeast;
                //await Task.Run(SetupAllProperties);
                SetupAllProperties();
            }
        }

        public override object OnNavigateFrom()
        {
            return _beastNote;
        }

        #endregion
    }
}
