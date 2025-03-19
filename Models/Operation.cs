using System;

namespace FinanceTracker.Models {
    public class Operation
{
    public Guid Id { get; }  // Уникальный идентификатор операции
    public OperationType Type { get; }  // Тип операции (Доход / Расход)
    public Guid BankAccountId { get; }  // Ссылка на счет
    public Guid CategoryId { get; }  // Ссылка на категорию
    public decimal Amount { get; }  // Сумма операции
    public DateTime Date { get; }  // Дата операции
    public string Description { get; }  // Описание (необязательно)

    public Operation(OperationType type, Guid bankAccountId, Guid categoryId, decimal amount, DateTime date, string description = "")
    {
        if (amount <= 0)
            throw new ArgumentException("Сумма операции должна быть положительной.", nameof(amount));

        Id = Guid.NewGuid();
        Type = type;
        BankAccountId = bankAccountId;
        CategoryId = categoryId;
        Amount = amount;
        Date = date;
        Description = description ?? string.Empty;  // Если null, заменяем на пустую строку
    }

    
    public override string ToString()
    {
        return $"{Date:dd.MM.yyyy} - {Type} - {Amount:F2} руб. - {Description}";
    }
}

// Перечисление для типа операции
public enum OperationType
{
    Income,  // Доход
    Expense  // Расход
}
}