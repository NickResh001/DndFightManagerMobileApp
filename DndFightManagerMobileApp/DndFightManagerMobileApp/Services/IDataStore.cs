using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DndFightManagerMobileApp.Services
{
    /// <summary>
    /// Interface for accessing data for one entity (similar to the repository pattern) 
    /// </summary>
    /// <typeparam name="T">Entity type (from Model layer)</typeparam>
    public interface IDataStore<T> where T : class
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetById(string id);
        public Task<bool> GetAny();
        public Task<bool> Create(T item);
        public Task<bool> Update(T item);
        public Task<bool> Delete(string id);
    }
}
