using System;
using System.Collections.Generic;
using FinanceTracker.Models;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace FinanceTracker.ImportExport
{
    public class YamlDataImporter<T> : DataImporter<T>
    {
        protected override List<T> ParseData(string fileContent)
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            return deserializer.Deserialize<List<T>>(fileContent) ?? new List<T>();
        }
    }
}
