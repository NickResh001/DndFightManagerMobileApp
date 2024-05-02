using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DndFightManagerMobileApp.Models
{
    public class AlignmentModel : HardcodeDirectoryModel
    {
        public int Law { get; set; }
        public int Goodness { get; set; }

        public static string GetLaw(int law)
        {
            switch (law)
            {
                case -1:
                    return "Хаотично";
                case 0:
                    return "Нейтрально";
                case 1:
                    return "Законно";
                default:
                    return null;
            }
        }
        public static string GetGoodness(int goodness)
        {
            switch (goodness)
            {
                case -1:
                    return "Злой";
                case 0:
                    return "Нейтральный";
                case 1:
                    return "Добрый";
                default:
                    return null;
            }
        }
        public static string GetDefaultTitle() => "Без мировоззрения";
        public string GetLaw()
        {
            return GetLaw(Law);
        }
        public string GetGoodness()
        {
            return GetGoodness(Goodness);
        }

    }
}
