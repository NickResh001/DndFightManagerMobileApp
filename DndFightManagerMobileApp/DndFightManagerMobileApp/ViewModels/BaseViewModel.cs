using CommunityToolkit.Mvvm.ComponentModel;
using DndFightManagerMobileApp.Services;
using DndFightManagerMobileApp.Services.MockData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DndFightManagerMobileApp.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
        protected static IGLobalDataStore dataStore = new MockDataGlobalStore();
        //public event PropertyChangedEventHandler PropertyChanged;
        //protected void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
