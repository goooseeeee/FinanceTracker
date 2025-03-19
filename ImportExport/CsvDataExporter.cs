using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using FinanceTracker.Models;

namespace FinanceTracker.ImportExport
{
    public class CsvDataExporter<T> : IDataExporter<T>
    {
        public void Export(string filePath, List<T> data)
        {
            if (data == null || !data.Any()) return;

            var properties = typeof(T).GetProperties();
            var lines = new List<string>
            {
                string.Join(",", properties.Select(p => p.Name))
            };

            lines.AddRange(data.Select(d =>
                string.Join(",", properties.Select(p => p.GetValue(d)?.ToString()))
            ));

            File.WriteAllLines(filePath, lines);
        }
    }
}
