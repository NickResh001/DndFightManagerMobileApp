using System;
using System.Collections.Generic;
using System.Text;

namespace DndFightManagerMobileApp.Models
{
    public class SpeedListModel
    {
        public string Id { get; set; } = null!;
        public SpeedModel Speed { get; set; }
        public int DistanceInFeet { get; set; }
    }
}
