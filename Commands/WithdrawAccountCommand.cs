using System;
using FinanceTracker.Services;

namespace FinanceTracker.Commands
{
    public class WithdrawAccountCommand : ICommand
    {
        private readonly BankAccountService _service;
        private readonly Guid _accountId;
        private readonly decimal _amount;

        public WithdrawAccountCommand(BankAccountService service, Guid accountId, decimal amount)
        {
            _service = service;
            _accountId = accountId;
            _amount = amount;
        }

        public void Execute()
        {
            _service.Withdraw(_accountId, _amount);
            Console.WriteLine($"Списано {_amount:F2} руб.");
        }
    }
}
