using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DndFightManagerMobileApp.Models
{
    public class ActionThrowModel : BaseEntityModel
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                if (value == null)
                    return;

                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private string _throw;
        public string Throw
        {
            get { return _throw; }
            set
            {
                if (value != null || value != _throw) _throw = value;
                OnPropertyChanged(nameof(Throw));
            }
        }
    }
}
