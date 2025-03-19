using System;
using FinanceTracker.Services;

namespace FinanceTracker.Commands
{
    public class RenameAccountCommand : ICommand
    {
        private readonly BankAccountService _service;
        private readonly Guid _accountId;
        private readonly string _newName;

        public RenameAccountCommand(BankAccountService service, Guid accountId, string newName)
        {
            _service = service;
            _accountId = accountId;
            _newName = newName;
        }

        public void Execute()
        {
            _service.RenameAccount(_accountId, _newName);
            Console.WriteLine($"Счет переименован в: {_newName}");
        }
    }
}
