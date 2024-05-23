using DndFightManagerMobileApp.Models;
using DndFightManagerMobileApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndFightManagerMobileApp.Services.MockData
{
    public class SceneDataStore : BaseMockDataStore<SceneModel>, ISceneDataStore
    {
        public async Task<IEnumerable<SceneModel>> GetAllByCampaignId(string id)
        {
            return await Task.FromResult(items.Where(x => x.Campaign.Id == id));
        }
    }
}
