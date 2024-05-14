using System.Collections.Generic;

namespace DndFightManagerMobileApp.Models
{
    public class ActionModel : BaseEntityModel
    {


        public string Title { get; set; } = null!;
        public CooldownTypeModel CooldownType { get; set; } = null!;
        public ActionResourceModel ActionResource { get; set; } = null!;
        public string Description { get; set; } = "";
        public List<ActionThrowModel> ActionThrows { get; set; } = [];

        // Cooldown 1 - spell slots
        public int? Cooldown1_SpellSlotLevel { get; set; }

        // Cooldown 2 - recharge
        public int? Cooldown2_LowerRangeLimit { get; set; } = null;
        public int? Cooldown2_UpperRangeLimit { get; set; } = null;
        public int? Cooldown2_DiceSize { get; set; } = null;

        // Cooldown 3 - time
        public TimeMeasureModel Cooldown3_TimeMeasure { get; set; } = null;
        public int? Cooldown3_HowManyTimes { get; set; } = null;
        public int? Cooldown3_MeasureMultiply { get; set; } = null;

        // Action resource - Reaction
        public string Reaction_Condition { get; set; }

        // Action resource - Lair
        public int? Lair_InitiativeBonus { get; set; } = 20;

        // Some multiaction
        public List<MultiActionList> ChildActions { get; set; } = [];
        
        //public ActionModel ParentMultiaction { get; set; } = null;

        // ==============================================================================

        public string ShortActionResourceTitle
        {
            get
            {
                if (ActionResource != null)
                {
                    switch (ActionResource.Title)
                    {
                        case "Основное":
                            return "Осн";
                        case "Бонусное":
                            return "Бон";
                        case "Свободное":
                            return "Своб";
                        case "Пассивное":
                            return "Пас";
                        case "Реакцией":
                            return "Реак";
                        case "Легендарное":
                            return "Лег";
                        case "Логова":
                            return "Лог";
                    }
                }
                return "Ошбк";
            }
        }


        private bool _isMoreMenuOpened = false;
        public bool IsMoreMenuOpened
        {
            get { return _isMoreMenuOpened; }
            set
            {
                _isMoreMenuOpened = value;
                OnPropertyChanged(nameof(IsMoreMenuOpened));
                OnPropertyChanged(nameof(IsMoreMenuClosed));
            }
        }
        public bool IsMoreMenuClosed
        {
            get 
            { 
                return !IsMoreMenuOpened; 
            }
        }
        public bool IsMultiaction { get; set; } = false;
        
    }
}
