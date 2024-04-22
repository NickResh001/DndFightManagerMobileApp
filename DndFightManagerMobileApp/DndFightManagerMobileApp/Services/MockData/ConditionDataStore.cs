using DndFightManagerMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DndFightManagerMobileApp.Services.MockData
{
    public class ConditionDataStore : BaseMockDataStore<ConditionModel>
    {
        public DataProvider dataProvider = new DataProvider();
        public override Task<bool> Create(ConditionModel item)
        {
            dataProvider.AddKey(item.Title, item.Id);
            return base.Create(item);
        }
        public async Task<ConditionModel> GetByTitle(string title)
        {
            string id = dataProvider.GetId(title);
            if (id == null)
            {
                return null;
            }
            return await GetById(id);
        }
    }
}
