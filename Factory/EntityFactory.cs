using System;
using FinanceTracker.Models;

namespace FinanceTracker.Factory {
    public static class EntityFactory
{
    // Фабрика для создания счета (BankAccount)
    public static BankAccount CreateBankAccount(string name, decimal initialBalance)
    {
        return new BankAccount(name, initialBalance);
    }

    // Фабрика для создания категории (Category)
    public static Category CreateCategory(string name, CategoryType type)
    {
        return new Category(name, type);
    }

    // Фабрика для создания операции (Operation)
    public static Operation CreateOperation(OperationType type, Guid bankAccountId, Guid categoryId, decimal amount, DateTime date, string description = "")
    {
        if (amount <= 0)
            throw new ArgumentException("Сумма операции должна быть положительной.", nameof(amount));

        return new Operation(type, bankAccountId, categoryId, amount, date, description);
    }
}
}