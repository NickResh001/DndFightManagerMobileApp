using DndFightManagerMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DndFightManagerMobileApp.Services.Interfaces
{
    public interface ISceneSaveDataStore : IDataStore<SceneSaveModel>
    {
        public Task<IEnumerable<SceneSaveModel>> GetAllBySceneId(string id);
    }
}
