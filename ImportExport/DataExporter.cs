using System.Collections.Generic;

namespace FinanceTracker.ImportExport
{
    public interface IDataExporter<T>
    {
        void Export(string filePath, List<T> data);
    }
}
