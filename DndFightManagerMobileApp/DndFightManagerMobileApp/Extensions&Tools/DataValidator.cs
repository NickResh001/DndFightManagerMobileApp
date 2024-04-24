using System;
using System.Collections.Generic;
using System.Text;

namespace DndFightManagerMobileApp.Extensions_Tools
{
    public enum ValidationGroup
    {
        OnlyInt,
        WithoutSpecialChars,

        MustContain,
        MustNotContain,
        MinLength,
        MaxLength,
    }

    public class ValidationRule
    {
        public ValidationGroup validationGroup { get; private set; }
        private List<string> parametres = [];
        
        public ValidationRule(ValidationGroup validationGroup)
        {
            this.validationGroup = validationGroup;
        }
        public ValidationRule(ValidationGroup validationGroup, string parameter)
        {
            this.validationGroup = validationGroup;
            parametres.Add(parameter);
        }
        public ValidationRule(ValidationGroup validationGroup, List<string> parametres)
        {
            this.validationGroup = validationGroup;
            this.parametres.AddRange(parametres);
        }

        public bool Validate(string value)
        {
            bool result = true;
            switch (validationGroup)
            {
                case ValidationGroup.OnlyInt:

                    foreach(char ch in value)
                    {
                        result &= char.IsDigit(ch);
                        if (!result) break;
                    }
                    break;

                case ValidationGroup.WithoutSpecialChars:

                    string specs = @"\/:*?<>|""";
                    foreach (char spec in specs)
                    {
                        if (value.Contains(spec.ToString()))
                        {
                            result = false; 
                            break;
                        }
                    }
                    break;

                case ValidationGroup.MustContain:

                    foreach(string str in parametres)
                    {
                        result &= value.Contains(str);
                        if (!result) break;
                    }
                    break;

                case ValidationGroup.MustNotContain:

                    foreach (string str in parametres)
                    {
                        result &= !value.Contains(str);
                        if (!result) break;
                    }
                    break;

                case ValidationGroup.MinLength:

                    int min = -1;
                    if (int.TryParse(parametres[0], out min))
                    {
                        result &= value.Length >= min;
                    }
                    else
                    {
                        result = false;
                    }
                    break;

                case ValidationGroup.MaxLength:

                    int max = -1;
                    if (int.TryParse(parametres[0], out max))
                    {
                        result &= value.Length <= max;
                    }
                    else
                    {
                        result = false;
                    }
                    break;

                default:
                    break;
            }
            return result;
        }
    }
    public class PropertyToValidate
    {
        public string propertyName { get; private set; }
        private List<ValidationRule> rules = [];

        public PropertyToValidate(string propertyName) 
        { 
            this.propertyName = propertyName;
        }
        public PropertyToValidate(string propertyName, List<ValidationRule> rules)
        {
            this.propertyName = propertyName;
            this.rules = rules;
        }

        public void AddRule(ValidationRule rule)
        {
            for (int i = 0; i < rules.Count; i++)
            { 
                if (rules[i].validationGroup == rule.validationGroup) 
                { 
                    rules.RemoveAt(i);
                    rules.Add(rule);
                    return;
                }
            }
            rules.Add(rule);
        }
        public bool Validate(string value)
        {
            bool result = true;
            foreach (ValidationRule rule in rules)
            {
                result &= rule.Validate(value);
            }
            return result;
        }
    }
    public class DataValidator
    {
        private List<PropertyToValidate> propList = [];
        
        public DataValidator(List<PropertyToValidate> propertyToValidates)
        {
            propList = propertyToValidates;
        }

        public bool Validate(string propertyName, string value)
        {
            foreach (var property in propList)
            {
                if (property.propertyName == propertyName)
                { 
                    return property.Validate(value);
                }
            }
            return false;
        }
        public bool ValidateAll(List<string> values)
        {
            if (values.Count != propList.Count)
                return false;

            bool result = true;
            for (int i = 0; i < propList.Count; i++)
            {
                result &= propList[i].Validate(values[i]);
            }
            return result;
        }
        
        //public static bool Validate()
        //{

        //}
    
    }


}
