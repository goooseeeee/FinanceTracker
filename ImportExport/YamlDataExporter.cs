using System.Collections.Generic;
using System.IO;
using FinanceTracker.Models;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace FinanceTracker.ImportExport
{
    public class YamlDataExporter<T> : IDataExporter<T>
    {
        public void Export(string filePath, List<T> data)
        {
            var serializer = new SerializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            var yaml = serializer.Serialize(data);
            File.WriteAllText(filePath, yaml);
        }
    }
}
