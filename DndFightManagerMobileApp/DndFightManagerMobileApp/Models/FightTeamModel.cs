using System;
using System.Collections.Generic;
using System.Text;

namespace DndFightManagerMobileApp.Models
{
    public class FightTeamModel : HardcodeDirectoryModel
    {
        public bool IsSpecial { get; set; } = false;
        public string SceneSaveId { get; set; }
    }
}
