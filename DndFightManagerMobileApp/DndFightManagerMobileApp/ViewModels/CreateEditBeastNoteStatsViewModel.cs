using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DndFightManagerMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DndFightManagerMobileApp.ViewModels
{
    public partial class CreateEditBeastNoteStatsViewModel : BaseViewModelHandNavigation
    {
        //private DiceRoller diceRoller = new DiceRoller();

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
                if (true/*diceRoller.IsCorrect(value)*/)
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
                int buffer;
                if (int.TryParse(value, out buffer))
                    _armorClass = buffer.ToString();
                else if (value == string.Empty)
                    _armorClass = 11.ToString();

                OnPropertyChanged(nameof(ArmorClass));
            }
        }
        
        // Initiative
        private string _initiativeBonus;
        public string InitiativeBonus
        {
            get { return _initiativeBonus; }
            set
            {
                int buffer;
                if (int.TryParse(value, out buffer))
                {
                    _initiativeBonus = value;
                    OnPropertyChanged(nameof(InitiativeBonus));
                }
            }
        }

        #endregion

        #region Commands

        public ICommand AutoArmorClassCommand { get; set; }
        public ICommand AutoInitiativeBonusCommand { get; set; }

        public ICommand AbilityChangedCommand { get; set; }
        public ICommand HitPointDicesChangedCommand { get; set; }
        public ICommand InitiativeBonusChangedCommand { get; set; }

        #endregion

        public CreateEditBeastNoteStatsViewModel()
        {
            AutoArmorClassCommand = new Command(AutoArmorClass);
            AutoInitiativeBonusCommand = new Command(AutoInitiativeBonus);

            AbilityChangedCommand = new Command<string>(AbilityChanged);
            HitPointDicesChangedCommand = new Command(HitPointDicesChanged);
            InitiativeBonusChangedCommand = new Command(InitiativeBonusChanged);
        }
        private async void InitializeFields()
        {
            Abilities = await dataStore.Ability.GetDefaultList();
            HitPointDices = "2#6 + 2";
            ArmorClass = string.Empty;
            InitiativeBonus = "2";
            //SpecialBonus = string.Empty;
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

        private void HitPointDicesChanged()
        {
            OnPropertyChanged(nameof(HitPointDices));
        }

        private void InitiativeBonusChanged()
        {
            OnPropertyChanged(nameof(InitiativeBonus));
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
