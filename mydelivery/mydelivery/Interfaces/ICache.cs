using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelivery.Interfaces
{
    public interface ICache
    {
        void Add<T>(int key, T value);
        T GetOrCreate<T>(int key, Func<T> createItem) where T : class;
    }
}
