using DndFightManagerMobileApp.Models;
using DndFightManagerMobileApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DndFightManagerMobileApp.Services.MockData
{
    public class BaseHardDirMockDataStore<T> : BaseMockDataStore<T>, IBaseHardoceDirectoryDataStore<T> where T : HardcodeDirectoryModel
    {
        public DataProvider dataProvider = new DataProvider();
        public override Task<bool> Create(T item)
        {
            dataProvider.AddKey(item.Title, item.Id);
            return base.Create(item);
        }
        public async Task<T> GetByTitle(string title)
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
