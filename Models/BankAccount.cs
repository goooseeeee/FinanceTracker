using System;

namespace FinanceTracker.Models {
    public class BankAccount
{
    public Guid Id { get; }  // Уникальный идентификатор счета
    public string Name { get; private set; }  // Название счета
    public decimal Balance { get; private set; }  // Текущий баланс

    public BankAccount(string name, decimal initialBalance)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Название счета не может быть пустым.", nameof(name));

        if (initialBalance < 0)
            throw new ArgumentException("Начальный баланс не может быть отрицательным.", nameof(initialBalance));

        Id = Guid.NewGuid();
        Name = name;
        Balance = initialBalance;
    }

    // Обновление названия счета
    public void Rename(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentException("Название счета не может быть пустым.", nameof(newName));

        Name = newName;
    }

    // Пополнение баланса
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Сумма пополнения должна быть положительной.", nameof(amount));

        Balance += amount;
    }

    // Списание средств
    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Сумма списания должна быть положительной.", nameof(amount));

        if (amount > Balance)
            throw new InvalidOperationException("Недостаточно средств на счете.");

        Balance -= amount;
    }

    // Вывод информации о счете
    public override string ToString()
    {
        return $"Счет: {Name}, Баланс: {Balance:F2} руб.";
    }
}
}