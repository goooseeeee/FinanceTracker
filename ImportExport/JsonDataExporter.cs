using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using FinanceTracker.Models;

namespace FinanceTracker.ImportExport
{
    public class JsonDataExporter<T> : IDataExporter<T>
    {
        public void Export(string filePath, List<T> data)
        {
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
    }
}
