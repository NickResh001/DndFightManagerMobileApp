using System;
using System.Collections.Generic;
using System.Text;

namespace DndFightManagerMobileApp.Models.ModelHelpers
{
    public class SpellSlotCrudHelper : HardcodeDirectoryModel
    {
        public static SpellSlotCrudHelper Create(int level)
        {
            return new SpellSlotCrudHelper(new SpellSlotModel()
            {
                Id = Guid.NewGuid().ToString(),
                Level = level,
                Count = 1
            }); 
        }
        public SpellSlotModel SpellSlot { get; set; }
        public SpellSlotCrudHelper(SpellSlotModel spellSlot) 
        {
            SpellSlot = spellSlot;
            Id = spellSlot.Id;
            Title = $"Уровень {spellSlot.Level}";
        }
    }
}
