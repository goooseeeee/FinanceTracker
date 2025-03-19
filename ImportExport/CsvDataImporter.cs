using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FinanceTracker.Models;

namespace FinanceTracker.ImportExport
{
    public class CsvDataImporter<T> : DataImporter<T> where T : class, new()
    {
        protected override List<T> ParseData(string fileContent)
        {
            var lines = fileContent.Split('\n').Select(l => l.Trim()).Where(l => !string.IsNullOrEmpty(l)).ToList();
            if (lines.Count < 2) return new List<T>(); // Минимум заголовок + 1 строка данных

            var properties = typeof(T).GetProperties();
            var headers = lines[0].Split(',');

            var dataList = new List<T>();

            foreach (var line in lines.Skip(1))
            {
                var values = line.Split(',');
                var obj = new T();

                for (int i = 0; i < headers.Length && i < values.Length; i++)
                {
                    var property = properties.FirstOrDefault(p => p.Name.Equals(headers[i], StringComparison.OrdinalIgnoreCase));
                    if (property != null)
                    {
                        property.SetValue(obj, Convert.ChangeType(values[i], property.PropertyType));
                    }
                }

                dataList.Add(obj);
            }

            return dataList;
        }
    }
}
