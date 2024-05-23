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
    public class CampaignDataStore : BaseHardDirMockDataStore<CampaignModel>, ICampaignDataStore
    {
        public async Task<IEnumerable<CampaignModel>> GetAllBySettingId(string settingId)
        {
            return await Task.FromResult(items.Where(x => x.Setting.Id == settingId));
        }

        public override async Task<bool> Delete(string id)
        {
            SceneModel[] scenes = [.. await BaseViewModel.dataStore.Scene.GetAllByCampaignId(id)];
            for (int i = 0; i < scenes.Length; i++)
            {
                await BaseViewModel.dataStore.Scene.Delete(scenes[i].Id);
            }
            return await base.Delete(id);
        }
    }
}
