using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Reflection;
using System.Text;
using Xamarin.Forms.Xaml;

namespace DndFightManagerMobileApp.Models.ModelHelpers
{
    public enum ManagedBeastHelperType
    {
        Beast,
        Player,
        Lair
    }
    public partial class ManagedBeastHelper : ObservableObject
    {
        public string Id { get; set; }
        public string BeastId { get; set; }
        public string Title { get; set; }
        public string ArmorClass { get; set; }
        public string CurrentHP { get; set; }
        public string MaxHP { get; set; }
        public FightTeamModel FightTeam { get; set; }

        [ObservableProperty]
        private bool _isSuprised;
        public int SequenceNumber { get; set; }
        public string InitiativeDice { get; set; }
        public string CurrentInitiative { get; set; }
        public List<ActionResourceListModel> ActionResourceList { get; set; }

        private ManagedBeastHelperType _beastHelperType;
        public ManagedBeastHelperType BeastHelperType
        {
            get { return _beastHelperType; }
            set
            {
                _beastHelperType = value;
                OnPropertyChanged(nameof(BeastHelperType));
                OnPropertyChanged(nameof(IsBeast));
                OnPropertyChanged(nameof(IsPlayer));
                OnPropertyChanged(nameof(IsLair));
            }
        }

        public bool IsBeast { get => BeastHelperType == ManagedBeastHelperType.Beast; }
        public bool IsPlayer { get => BeastHelperType == ManagedBeastHelperType.Player; }
        public bool IsLair { get => BeastHelperType == ManagedBeastHelperType.Lair; }
        
        [ObservableProperty]
        public bool _isSelected;

        [ObservableProperty]
        public bool _isKilled;
        public string LairTitle { get; set; }

        //=========

        public string ShowingHP 
        { 
            get
            {
                return $"{CurrentHP}/{MaxHP}";
            } 
        }
        public string ShowingTeam
        {
            get
            {
                if (FightTeam == null)
                    return "Против всех";
                else
                    return $"{FightTeam.Title}";
            }
        }
        public string ChallengeRatingString { get; set; }
        public ManagedBeastHelper()
        {

        }

        public ManagedBeastHelper(BeastModel beast, ManagedBeastHelperType beastHelperType = ManagedBeastHelperType.Beast)
        {
            Id = Guid.NewGuid().ToString();
            BeastHelperType = beastHelperType;
            IsSelected = false;
            IsKilled = false;

            if (BeastHelperType == ManagedBeastHelperType.Beast)
            {
                BeastId = beast.Id;
                Title = beast.Title;
                ArmorClass = beast.CurrentArmorClass.ToString();
                CurrentHP = beast.CurrentHitPoints.ToString();
                MaxHP = beast.MaxHitPoints.ToString();
                FightTeam = beast.FightTeam;
                IsSuprised = beast.IsSuprised;
                SequenceNumber = 0;
                InitiativeDice = beast.InitiativeDice;
                CurrentInitiative = beast.CurrentInitiative;
                ChallengeRatingString = beast.ChallangeRatingString();
            }
            else if (BeastHelperType == ManagedBeastHelperType.Player)
            {
                Title = beast.Title;
                FightTeam = beast.FightTeam;
                IsSuprised = beast.IsSuprised;
                CurrentInitiative = beast.CurrentInitiative;
            }
            else if (BeastHelperType == ManagedBeastHelperType.Lair)
            {
                BeastId = beast.Id;
                Title = beast.Title;
                LairTitle = $"{Title} (Логово)";
                FightTeam = beast.FightTeam;
                CurrentInitiative = beast.LairInitiative.ToString();
            }
        }
    }
}
