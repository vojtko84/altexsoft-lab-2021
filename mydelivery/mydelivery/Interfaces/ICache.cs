using System;

namespace MyDelivery.Interfaces
{
    public interface ICache
    {
        void Add<T>(int key, T value);

        T GetOrCreate<T>(int key, Func<T> createItem) where T : class;
    }
}