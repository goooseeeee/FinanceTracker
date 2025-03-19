using System;
using System.Collections.Generic;
using System.IO;

namespace FinanceTracker.ImportExport
{
    public abstract class DataImporter<T>
    {
        public List<T> Import(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Файл не найден.", filePath);

            string fileContent = File.ReadAllText(filePath);
            return ParseData(fileContent);
        }

        protected abstract List<T> ParseData(string fileContent);
    }
}
