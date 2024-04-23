using CommunityToolkit.Mvvm.ComponentModel;
using DndFightManagerMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;

namespace DndFightManagerMobileApp.ViewModels
{
    public partial class CreateEditBeastNoteStatsViewModel : BaseViewModelHandNavigation
    {
        #region ObservableProperties

        [ObservableProperty] private ObservableCollection<AbilityListModel> _abilities;
        // Hitpoint dices - 3 separate field
        [ObservableProperty] private string _hitPointDiceField1;
        [ObservableProperty] private string _hitPointDiceField2;
        [ObservableProperty] private string _hitPointDiceField3;

        [ObservableProperty] private string _armorClass;

        [ObservableProperty] private string _initiativeBonus;

        [ObservableProperty] private string _specialBonus;


        private bool _hitPointDice1isValid;
        public bool HitPointDice1isValid
        {
            get { return _hitPointDice1isValid; }
            set
            {
                _hitPointDice1isValid = value;
                OnPropertyChanged(nameof(HitPointDice1isValid));
            }
        }

        #endregion
        public CreateEditBeastNoteStatsViewModel()
        {

        }
        private async void InitializeFields()
        {
            Abilities = await dataStore.Ability.GetDefaultList();
            HitPointDiceField1 = string.Empty;
            HitPointDiceField2 = string.Empty;
            HitPointDiceField3 = string.Empty;
            ArmorClass = string.Empty;
            InitiativeBonus = string.Empty;
            SpecialBonus = string.Empty;
        }

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
    }
}
