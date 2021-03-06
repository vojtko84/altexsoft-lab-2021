using System;
using System.Collections.Generic;
using System.Linq;
using MyDelivery.Interfaces;

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
                    var keyToDelete = cachePosition[type.ToString()].FirstOrDefault(x => x.Value == cachePosition[type.ToString()].Min(x => x.Value)).Key;
                    cache[type.ToString()].Remove(keyToDelete);
                    cachePosition[type.ToString()].Remove(keyToDelete);
                }

                cache[type.ToString()].Add(key, value);

                if (cachePosition[type.ToString()].Count == 0)
                {
                    cachePosition[type.ToString()].Add(key, 1);
                }
                else
                {
                    cachePosition[type.ToString()].Add(key, cachePosition[type.ToString()].Max(x => x.Value) + 1);
                }
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

                    if (cachePosition[type.ToString()].Count == 0)
                    {
                        cachePosition[type.ToString()].Add(key, 1);
                    }
                    else
                    {
                        cachePosition[type.ToString()].Add(key, cachePosition[type.ToString()].Max(x => x.Value) + 1);
                    }
                }

                T result = (T)cache[type.ToString()][key];
                return result;
            }
        }
    }
}