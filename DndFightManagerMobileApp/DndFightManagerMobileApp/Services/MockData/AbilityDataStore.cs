using DndFightManagerMobileApp.Models;
using DndFightManagerMobileApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace DndFightManagerMobileApp.Services.MockData
{
    public class AbilityDataStore : BaseMockDataStore<AbilityModel>, IAbilityDataStore
    {
        public DataProvider dataProvider = new DataProvider();
        public override Task<bool> Create(AbilityModel item)
        {
            dataProvider.AddKey(item.Title, item.Id);
            return base.Create(item);
        }
        
        
        public async Task<AbilityModel> GetByTitle(string title)
        {
            string id = dataProvider.GetId(title);
            if (id == null)
            {
                return null;
            }
            return await GetById(id);
        }
        public async Task<ObservableCollection<AbilityListModel>> GetDefaultList()
        {
            ObservableCollection<AbilityListModel> abilityList = 
            [
                new AbilityListModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Ability = await GetByTitle("Сила"),
                    Value = 10,
                },
                new AbilityListModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Ability = await GetByTitle("Ловкость"),
                    Value = 10,
                },
                new AbilityListModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Ability = await GetByTitle("Телосложение"),
                    Value = 10,
                },
                new AbilityListModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Ability = await GetByTitle("Интеллект"),
                    Value = 10,
                },
                new AbilityListModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Ability = await GetByTitle("Мудрость"),
                    Value = 10,
                },
                new AbilityListModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Ability = await GetByTitle("Харизма"),
                    Value = 10,
                },
            ];

            return abilityList;
        }
        
    }
}
