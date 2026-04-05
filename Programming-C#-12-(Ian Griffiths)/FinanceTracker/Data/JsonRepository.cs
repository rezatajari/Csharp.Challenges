using FinanceTracker.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;

namespace FinanceTracker.Data
{
    public class JsonRepository<T> :Repository<T> where T : class,IEntity
    {
        private readonly string _filePath;

        public JsonRepository(string fileName)
        {
            var directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StoredData");
            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
            _filePath = Path.Combine(directory, fileName);
            
            Load();
        }

        public void Load()
        {
            if (!File.Exists(_filePath)) return;

            string json=File.ReadAllText(_filePath);

            var loadedData=JsonSerializer.Deserialize<List<T>>(json);

            if (loadedData != null)
            {
                _item.Clear();
                _item.AddRange(loadedData);
            }
        }

        public override void Add(T item)
        {
            base.Add(item);
            Save();
        }

        private void Save()
        {
            var options=new JsonSerializerOptions { WriteIndented = true }  ;
            string json=JsonSerializer.Serialize(_item,options);
            File.WriteAllText(_filePath,json);
        }

    }
}
