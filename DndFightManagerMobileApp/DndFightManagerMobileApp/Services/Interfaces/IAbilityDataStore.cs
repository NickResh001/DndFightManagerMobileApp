using DndFightManagerMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace DndFightManagerMobileApp.Services.Interfaces
{
    public interface IAbilityDataStore : IDataStore<AbilityModel>
    {
        public Task<AbilityModel> GetByTitle(string title);
        public Task<ObservableCollection<AbilityListModel>> GetDefaultList();
    }
}
