using DndFightManagerMobileApp.Models;
using DndFightManagerMobileApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndFightManagerMobileApp.Services.MockData
{
    public class SceneSaveDataStore : BaseMockDataStore<SceneSaveModel>, ISceneSaveDataStore
    {
        public async Task<IEnumerable<SceneSaveModel>> GetAllBySceneId(string id)
        {
            return await Task.FromResult(items.Where(x => x.Scene.Id == id));
        }
    }
}
