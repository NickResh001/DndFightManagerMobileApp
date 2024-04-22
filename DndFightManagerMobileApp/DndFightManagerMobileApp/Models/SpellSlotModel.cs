using System;
using System.Collections.Generic;
using System.Text;

namespace DndFightManagerMobileApp.Models
{
    public class SpellSlotModel : BaseEntityModel
    {
        public int Level { get; set; }
        public int Count { get; set; }
    }
}
