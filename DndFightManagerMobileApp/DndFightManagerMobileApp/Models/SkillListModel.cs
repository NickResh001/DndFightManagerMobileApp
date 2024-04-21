using System;
using System.Collections.Generic;
using System.Text;

namespace DndFightManagerMobileApp.Models
{
    public class SkillListModel
    {
        public string Id { get; set; }
        public SkillModel Skill { get; set; }
        public int Value { get; set; }
        public bool Proficiency { get; set; }
    }
}
