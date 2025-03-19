using FinanceTracker.Services;
using FinanceTracker.ImportExport;
using FinanceTracker.Models;
using System;
using System.IO;

namespace FinanceTracker
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Настройка сервисов
            var bankAccountService = new BankAccountService();
            var categoryService = new CategoryService();
            var operationService = new OperationService();
            
            var dataService = new DataImportExportService(
                bankAccountService,
                categoryService,
                operationService);

            // Создание тестовых данных
            CreateTestData(bankAccountService, categoryService, operationService);

            // Экспорт тестовых данных
            ExportTestData(dataService);

            Console.WriteLine("Данные успешно экспортированы.");
        }

        private static void CreateTestData(
            BankAccountService bankAccountService,
            CategoryService categoryService,
            OperationService operationService)
        {
            var account = bankAccountService.CreateAccount("Main Account", 1000);
            var category = categoryService.CreateCategory("Food", CategoryType.Expense);
            
            operationService.CreateOperation(OperationType.Expense, account.Id, category.Id, 50, DateTime.Now, "Lunch");
        }

        private static void ExportTestData(DataImportExportService dataService)
        {
            const string exportPath = "../../../Testing/FinancialExports";
            Directory.CreateDirectory(exportPath);

            dataService.ExportDataToFile(Path.Combine(exportPath, "data.json"), "json");
            dataService.ExportDataToFile(Path.Combine(exportPath, "data.yaml"), "yaml");
            dataService.ExportDataToFile(exportPath, "csv");
        }
    }
}
