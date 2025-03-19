using System;
using System.Collections.Generic;
using System.Linq;
using FinanceTracker.Models;
using FinanceTracker.Factory;

namespace FinanceTracker.Services {
    public class OperationService
{
    private readonly List<Operation> _operations = new List<Operation>();

    // Создание новой операции
    public Operation CreateOperation(OperationType type, Guid bankAccountId, Guid categoryId, decimal amount, DateTime date, string description = "")
    {
        var operation = EntityFactory.CreateOperation(type, bankAccountId, categoryId, amount, date, description);
        _operations.Add(operation);
        return operation;
    }

    // Получение всех операций
    public IEnumerable<Operation> GetAllOperations()
    {
        return _operations;
    }

    // Получение операций по счету
    public IEnumerable<Operation> GetOperationsByAccount(Guid bankAccountId)
    {
        return _operations.Where(op => op.BankAccountId == bankAccountId);
    }

    // Получение операций по категории
    public IEnumerable<Operation> GetOperationsByCategory(Guid categoryId)
    {
        return _operations.Where(op => op.CategoryId == categoryId);
    }

    // Поиск операции по ID
    public Operation GetOperationById(Guid operationId)
    {
        return _operations.FirstOrDefault(op => op.Id == operationId) ?? throw new InvalidOperationException("Операция не найдена.");
    }

    // Удаление операции по ID
    public void DeleteOperation(Guid operationId)
    {
        var operation = GetOperationById(operationId);
        _operations.Remove(operation);
    }
}
}