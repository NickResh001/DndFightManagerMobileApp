using DndFightManagerMobileApp.Utils;
using System;
using System.Collections.Generic;
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

        List<AbilityListModel> TemporaryAbilityList { get; set; } = [];
        List<SpellSlotListModel> SpellSlotList { get; set; } = [];
        List<ActionResourceListModel> ActionResources { get; set; } = [];
        List<ConditionListModel> Conditions { get; set; } = [];
        #endregion

        #region Inherit Props
        public int InitiativeBonus { get; set; }
        public string BeastNoteTitle { get; set; }
        public List<SkillListModel> Skills { get; set; }
        #endregion

        #region Additional Props
        public int SequenceNumber { get; set; }
        public string SceneSaveId { get; set; }
        #endregion

        public BeastModel(BeastNoteModel beastNote)
        {
            CurrentArmorClass = beastNote.ArmorClass;
            Title = beastNote.Title;
            TemporaryHitPoints = 0;
            IsSuprised = false;
            CurrentInitiative = $"{10 + beastNote.InitiativeBonus}";

            DiceThrowInfo diceThrowInfo;

            diceThrowInfo = diceRoller.GetAverageThrowResult(beastNote.HitPoitsDice);
            if (diceThrowInfo.status == DiceThrowStatus.Success)
            {
                MaxHitPoints = diceThrowInfo.GetResult();
                CurrentHitPoints = diceThrowInfo.GetResult();
            }

        }
    }
}
