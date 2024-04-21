using System;
using System.Collections.Generic;
using System.Text;

namespace DndFightManagerMobileApp.Models
{
    public class SenseListModel
    {
        public string Id { get; set; } = null!;
        public SenseModel Sense { get; set; }
        public int DistanceInFeet { get; set; }
    }
}
