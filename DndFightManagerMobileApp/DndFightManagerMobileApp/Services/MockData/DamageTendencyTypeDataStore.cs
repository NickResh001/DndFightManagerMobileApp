using DndFightManagerMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DndFightManagerMobileApp.Services.MockData
{
    public class DamageTendencyTypeDataStore : BaseMockDataStore<DamageTendencyTypeModel>
    {
        public DataProvider dataProvider = new DataProvider();
        public override Task<bool> Create(DamageTendencyTypeModel item)
        {
            dataProvider.AddKey(item.Title, item.Id);
            return base.Create(item);
        }
        public async Task<DamageTendencyTypeModel> GetByTitle(string title)
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
