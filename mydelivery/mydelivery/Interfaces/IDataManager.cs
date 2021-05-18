using System.Collections.Generic;

namespace MyDelivery.Interfaces
{
    public interface IDataManager
    {
        void Save<T>(IList<T> list, string nameFile) where T : class;

        IList<T> Load<T>(string nameFile) where T : class;
    }
}