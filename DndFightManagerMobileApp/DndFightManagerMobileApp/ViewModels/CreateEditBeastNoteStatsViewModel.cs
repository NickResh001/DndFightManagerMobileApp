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
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace DndFightManagerMobileApp.ViewModels
{
    public partial class CreateEditBeastNoteStatsViewModel : BaseViewModelHandNavigation
    {
        private DiceRoller diceRoller = new DiceRoller();
        private BeastNoteModel _beastNote;

        #region ObservableProperties

        // AbilityCollection
        [ObservableProperty] 
        private ObservableCollection<AbilityListModel> _abilities;

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
        [ObservableProperty]
        private CrudMultiSelectVM _skillsMultiSelect;

        // Speeds
        [ObservableProperty]
        private CrudMultiSelectVM _speedsMultiSelect;

        // Senses
        [ObservableProperty]
        private CrudMultiSelectVM _sensesMultiSelect;

        #endregion

        private ObservableCollection<SkillModel> _allSkills;
        private ObservableCollection<SpeedModel> _allSpeeds;
        private ObservableCollection<SenseModel> _allSenses;

        #region Commands

        public ICommand AutoArmorClassCommand { get; set; }
        public ICommand AutoInitiativeBonusCommand { get; set; }

        public ICommand OnPropertyChangedCommand { get; set; }
        public ICommand AbilityChangedCommand { get; set; }
        #endregion

        public CreateEditBeastNoteStatsViewModel()
        {
            _allSkills = new(dataStore.Skill.GetAll().Result);
            _allSpeeds = new(dataStore.Speed.GetAll().Result);
            _allSenses = new(dataStore.Sense.GetAll().Result);

            AutoArmorClassCommand = new Command(AutoArmorClass);
            AutoInitiativeBonusCommand = new Command(AutoInitiativeBonus);
            OnPropertyChangedCommand = new Command<string>(OnPropertyChanged);
            AbilityChangedCommand = new Command<string>(AbilityChanged);            
        }


        private void AutoArmorClass()
        {
            if (Abilities != null)
            {
                var ability = Abilities.ToList().FirstOrDefault(x => x.Ability.Title == "Ловкость");
                if (ability != null)
                    ArmorClass = (10 + ability.Modifier).ToString();
            }
        }
        private void AutoInitiativeBonus()
        {
            if (Abilities != null)
            {
                var ability = Abilities.ToList().FirstOrDefault(x => x.Ability.Title == "Ловкость");
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
        public override void OnNavigateTo(object parameter)
        {
            if (parameter is BeastNoteModel incomeBeast)
            {
                _beastNote = incomeBeast;

                Abilities = _beastNote.AbilityList.ToObservableCollection();
                HitPointDices = _beastNote.HitPoitsDice;
                ArmorClass = _beastNote.ArmorClass.ToString();
                InitiativeBonus = _beastNote.InitiativeBonus.ToString();
                SpecialBonus = _beastNote.SpecialBonus.ToString();

                ObservableCollection<MultiSelectCRUDHelper> skillItems = [];
                foreach (var skill in _allSkills)
                {
                    bool selected = false;
                    foreach (var skillList in _beastNote.SkillList)
                    {
                        if (skillList.Skill.Id == skill.Id)
                        {
                            selected = skillList.Proficiency;
                            break;
                        }
                    }
                    skillItems.Add(new MultiSelectCRUDHelper(skill, "", selected));
                }
                SkillsMultiSelect = new CrudMultiSelectVM
                (
                    header: "Владение навыками",
                    infoCommandParameter: "",
                    allItems: skillItems
                );

                ObservableCollection<MultiSelectCRUDHelper> speedItems = [];
                foreach (var speed in _allSpeeds)
                {
                    bool selected = false;
                    string value = "";
                    foreach (var speedList in _beastNote.SpeedList)
                    {
                        if (speed.Id == speedList.Speed.Id)
                        {
                            selected = true;
                            value = speedList.DistanceInFeet.ToString();
                            break;
                        }
                    }
                    speedItems.Add(new MultiSelectCRUDHelper(speed, value, selected));
                }
                SpeedsMultiSelect = new CrudMultiSelectVM
                (
                    header: "Скорости",
                    infoCommandParameter: "",
                    allItems: speedItems,
                    haveValue: true
                );

                ObservableCollection<MultiSelectCRUDHelper> senseItems = [];
                foreach (var sense in _allSenses)
                {
                    bool selected = false;
                    string value = "";
                    foreach (var senseList in _beastNote.SenseList)
                    {
                        if (sense.Id == senseList.Sense.Id)
                        {
                            selected = true;
                            value = senseList.DistanceInFeet.ToString();
                            break;
                        }
                    }
                    senseItems.Add(new MultiSelectCRUDHelper(sense, value, selected));
                }
                SensesMultiSelect = new CrudMultiSelectVM
                (
                    header: "Чувства",
                    infoCommandParameter: "",
                    allItems: senseItems,
                    haveValue: true
                );
            }
        }
        public override object OnNavigateFrom()
        {
            // Pack Changes
            //
            //      HitPointDices
            //      ArmorClass
            //      Initiative
            //      SpecialBonus
            //      AbilityCollection
            //
            //      Skills
            //      Speeds
            //      Senses

            _beastNote.HitPoitsDice = HitPointDices;
            _beastNote.ArmorClass = int.Parse(ArmorClass);
            _beastNote.InitiativeBonus = int.Parse(InitiativeBonus);
            _beastNote.SpecialBonus = int.Parse(SpecialBonus);
            _beastNote.AbilityList = Abilities.ToList();

            List<SkillListModel> skillList = [];
            foreach(var helper in SkillsMultiSelect.AllItems)
            {
                SkillModel skill = helper.DirectoryModel as SkillModel;
                string abilityId = skill.Ability.Id;
                AbilityListModel abilityList = 
                    _beastNote.AbilityList.FirstOrDefault(x => x.Ability.Id == abilityId);

                int skillValue = -100;
                bool skillProficiency = helper.Selected;
                if (abilityList != null)
                {
                    skillValue = abilityList.Value;
                    if (skillProficiency)
                        skillValue += _beastNote.SpecialBonus;
                }

                skillList.Add(new SkillListModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Skill = skill,
                    Value = skillValue,
                    Proficiency = skillProficiency
                });
            }
            _beastNote.SkillList = skillList;

            List<SpeedListModel> speedList = [];
            foreach(var helper in SpeedsMultiSelect.SelectedItems)
            {
                speedList.Add(new SpeedListModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Speed = helper.DirectoryModel as SpeedModel,
                    DistanceInFeet = int.Parse(helper.Value),
                });
            }
            _beastNote.SpeedList = speedList;

            List<SenseListModel> senseList = [];
            foreach (var helper in SensesMultiSelect.SelectedItems)
            {
                senseList.Add(new SenseListModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Sense = helper.DirectoryModel as SenseModel,
                    DistanceInFeet = int.Parse(helper.Value),
                });
            }
            _beastNote.SenseList = senseList;

            return _beastNote;
        }
        
        #endregion

    }
}
