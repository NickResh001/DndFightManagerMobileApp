using DndFightManagerMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DndFightManagerMobileApp.Services.Interfaces
{
    public interface ISettingDataStore : IBaseHardoceDirectoryDataStore<SettingModel>
    {
        public Task<IEnumerable<SettingModel>> GetAll(bool isSpecial);
    }
}
