using System;
using System.Collections.Generic;
using System.Text;

namespace DndFightManagerMobileApp.Models
{
    public class SpellSlotListModel : BaseEntityModel
    {
        public int Level { get; set; }
        public int Count { get; set; }
        public int CountAvailable { get; set; }

        public SpellSlotListModel() { }
        public SpellSlotListModel(SpellSlotModel spellSlotModel)
        {
            Level = spellSlotModel.Level;
            Count = spellSlotModel.Count;
            CountAvailable = Count;
        }
    }
}
