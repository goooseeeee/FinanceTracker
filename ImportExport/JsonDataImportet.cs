using System;
using System.Collections.Generic;
using System.Text.Json;
using FinanceTracker.Models;

namespace FinanceTracker.ImportExport
{
    public class JsonDataImporter<T> : DataImporter<T>
    {
        protected override List<T> ParseData(string fileContent)
        {
            return JsonSerializer.Deserialize<List<T>>(fileContent) ?? new List<T>();
        }
    }
}
