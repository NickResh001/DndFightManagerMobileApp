using DndFightManagerMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DndFightManagerMobileApp.Services.Interfaces
{
    public interface ICampaignDataStore : IBaseHardoceDirectoryDataStore<CampaignModel>
    {
        public Task<IEnumerable<CampaignModel>> GetAllBySettingId(string id);
    }
}
