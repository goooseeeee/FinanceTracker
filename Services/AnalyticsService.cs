using System;
using System.Collections.Generic;
using System.Linq;
using FinanceTracker.Models;

namespace FinanceTracker.Services {
    public class AnalyticsService
{
    private readonly OperationService _operationService;

    public AnalyticsService(OperationService operationService)
    {
        _operationService = operationService;
    }

    // Подсчет разницы доходов и расходов за выбранный период
    public decimal GetIncomeExpenseDifference(DateTime startDate, DateTime endDate)
    {
        var operations = _operationService.GetAllOperations()
            .Where(op => op.Date >= startDate && op.Date <= endDate);

        decimal totalIncome = operations.Where(op => op.Type == OperationType.Income).Sum(op => op.Amount);
        decimal totalExpense = operations.Where(op => op.Type == OperationType.Expense).Sum(op => op.Amount);

        return totalIncome - totalExpense;
    }

    // Группировка доходов и расходов по категориям
    public Dictionary<Guid, decimal> GetAmountByCategory(DateTime startDate, DateTime endDate)
    {
        return _operationService.GetAllOperations()
            .Where(op => op.Date >= startDate && op.Date <= endDate)
            .GroupBy(op => op.CategoryId)
            .ToDictionary(group => group.Key, group => group.Sum(op => op.Amount));
    }

    // Получение общей суммы операций по типу (доходы или расходы)
    public decimal GetTotalByType(OperationType type, DateTime startDate, DateTime endDate)
    {
        return _operationService.GetAllOperations()
            .Where(op => op.Type == type && op.Date >= startDate && op.Date <= endDate)
            .Sum(op => op.Amount);
    }
}
}