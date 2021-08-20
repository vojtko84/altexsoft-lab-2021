using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using MyDelivery.Interfaces;

namespace MyDelivery.Data
{
    public class JsonManager : IDataManager
    {
        public void Save<T>(IList<T> list, string nameFile) where T : class
        {
            string json = JsonSerializer.Serialize<IList<T>>(list);
            File.WriteAllText(nameFile, json, Encoding.Unicode);
        }

        public IList<T> Load<T>(string nameFile) where T : class
        {
            if (File.Exists(nameFile))
            {
                string json = File.ReadAllText(nameFile, Encoding.Unicode);

                var data = JsonSerializer.Deserialize<IList<T>>(json);
                return data;
            }
            else
            {
                return new List<T>();
            }
        }
    }
}