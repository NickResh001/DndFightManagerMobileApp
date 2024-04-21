using System;
using System.Collections.Generic;
using System.Text;

namespace DndFightManagerMobileApp.Models
{
    public class ConditionImmunitiesListModel
    {
        public string Id { get; set; } = null!;
        public ConditionModel Condition { get; set; }
    }
}
