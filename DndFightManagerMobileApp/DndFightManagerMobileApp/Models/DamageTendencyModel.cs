using System;
using System.Collections.Generic;
using System.Text;

namespace DndFightManagerMobileApp.Models
{
    public class DamageTendencyModel : BaseEntityModel
    {
        public DamageTypeModel DamageType { get; set; }
        public DamageTendencyTypeModel DamageTendencyType { get; set; }
        public bool Magical { get; set; }
        public bool NonMagical { get; set; }
    }
}
