using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DndFightManagerMobileApp.Models.ModelHelpers
{
    public class MultiSelectCRUDHelper : ObservableObject
    {
        public HardcodeDirectoryModel DirectoryModel { get; set; }
        public string Title { get; set; }

        private string _value;
        public string Value
        {
            get { return _value; }
            set
            {
                if (value == null)
                    return;

                // Любое число нулей превращается в один ноль
                if (value == "")
                {
                    _value = 0.ToString();
                    OnPropertyChanged(nameof(Value));
                }
                else
                {
                    int buffer;
                    if (int.TryParse(value, out buffer))
                    {
                        _value = buffer.ToString();
                        OnPropertyChanged(nameof(Value));
                    }
                }
            }
        }
        public bool Selected { get; set; }
        public int ValueMaxLength { get; set; }

        public MultiSelectCRUDHelper() { }
        public MultiSelectCRUDHelper(HardcodeDirectoryModel directoryModel, string value = "", bool selected = false, int valueMaxLength = 3)
        {
            DirectoryModel = directoryModel;
            Title = DirectoryModel.Title;
            Value = value;
            Selected = selected;
            ValueMaxLength = valueMaxLength;
        }
    }
}
