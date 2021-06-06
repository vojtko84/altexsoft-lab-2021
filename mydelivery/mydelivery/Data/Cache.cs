using MyDelivery.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyDelivery.Data
{
    public class Cache : ICache
    {
        private readonly object _lock = new();
        private const int CacheSize = 5;

        private readonly Dictionary<string, Dictionary<int, object>> cache = new();
        private readonly Dictionary<string, Dictionary<int, int>> cachePosition = new();

        public void Add<T>(int key, T value)
        {
            var type = typeof(T);

            if (value.GetType() != type)
            {
                throw new ApplicationException();
            }

            lock (_lock)
            {
                if (!cache.ContainsKey(type.ToString()))
                {
                    cache.Add(type.ToString(), new Dictionary<int, object>());
                    cachePosition.Add(type.ToString(), new Dictionary<int, int>());
                }
                if (cache[type.ToString()].Count > CacheSize)
                {
                    var keyToDelete = cachePosition[type.ToString()].FirstOrDefault(x => x.Value == 1).Key;
                    cache[type.ToString()].Remove(keyToDelete);
                    cachePosition[type.ToString()].Remove(keyToDelete);
                }
                cache[type.ToString()].Add(key, value);
                cachePosition[type.ToString()].Add(key, cache[type.ToString()].Count);
            }
        }

        public T GetOrCreate<T>(int key, Func<T> createItem) where T : class
        {
            var type = typeof(T);

            lock (_lock)
            {
                if (!cache.ContainsKey(type.ToString()))
                {
                    cache.Add(type.ToString(), new Dictionary<int, object>());
                    cachePosition.Add(type.ToString(), new Dictionary<int, int>());
                }

                if (!cache[type.ToString()].ContainsKey(key))
                {
                    cache[type.ToString()][key] = createItem();
                    cachePosition[type.ToString()][key] = cache[type.ToString()].Count;
                }

                T result = (T)cache[type.ToString()][key];
                return result;
            }
        }
    }
}