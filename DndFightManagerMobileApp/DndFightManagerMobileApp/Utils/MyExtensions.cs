using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace DndFightManagerMobileApp.Utils
{
    public static class MyExtensions
    {
        #region ObservableCollection
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> items) 
        {
            ObservableCollection<T> collection = [.. items];
            return collection;
        }
        /// <summary>
        /// Projects one collection into another.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="items"></param>
        /// <param name="func">Func delegate that specifies how elements of one collection are converted to elements of another.</param>
        /// <returns></returns>
        public static ObservableCollection<TResult> Projection<T1, TResult>(this ObservableCollection<T1> items, Func<T1, TResult> func)
        {
            var newItems = new ObservableCollection<TResult>();
            foreach (var item in items)
            {
                newItems.Add(func(item));
            }
            return newItems;
        }
        public static ObservableCollection<T> Sort<T>(this ObservableCollection<T> collection)
        {
            List<T> list = collection.ToList();
            list.Sort();
            return list.ToObservableCollection();
        }
        public static ObservableCollection<T> Sort<T>(this ObservableCollection<T> collection, Comparison<T> comparison)
        {
            List<T> list = collection.ToList();
            list.Sort(comparison);
            return list.ToObservableCollection();
        }

        #endregion
    }
}
