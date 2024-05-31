using DndFightManagerMobileApp.Models;
using DndFightManagerMobileApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndFightManagerMobileApp.Services.MockData
{
    public class FightTeamDataStore : BaseHardDirMockDataStore<FightTeamModel>, IFightTeamDataStore
    {
        public async Task<IEnumerable<FightTeamModel>> GetAllBySceneSaveId(string id)
        {
            return await Task.FromResult(items.Where(x => x.SceneSaveId == id));
        }
    }
}
