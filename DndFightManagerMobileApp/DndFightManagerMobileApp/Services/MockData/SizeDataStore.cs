using DndFightManagerMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DndFightManagerMobileApp.Services.MockData
{
    public class SizeDataStore : BaseMockDataStore<SizeModel>
    {
        public DataProvider dataProvider = new DataProvider();
        public override Task<bool> Create(SizeModel item)
        {
            dataProvider.AddKey(item.Title, item.Id);
            return base.Create(item);
        }
        public async Task<SizeModel> GetByTitle(string title)
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
