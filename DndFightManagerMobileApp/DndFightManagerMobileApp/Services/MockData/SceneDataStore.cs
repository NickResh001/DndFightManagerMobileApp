using DndFightManagerMobileApp.Models;
using DndFightManagerMobileApp.Services.Interfaces;
using DndFightManagerMobileApp.ViewModels;
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
        public override async Task<bool> Delete(string id)
        {
            SceneSaveModel[] sceneSaves = [.. await BaseViewModel.dataStore.SceneSave.GetAllBySceneId(id)];
            for (int i = 0; i < sceneSaves.Length; i++)
            {
                await BaseViewModel.dataStore.SceneSave.Delete(sceneSaves[i].Id);
            }
            return await base.Delete(id);
        }
    }
}
