using DndFightManagerMobileApp.Utils;
using DndFightManagerMobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DndFightManagerMobileApp.Models
{
    public class BeastModel : BaseEntityModel
    {
        private static DiceRoller diceRoller = new DiceRoller();

        #region Original Props
        public int CurrentArmorClass { get; set; }
        public string Title { get; set; }
        public int MaxHitPoints { get; set; }
        public int CurrentHitPoints { get; set; }
        public int TemporaryHitPoints { get; set; } = 0;
        public bool IsSuprised { get; set; } = false;
        public string CurrentInitiative { get; set; }
        public FightTeamModel FightTeam { get; set; } = null;
        public string BeastNoteId { get; set; }

        public List<AbilityListModel> TemporaryAbilityList { get; set; } = [];
        public List<SpellSlotListModel> SpellSlotList { get; set; } = [];
        public List<ActionResourceListModel> ActionResources { get; set; } = [];
        public List<ConditionListModel> Conditions { get; set; } = [];
        #endregion

        #region Inherit Props
        public double ChallengeRating { get; set; }
        public string ChallangeRatingString()
        {
            if (ChallengeRating == 0.5)
                return "1/2";
            else if (ChallengeRating == 0.25)
                return "1/4";
            else if (ChallengeRating == 0.125)
                return "1/8";
            else
                return ((int)ChallengeRating).ToString();
        }
        public int InitiativeBonus { get; set; }
        public string BeastNoteTitle { get; set; }
        public List<SkillListModel> Skills { get; set; }
        public int LairInitiative { get; set; }
        public List<ActionModel> Actions { get; set; } = [];
        #endregion

        #region Additional Props
        public int SequenceNumber { get; set; }
        public string SceneSaveId { get; set; }
        public bool IsPlayer { get; set; }
        public bool HaveLair { get; set; }
        #endregion

        public BeastModel(BeastNoteModel beastNote, string sceneSaveId, List<ActionResourceModel> actionResources)
        {
            Id = Guid.NewGuid().ToString();
            SceneSaveId = sceneSaveId;
            IsPlayer = false;
            if (beastNote != null)
            {
                BeastNoteId = beastNote.Id;
                Id = Guid.NewGuid().ToString();
                CurrentArmorClass = beastNote.ArmorClass;
                Title = beastNote.Title;

                DiceThrowInfo diceThrowInfo;
                diceThrowInfo = diceRoller.GetAverageThrowResult(beastNote.HitPoitsDice);
                if (diceThrowInfo.status == DiceThrowStatus.Success)
                {
                    MaxHitPoints = diceThrowInfo.GetResult();
                    CurrentHitPoints = diceThrowInfo.GetResult();
                }

                TemporaryHitPoints = 0;
                IsSuprised = false;
                CurrentInitiative = $"{10 + beastNote.InitiativeBonus}";
                FightTeam = null;

                TemporaryAbilityList = beastNote.AbilityList;
                SpellSlotList = [.. beastNote.SpellSlots.Select(x => new SpellSlotListModel(x))];
                ActionResources = actionResources
                    .Select(x => new ActionResourceListModel
                    {
                        Id = Guid.NewGuid().ToString(),
                        ActionResource = x,
                    })
                    .ToList();
                Conditions = [];

                ChallengeRating = beastNote.ChallengeRating;
                InitiativeBonus = beastNote.InitiativeBonus;
                BeastNoteTitle = beastNote.Title;
                Skills = beastNote.SkillList;
                LairInitiative = beastNote.LairInitiative;
                Actions = beastNote.Actions;
                HaveLair = Actions != null 
                    && Actions.Count > 0
                    && Actions.FirstOrDefault(x => x.ActionResource.Title == "Логова") != null;

                SequenceNumber = 0;
            }
        }
        public BeastModel(string title, FightTeamModel fightTeam, string initiative, bool isSuprised = false)
        {
            Id = Guid.NewGuid().ToString();
            IsPlayer = true;
            Title = title;
            FightTeam = fightTeam;
            CurrentInitiative = initiative;
        }
        public string InitiativeDice
        {
            get
            {
                string result = $"{InitiativeBonus}";
                if (InitiativeBonus >= 0)
                    result = $"+{result}";
                return $"d20{result}";
            }
        }
    }
}
