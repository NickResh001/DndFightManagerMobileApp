using System;
using System.Collections.Generic;
using System.Text;

namespace DndFightManagerMobileApp.Extensions_Tools
{
    public class DataToValidate
    {
        public string propertyName;
        public List<string> mustContain = [];
        public List<string> mustNotContain = [];
    
        public bool Validate(string value)
        {
            bool result = true;
            foreach (string substring in mustContain)
            {
                result &= value.Contains(substring);
            }
            foreach (string substring in mustNotContain)
            {
                result &= !value.Contains(substring);
            }
            return result;
        }
    }
    public class DataValidator
    {
        private List<DataToValidate> dataList = [];

        public void AddRule(string propertyName, string substring, bool mustContain)
        {
            for (int i = 0; i < dataList.Count; i++)
            {
                if (dataList[i].propertyName == propertyName)
                {
                    if (mustContain)
                    {
                        dataList[i].mustContain.Add(substring);
                    }
                    else
                    {
                        dataList[i].mustNotContain.Add(substring);
                    }
                    return;
                }
            }

        }

    }
}
