using System;
using System.Collections.Generic;
using System.Text;

namespace DndFightManagerMobileApp.Models
{
    public class ConditionListModel : BaseEntityModel
    {
        public ConditionModel Condition { get; set; }
        public int RoundCount { get; set; }
    }
}
