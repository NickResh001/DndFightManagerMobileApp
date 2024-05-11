using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DndFightManagerMobileApp.Models.ModelHelpers
{
    public class ActionWatchingHelper
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Recharge { get; set; }
        public string AdditionalInfo { get; set; }

        public bool IsHaveRecharge { get; set; }
        public bool IsHaveAdditionalInfo { get; set; }
        public bool IsMultiaction { get; set; }

        public ActionWatchingHelper() { }
        public ActionWatchingHelper(ActionModel action, string additionalInfo = "")
        {
            Title = action.Title;
            AdditionalInfo = additionalInfo;
            IsHaveRecharge = action.CooldownType.Title != "Нет";
            IsHaveAdditionalInfo = additionalInfo != "";
            string recharge = "";
            if (IsHaveRecharge)
            {
                switch (action.CooldownType.Title) 
                {
                    case "Ячейки заклинаний":
                        recharge += $"Тратит ячейку уровня {action.Cooldown1_SpellSlotLevel}";
                        break;
                    case "Перезарядка":
                        recharge += $"Перезарядка: от {action.Cooldown2_LowerRangeLimit} до {action.Cooldown2_UpperRangeLimit} на d{action.Cooldown2_DiceSize}";
                        break;
                    case "Время":
                        recharge += $"Доступно {action.Cooldown3_HowManyTimes} раз(а) в {action.Cooldown3_MeasureMultiply} [{action.Cooldown3_TimeMeasure.Title}]";
                        break;
                    default: 
                        break;
                }
            }
            Recharge = recharge;

            string description = "";
            IsMultiaction = action.IsMultiaction;
            if (action.IsMultiaction)
            {
                description += $"Мультиатака: ";
                for (int i = 0; i < action.ChildActions.Count; i++)
                {
                    description += $"{action.ChildActions[i].RepititionNumber}x {action.ChildActions[i].Title}";
                    if (i != action.ChildActions.Count - 1)
                        description += ", ";                    
                }
            }
            else
            {
                description = action.Description;
            }
            Description = description;
        }
    }
}
