using DndFightManagerMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DndFightManagerMobileApp.Services.Interfaces
{
    public interface IBeastDataStore : IDataStore<BeastModel>
    {
        public Task<IEnumerable<BeastModel>> GetAllBySceneSaveId(string id);
    }
}
