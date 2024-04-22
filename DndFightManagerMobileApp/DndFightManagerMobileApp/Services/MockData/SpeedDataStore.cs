using DndFightManagerMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DndFightManagerMobileApp.Services.MockData
{
    public class SpeedDataStore : BaseMockDataStore<SpeedModel>
    {
        public DataProvider dataProvider = new DataProvider();
        public override Task<bool> Create(SpeedModel item)
        {
            dataProvider.AddKey(item.Title, item.Id);
            return base.Create(item);
        }
        public async Task<SpeedModel> GetByTitle(string title = "Обычная")
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
