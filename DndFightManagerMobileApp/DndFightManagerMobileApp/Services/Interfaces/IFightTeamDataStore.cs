using DndFightManagerMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DndFightManagerMobileApp.Services.Interfaces
{
    public interface IFightTeamDataStore : IBaseHardoceDirectoryDataStore<FightTeamModel>
    {
        public Task<IEnumerable<FightTeamModel>> GetAllBySceneSaveId(string id);
    }
}
