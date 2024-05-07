using DndFightManagerMobileApp.Services.MockData;
using System;
using System.Collections.Generic;
using System.Text;

namespace DndFightManagerMobileApp.Models
{
    public class MultiActionList : HardcodeDirectoryModel
    {
        private ActionModel _childAction;
        public ActionModel ChildAction
        {
            get { return _childAction; }
            set
            {
                if (value == null)
                    return;
                _childAction = value;
                Title = value.Title;
                OnPropertyChanged(nameof(ChildAction));
                OnPropertyChanged(nameof(Title));
            }
        }
        public int SequenceNumber { get; set; }
        public int RepititionNumber { get; set; }

    }
}
