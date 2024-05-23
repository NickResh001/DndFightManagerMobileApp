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
    public class SettingDataStore : BaseHardDirMockDataStore<SettingModel>, ISettingDataStore
    {
        public async Task<IEnumerable<SettingModel>> GetAll(bool isSpecial)
        {
            return await Task.FromResult(items.Where(x => x.IsSpecial == isSpecial));
        }

        public override async Task<bool> Delete(string id)
        {
            CampaignModel[] campaigns = [ .. await BaseViewModel.dataStore.Campaign.GetAllBySettingId(id)];
            for (int i = 0; i < campaigns.Length; i++)
            {
                await BaseViewModel.dataStore.Campaign.Delete(campaigns[i].Id);
            }
            return await base.Delete(id);
        }
    }
}
