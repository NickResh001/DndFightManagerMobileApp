using DndFightManagerMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DndFightManagerMobileApp.Services.Interfaces
{
    public interface ISceneDataStore : IDataStore<SceneModel>
    {
        public Task<IEnumerable<SceneModel>> GetAllByCampaignId(string id);
    }
}
