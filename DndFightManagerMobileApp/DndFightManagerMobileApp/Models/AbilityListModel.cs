using System;
using System.Collections.Generic;
using System.Text;

namespace DndFightManagerMobileApp.Models
{
    public class AbilityListModel
    {
        public string Id { get; set; } = null!;
        public AbilityModel Ability { get; set; }
        public int Value { get; set; }
        public bool SavingThrowProficiency { get; set; }
    }
}
