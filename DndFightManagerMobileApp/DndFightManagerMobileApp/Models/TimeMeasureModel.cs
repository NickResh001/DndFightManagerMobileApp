using System;
using System.Collections.Generic;
using System.Text;

namespace DndFightManagerMobileApp.Models
{
    public class TimeMeasureModel : HardcodeDirectoryModel
    {
        public string GetAccusativeCase()
        {
            switch (Title)
            {
                case "Минута":
                    return "Минуту";
                case "Час":
                    return "Час";
                case "Сутки":
                    return "Сутки";
                case "Неделя":
                    return "Неделю";
                case "Раунд":
                    return "Раунд";
                case "Ход":
                    return "Ход";
                default:
                    return null;
            }
        }
    }
}
