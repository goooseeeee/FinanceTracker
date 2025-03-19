using System;
using System.Collections.Generic;
using System.IO;
using FinanceTracker.Models;
using FinanceTracker.Services;
using FinanceTracker.ImportExport;

namespace FinanceTracker
{
    public class DataImportExportService
    {
        private readonly BankAccountService _bankAccountService;
        private readonly CategoryService _categoryService;
        private readonly OperationService _operationService;

        public DataImportExportService(
            BankAccountService bankAccountService,
            CategoryService categoryService,
            OperationService operationService)
        {
            _bankAccountService = bankAccountService;
            _categoryService = categoryService;
            _operationService = operationService;
        }

        public void ExportDataToFile(string filePath, string format)
        {
            switch (format.ToLower())
            {
                case "json":
                    ExportJson(filePath);
                    break;
                case "yaml":
                    ExportYaml(filePath);
                    break;
                case "csv":
                    ExportCsv(filePath);
                    break;
                default:
                    throw new ArgumentException("Неподдерживаемый формат");
            }
        }

        private void ExportJson(string filePath)
        {
            var exporter = new JsonDataExporter<object>();
            var data = GetAllData();
            exporter.Export(filePath, data);
        }

        private void ExportYaml(string filePath)
        {
            var exporter = new YamlDataExporter<object>();
            var data = GetAllData();
            exporter.Export(filePath, data);
        }

        private void ExportCsv(string filePath)
        {
            var exporter = new CsvDataExporter<object>();
            var data = GetAllData();
            exporter.Export(filePath, data);
        }

        private List<object> GetAllData()
        {
            var data = new List<object>();
            data.AddRange(_bankAccountService.GetAllAccounts());
            data.AddRange(_categoryService.GetAllCategories());
            data.AddRange(_operationService.GetAllOperations());
            return data;
        }
    }
}
