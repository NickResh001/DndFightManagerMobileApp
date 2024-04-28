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
                if (new Regex(@"^\d*$", RegexOptions.Compiled).IsMatch(value))
                {
                    int buffer;
                    if (int.TryParse(value, out buffer))
                    {
                        _value = value;
                        OnPropertyChanged(nameof(Value));
                    }
                }
                else
                {
                    OnPropertyChanged(nameof(Value));
                }
            }
        }
        public bool Selected { get; set; }

        public MultiSelectCRUDHelper() { }
        public MultiSelectCRUDHelper(HardcodeDirectoryModel directoryModel, string value = "", bool selected = false)
        {
            DirectoryModel = directoryModel;
            Title = DirectoryModel.Title;
            Value = value;
            Selected = selected;
        }
    }
}
