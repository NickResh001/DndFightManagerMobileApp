using System;
using System.Collections.Generic;
using System.Text;

namespace DndFightManagerMobileApp.Models
{
    public class AbilityListModel : BaseEntityModel
    {
        public AbilityModel Ability { get; set; }
        public int Value { get; set; }
        public bool SavingThrowProficiency { get; set; } = false;


    }
}
