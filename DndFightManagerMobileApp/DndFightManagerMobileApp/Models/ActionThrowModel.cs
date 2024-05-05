using System;
using System.Collections.Generic;
using System.Text;

namespace DndFightManagerMobileApp.Models
{
    public class ActionThrowModel : BaseEntityModel
    {
        public string Title { get; set; } = null!;
        public string Throw { get; set; } = null!;
    }
}
