using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DndFightManagerMobileApp.Utils
{
    public class Initiative
    {
        private static DiceRoller diceRoller = new DiceRoller();
        public int SequenceNumber { get; private set; } = 0;
        public string DiceFormula { get; private set; } = "d20";
        public string InitiativeSequenceString { get; private set; } = "00000000000000000000";
        public List<int> InitiativeSequence { get; private set; } = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0];

        public Initiative() { }

        public void CalculateInitiative(int step)
        {
            if (step < 0 || step > 9)
                return;

            var info = diceRoller.Throw(DiceFormula);
            if (info != null && info.status == DiceThrowStatus.Success)
            {
                InitiativeSequence[step] = info.GetResult();
            }
        }
        public static List<Initiative> CalculateInitiativeStack(List<string> dices)
        {
            List<Initiative> initiatives = [];
            foreach (string dice in dices) 
            {
                initiatives.Add(new Initiative
                {
                    DiceFormula = dice
                });
            }

            for (int i = 0; i < 10; i++)
            {
                foreach (var initiative in initiatives)
                {
                    initiative.CalculateInitiative(i);
                }
            }

            return null;
        }
        
    }
}
