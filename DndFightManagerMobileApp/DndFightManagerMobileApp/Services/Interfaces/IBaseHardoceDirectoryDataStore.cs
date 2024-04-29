using DndFightManagerMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DndFightManagerMobileApp.Services.Interfaces
{
    public interface IBaseHardoceDirectoryDataStore<T> : IDataStore<T> where T : HardcodeDirectoryModel
    {
        public Task<T> GetByTitle(string title);
    }
}
