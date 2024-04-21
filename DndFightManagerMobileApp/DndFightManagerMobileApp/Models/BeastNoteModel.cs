using System;
using System.Collections.Generic;
using System.Text;

namespace DndFightManagerMobileApp.Models
{
    public class BeastNoteModel
    {
        public string Id { get; set; }
        public string HitPoitsDice { get; set; }
        public int InitiativeBonus { get; set; }
        public int ArmorClass { get; set; }
        public int SpecialBonus { get; set; }
        public byte[] Image { get; set; }
        public string Title { get; set; }
        public AlignmentModel Alignment { get; set; }
        public SizeModel Size { get; set; }
        public BeastTypeModel BeastType { get; set; }
        public int ChallengeRating { get; set; }
        public string Description { get; set; }
        public AbilityModel SpellAbility { get; set; }
        public int? SpellAttackBonus { get; set; }
        public int SpellSaveThrowDifficulty { get; set; }

        //public string Author { get; set; }

        //public string Moderator { get; set; }

        public string ModeratorComment { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastEditingDate { get; set; }
        public int AllUses { get; set; }
        public int UniqueUses { get; set; }
        public double UserRating { get; set; }
        public bool IsBeingModerated { get; set; }
        public bool IsPublished { get; set; }

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
