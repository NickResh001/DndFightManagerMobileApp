using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DndFightManagerMobileApp.Services
{
    public class DataProvider
    {
        private List<(string id, List<string> keys)> _pairsKeysId = [];

        public string GetId(string key)
        {
            for (int i = 0; i < _pairsKeysId.Count; i++)
            {
                for (int j = 0; j < _pairsKeysId[i].keys.Count; j++)
                {
                    if (_pairsKeysId[i].keys[j] == key) 
                    {
                        return _pairsKeysId[i].id;
                    }
                }
            }
            return null;
        }
        public void AddKey(string key, string id)
        {
            for (int i = 0; i < _pairsKeysId.Count; i++)
            {
                if (_pairsKeysId[i].id == id)
                {
                    _pairsKeysId[i].keys.Add(key);
                    return;
                }
            }

            (string id, List<string> keys) pair;
            pair.id = id;
            pair.keys = [key];
            _pairsKeysId.Add(pair);
        }
        public void DeleteId(string id)
        {
            for (int i = 0; i < _pairsKeysId.Count; i++)
            {
                if (_pairsKeysId[i].id == id)
                {
                    _pairsKeysId.RemoveAt(i);
                    return;
                }
            }
        }
        public void DeleteKey(string key)
        {
            for (int i = 0; i < _pairsKeysId.Count; i++)
            {
                for (int j = 0; j < _pairsKeysId[i].keys.Count; j++)
                {
                    if (_pairsKeysId[i].keys[j] == key)
                    {
                        _pairsKeysId[i].keys.RemoveAt(j);
                        return;
                    }
                }
            }
        }
    }
}
