using System;
using System.Collections.Generic;
using System.Text;

namespace DndFightManagerMobileApp.Models
{
    public class SenseListModel : BaseEntityModel
    {
        public SenseModel Sense { get; set; }
        public int DistanceInFeet { get; set; }
    }
}
