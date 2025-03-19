using System;
using FinanceTracker.Services;

namespace FinanceTracker.Commands
{
    public class DepositAccountCommand : ICommand
    {
        private readonly BankAccountService _service;
        private readonly Guid _accountId;
        private readonly decimal _amount;

        public DepositAccountCommand(BankAccountService service, Guid accountId, decimal amount)
        {
            _service = service;
            _accountId = accountId;
            _amount = amount;
        }

        public void Execute()
        {
            _service.Deposit(_accountId, _amount);
            Console.WriteLine($"Пополнен счет на {_amount:F2} руб.");
        }
    }
}
