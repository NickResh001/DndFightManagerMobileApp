using System;
using System.Collections.Generic;
using System.Text;

namespace DndFightManagerMobileApp.Models
{
    public class ActionResourceListModel : BaseEntityModel
    {
        public ActionResourceModel ActionResource { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}
