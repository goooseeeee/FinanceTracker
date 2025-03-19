using System;
using FinanceTracker.Services;

namespace FinanceTracker.Commands
{
    public class CreateAccountCommand : ICommand
    {
        private readonly BankAccountService _service;
        private readonly string _name;
        private readonly decimal _initialBalance;

        public CreateAccountCommand(BankAccountService service, string name, decimal initialBalance)
        {
            _service = service;
            _name = name;
            _initialBalance = initialBalance;
        }

        public void Execute()
        {
            var account = _service.CreateAccount(_name, _initialBalance);
            Console.WriteLine($"Создан новый счет: {account}");
        }
    }
}
