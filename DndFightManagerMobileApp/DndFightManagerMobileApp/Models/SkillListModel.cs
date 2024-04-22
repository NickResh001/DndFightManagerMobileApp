using System;
using System.Collections.Generic;
using System.Text;

namespace DndFightManagerMobileApp.Models
{
    public class SkillListModel : BaseEntityModel
    {
        public SkillModel Skill { get; set; }
        public int Value { get; set; }
        public bool Proficiency { get; set; } = true;
    }
}
