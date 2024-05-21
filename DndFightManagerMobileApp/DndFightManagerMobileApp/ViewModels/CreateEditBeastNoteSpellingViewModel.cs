using CommunityToolkit.Mvvm.ComponentModel;
using DndFightManagerMobileApp.Controls.ViewModels;
using DndFightManagerMobileApp.Models;
using DndFightManagerMobileApp.Models.ModelHelpers;
using DndFightManagerMobileApp.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;

namespace DndFightManagerMobileApp.ViewModels
{
    public partial class CreateEditBeastNoteSpellingViewModel : BaseViewModelHandNavigation
    {
        private BeastNoteModel _beastNote;

        #region ObservableProperties

        // Не использует заклинания

        [ObservableProperty]
        private bool _isNotUsesSpelling; 

        // Характеристика заклинателя

        [ObservableProperty]
        private ObservableCollection<AbilityListModel> _allSpellAbilities;

        [ObservableProperty]
        private AbilityListModel _selectedSpellAbility;

        // Сложность спасброска

        private string _saveThrowDifficulty;
        public string SaveThrowDifficulty
        {
            get { return _saveThrowDifficulty; }
            set
            {
                if (value == null)
                    return;

                // не даем писать то, что не соответствует regex
                if (new Regex(@"^\d*$", RegexOptions.Compiled).IsMatch(value))
                {
                    int buffer;
                    if (int.TryParse(value, out buffer))
                    {
                        _saveThrowDifficulty = buffer.ToString();
                        OnPropertyChanged(nameof(SaveThrowDifficulty));
                    }
                }
                else
                {
                    OnPropertyChanged(nameof(SaveThrowDifficulty));
                }
            }
        }

        // Бонус к попаданию
        private string _spellAttackBonus;
        public string SpellAttackBonus
        {
            get { return _spellAttackBonus; }
            set
            {
                if (value == null)
                    return;

                // не даем писать то, что не соответствует regex
                if (new Regex(@"^[-+]?\d*$", RegexOptions.Compiled).IsMatch(value))
                {
                    int buffer;
                    if (int.TryParse(value, out buffer))
                    {
                        _spellAttackBonus = buffer.ToString();
                        OnPropertyChanged(nameof(SpellAttackBonus));
                    }
                }
                else
                {
                    OnPropertyChanged(nameof(SpellAttackBonus));
                }
            }
        }

        // Ячейки
        [ObservableProperty]
        private CrudMultiSelectVM _spellSlotsMS;

        #endregion

        private ObservableCollection<SpellSlotCrudHelper> _allSpellSlots;

        #region Commands

        public ICommand AutoSaveThrowDifficultyCommand { get; set; }
        public ICommand AutoSpellAttackBonusCommand { get; set; }

        #endregion

        public CreateEditBeastNoteSpellingViewModel() 
        {
            AllSpellAbilities = [];
            _allSpellSlots = [];
            for (int i = 1; i <= 9; i++)
            {
                _allSpellSlots.Add(SpellSlotCrudHelper.Create(i));
            }

            AutoSaveThrowDifficultyCommand = new Command(AutoSaveThrowDifficulty);
            AutoSpellAttackBonusCommand = new Command(AutoSpellAttackBonus);
        }

        private void AutoSaveThrowDifficulty()
        {
            SaveThrowDifficulty = (8 + SelectedSpellAbility.Modifier + _beastNote.SpecialBonus).ToString();
        }
        private void AutoSpellAttackBonus()
        {
            SpellAttackBonus = (SelectedSpellAbility.Modifier + _beastNote.SpecialBonus).ToString();
        }

        #region Navigation

        public override void OnNavigateTo(object parameter)
        {
            if (parameter is BeastNoteModel incomeBeast)
            {
                _beastNote = incomeBeast;

                AllSpellAbilities = [.. _beastNote.AbilityList.Where(x =>
                    x.Ability.Title == "Интеллект" ||
                    x.Ability.Title == "Мудрость" ||
                    x.Ability.Title == "Харизма")];

                if (_beastNote.SpellAbility != null)
                {
                    SelectedSpellAbility = AllSpellAbilities.FirstOrDefault(x => x.Ability.Title == _beastNote.SpellAbility.Title);
                }
                else
                {
                    SelectedSpellAbility = AllSpellAbilities[0];
                }

                AutoSaveThrowDifficulty();
                if (_beastNote.SpellSaveThrowDifficulty != null)
                    SaveThrowDifficulty = _beastNote.SpellSaveThrowDifficulty.ToString();

                AutoSpellAttackBonus();
                if (_beastNote.SpellAttackBonus != null)
                    SpellAttackBonus = _beastNote.SpellAttackBonus.ToString();

                ObservableCollection<MultiSelectCRUDHelper> spellSlotsItems = [];

                for (int i = 1; i <= 9; i++)
                {
                    if (_beastNote.SpellSlots.FirstOrDefault(x => x.Level == i) == null)
                    {
                        _beastNote.SpellSlots.Add(new SpellSlotModel()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Level = i,
                            Count = 0
                        });
                    }
                }
                foreach (var spellSlot in _beastNote.SpellSlots)
                {
                    var spellSlotHepler = new SpellSlotCrudHelper(spellSlot);
                    int count = spellSlot.Count;
                    bool selected = count > 0;
                    spellSlotsItems.Add(new MultiSelectCRUDHelper(spellSlotHepler, count.ToString(), selected, 2));
                }
                SpellSlotsMS = new CrudMultiSelectVM
                (
                    header: "Ячейки заклинаний",
                    infoCommandParameter: "",
                    allItems: spellSlotsItems,
                    haveValue: true
                );
            }
        }

        public override object OnNavigateFrom()
        {
            // Pack Changes
            //      IsNotUsesSpelling
            //      SpellAbility
            //      SpellAttackBonus
            //      SpellSaveThrowDifficulty
            //      SpellSlots

            _beastNote.SpellAbility = SelectedSpellAbility.Ability;
            _beastNote.SpellSaveThrowDifficulty = int.Parse(SaveThrowDifficulty);
            _beastNote.SpellAttackBonus = int.Parse(SpellAttackBonus);

            List<SpellSlotModel> spellSlots = [];
            foreach (var crudHelper in SpellSlotsMS.SelectedItems)
            {
                SpellSlotCrudHelper spellHelper = crudHelper.DirectoryModel as SpellSlotCrudHelper;
                spellSlots.Add(new SpellSlotModel
                {
                    Id = spellHelper.Id,
                    Level = spellHelper.SpellSlot.Level,
                    Count = int.Parse(crudHelper.Value)
                });
            }
            _beastNote.SpellSlots = spellSlots;

            AllSpellAbilities.Clear();
            return _beastNote;
        }

        #endregion
    }
}
