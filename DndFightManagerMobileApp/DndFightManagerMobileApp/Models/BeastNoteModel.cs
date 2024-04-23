using System;
using System.Collections.Generic;
using System.Text;

namespace DndFightManagerMobileApp.Models
{
    public class BeastNoteModel : BaseEntityModel
    {
        public string HitPoitsDice { get; set; }
        public int InitiativeBonus { get; set; }
        public int ArmorClass { get; set; }
        public int SpecialBonus { get; set; }
        public byte[] Image { get; set; }
        public string Title { get; set; }
        public AlignmentModel Alignment { get; set; }
        public SizeModel Size { get; set; }
        public BeastTypeModel BeastType { get; set; }
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
        public string Description { get; set; }
        public AbilityModel SpellAbility { get; set; } = null;
        public int? SpellAttackBonus { get; set; } = null;
        public int? SpellSaveThrowDifficulty { get; set; } = null;

        //public string Author { get; set; }

        //public string Moderator { get; set; }

        public string ModeratorComment { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public DateTime LastEditingDate { get; set; }
        public int AllUses { get; set; } = 0;
        public int UniqueUses { get; set; } = 0;
        public double UserRating { get; set; } = 0;
        public bool IsBeingModerated { get; set; } = false;
        public bool IsPublished { get; set; } = false;

        public List<SpeedListModel> SpeedList { get; set; } = [];
        public List<DamageTendencyModel> DamageTendencyList { get; set; } = [];
        public List<SkillListModel> SkillList { get; set; } = [];
        public List<AbilityListModel> AbilityList { get; set; } = [];
        public List<SpellSlotModel> SpellSlots { get; set; } = [];
        public List<ThingModel> Things { get; set; } = [];
        public List<HabitatListModel> HabitatList { get; set; } = [];
        public List<SenseListModel> SenseList { get; set; } = [];
        public List<ConditionImmunitiesListModel> ConditionImmunitiesList { get; set; } = [];

    }
}
