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

        public int Modifier 
        { 
            get
            {
                int result = Value;
                if (result % 2 != 0)
                    result--;

                return (result - 10) / 2;
            } 
        }
        public int Passive
        {
            get
            {
                return 10 + Modifier;
            }
        }
        public string ShortTitle
        {
            get
            {
                if (Ability != null)
                {
                    switch (Ability.Title)
                    {
                        case "Сила":
                            return "Сил";
                        case "Ловкость":
                            return "Лов";
                        case "Телосложение":
                            return "Тел";
                        case "Интеллект":
                            return "Инт";
                        case "Мудрость":
                            return "Мдр";
                        case "Харизма":
                            return "Хар";
                    }
                }
                return "Ошбк";
            }
        }
        
    }
}
