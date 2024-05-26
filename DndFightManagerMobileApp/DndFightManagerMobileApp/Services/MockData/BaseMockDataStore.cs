using DndFightManagerMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndFightManagerMobileApp.Services.MockData
{
    public class BaseMockDataStore<T> : IDataStore<T> where T : BaseEntityModel
    {
        protected List<T> items = new List<T>();

        public virtual async Task<bool> Create(T item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }
        public virtual async Task<bool> Delete(string id)
        {
            var oldItem = items.Where((x) => x.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }
        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await Task.FromResult(items);
        }
        public virtual async Task<bool> GetAny()
        {
            return await Task.FromResult(items.Any());
        }
        public virtual async Task<T> GetById(string id)
        {
            return await Task.FromResult(items.Where((x) => x.Id == id).FirstOrDefault());
        }
        public virtual async Task<bool> Update(T item)
        {
            var oldItem = items.Where((x) => x.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }
    }
}
