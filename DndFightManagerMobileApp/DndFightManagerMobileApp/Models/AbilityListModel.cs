using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DndFightManagerMobileApp.Models
{
    public partial class AbilityListModel : BaseEntityModel
    {
        public AbilityModel Ability { get; set; }

        private int _value;
        public int Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnPropertyChanged(nameof(Value));
            }
        }
        public bool SavingThrowProficiency { get; set; } = false;

        public int Modifier => ((Value % 2 == 0 ? Value : Value - 1) - 10) / 2;

    }
}
