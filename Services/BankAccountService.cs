using System;
using System.Collections.Generic;
using System.Linq;
using FinanceTracker.Models;
using FinanceTracker.Factory;

namespace FinanceTracker.Services {
    public class BankAccountService
{
    private readonly List<BankAccount> _accounts = new List<BankAccount>();

    // Создание нового счета
    public BankAccount CreateAccount(string name, decimal initialBalance)
    {
        var account = EntityFactory.CreateBankAccount(name, initialBalance);
        _accounts.Add(account);
        return account;
    }

    // Получение всех счетов
    public IEnumerable<BankAccount> GetAllAccounts()
    {
        return _accounts;
    }

    // Поиск счета по ID
    public BankAccount GetAccountById(Guid accountId)
    {
        return _accounts.FirstOrDefault(acc => acc.Id == accountId) ?? throw new InvalidOperationException("Счет не найден.");
    }

    // Удаление счета по ID
    public void DeleteAccount(Guid accountId)
    {
        var account = GetAccountById(accountId);
        _accounts.Remove(account);
    }

    // Переименование счета
    public void RenameAccount(Guid accountId, string newName)
    {
        var account = GetAccountById(accountId);
        account.Rename(newName);
    }

    // Пополнение счета
    public void Deposit(Guid accountId, decimal amount)
    {
        var account = GetAccountById(accountId);
        account.Deposit(amount);
    }

    // Списание средств со счета
    public void Withdraw(Guid accountId, decimal amount)
    {
        var account = GetAccountById(accountId);
        account.Withdraw(amount);
    }

    // Получение баланса счета
    public decimal GetBalance(Guid accountId)
    {
        var account = GetAccountById(accountId);
        return account.Balance;
    }
}
}