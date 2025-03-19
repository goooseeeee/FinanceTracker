using System;
using FinanceTracker.Services;

namespace FinanceTracker.Commands
{
    public class DeleteBankAccountCommand : ICommand
    {
        private readonly BankAccountService _service;
        private readonly Guid _accountId;

        public DeleteBankAccountCommand(BankAccountService service, Guid accountId)
        {
            _service = service;
            _accountId = accountId;
        }

        public void Execute()
        {
            _service.DeleteAccount(_accountId);
            Console.WriteLine("Счет удален.");
        }
    }
}
