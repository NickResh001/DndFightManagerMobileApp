using DndFightManagerMobileApp.Models;
using DndFightManagerMobileApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndFightManagerMobileApp.Services.MockData
{
    public class BeastDataStore : BaseMockDataStore<BeastModel>, IBeastDataStore
    {
        public Task<IEnumerable<BeastModel>> GetAllBySceneSaveId(string id)
        {
            return Task.FromResult(items.Where(x => x.SceneSaveId == id));
        }
    }
}
