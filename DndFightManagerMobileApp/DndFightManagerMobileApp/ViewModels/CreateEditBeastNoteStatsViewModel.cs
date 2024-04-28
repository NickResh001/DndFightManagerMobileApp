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
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace DndFightManagerMobileApp.ViewModels
{
    public partial class CreateEditBeastNoteStatsViewModel : BaseViewModelHandNavigation
    {
        private DiceRoller diceRoller = new DiceRoller();

        #region ObservableProperties

        // AbilityCollection
        [ObservableProperty] private ObservableCollection<AbilityListModel> _abilities;

        // HitPointDices 
        private string _hitPointDices;
        public string HitPointDices
        {
            get { return _hitPointDices; }
            set
            {
                if (value == null)
                    return;

                if (diceRoller.IsCorrect(value))
                {
                    _hitPointDices = value;
                    OnPropertyChanged(nameof(HitPointDices));
                }
            }
        }

        // ArmorClass
        private string _armorClass;
        public string ArmorClass
        {
            get { return _armorClass; }
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
                        _armorClass = value;
                        OnPropertyChanged(nameof(ArmorClass));
                    }
                }
                else
                {
                    OnPropertyChanged(nameof(ArmorClass));
                }
            }
        }
        
        // Initiative
        private string _initiativeBonus;
        public string InitiativeBonus
        {
            get { return _initiativeBonus; }
            set
            {
                if (value == null)
                    return;
                // не даем писать то, что не соответствует regex
                if (new Regex(@"^[+-]?\d*$", RegexOptions.Compiled).IsMatch(value))
                {
                    int buffer;
                    if (int.TryParse(value, out buffer))
                    {
                        _initiativeBonus = value;
                        OnPropertyChanged(nameof(InitiativeBonus));
                    }
                }
                else
                {
                    OnPropertyChanged(nameof(InitiativeBonus));
                }
            }
        }

        // SpecialBonus
        private string _specialBonus;
        public string SpecialBonus
        {
            get { return _specialBonus; }
            set
            {
                if (value == null)
                    return;
                // не даем писать то, что не соответствует regex
                if (new Regex(@"^[+]?\d*$", RegexOptions.Compiled).IsMatch(value))
                {
                    int buffer;
                    if (int.TryParse(value, out buffer))
                    {
                        _specialBonus = value;
                        OnPropertyChanged(nameof(SpecialBonus));
                    }
                }
                else
                {
                    OnPropertyChanged(nameof(SpecialBonus));
                }
            }
        }

        // Skills
        private CrudMultiSelectVM _skillsMultiSelect;
        public CrudMultiSelectVM SkillsMultiSelect
        {
            get { return _skillsMultiSelect; }
            set
            {
                if (value != null || value != _skillsMultiSelect) _skillsMultiSelect = value;
                OnPropertyChanged(nameof(SkillsMultiSelect));
            }
        }

        private ObservableCollection<SkillModel> _allSkills;
        
        #endregion

        #region Commands

        public ICommand AutoArmorClassCommand { get; set; }
        public ICommand AutoInitiativeBonusCommand { get; set; }

        public ICommand OnPropertyChangedCommand { get; set; }
        public ICommand AbilityChangedCommand { get; set; }
        #endregion

        public CreateEditBeastNoteStatsViewModel()
        {
            _allSkills = new(dataStore.Skill.GetAll().Result);

            AutoArmorClassCommand = new Command(AutoArmorClass);
            AutoInitiativeBonusCommand = new Command(AutoInitiativeBonus);
            OnPropertyChangedCommand = new Command<string>(OnPropertyChanged);
            AbilityChangedCommand = new Command<string>(AbilityChanged);            
        }
        private async void InitializeFields()
        {
            Abilities = await dataStore.Ability.GetDefaultList();
            HitPointDices = "2#6 + 2";
            ArmorClass = "11";
            InitiativeBonus = "2";
            SpecialBonus = "+2";

            SkillsMultiSelect = new CrudMultiSelectVM
            (
                header: "Владение навыками",
                infoCommandParameter: "",
                allItems: _allSkills.Projection(x => new MultiSelectCRUDHelper(x, "30")),
                haveValue: true
            );
        }


        private void AutoArmorClass()
        {
            if (Abilities != null)
            {
                var ability = Abilities.ToList().First(x => x.Ability.Title == "Ловкость");
                if (ability != null)
                    ArmorClass = (10 + ability.Modifier).ToString();
            }
        }
        private void AutoInitiativeBonus()
        {
            if (Abilities != null)
            {
                var ability = Abilities.ToList().First(x => x.Ability.Title == "Ловкость");
                if (ability != null)
                    InitiativeBonus = ability.Modifier.ToString();
            }
        }

        #region Validation

        private void AbilityChanged(string id)
        {
            var ability = Abilities.ToList().Find(x => x.Id == id);
            ability.Value = ability.Value;
        }
        #endregion

        #region Navigation
        public override async void OnNavigateTo(object parameter)
        {
            if (parameter == null)
            {
                InitializeFields();
            }

        }
        public override object OnNavigateFrom()
        {
            return base.OnNavigateFrom();
        }
        
        #endregion

    }
}
