using System;
using System.Collections.Generic;
using System.Text;

namespace DndFightManagerMobileApp.Models
{
    public class SpeedListModel : BaseEntityModel
    {
        public SpeedModel Speed { get; set; }
        public int DistanceInFeet { get; set; }
    }
}
