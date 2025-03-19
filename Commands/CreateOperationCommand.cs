using System;
using FinanceTracker.Models;
using FinanceTracker.Services;

namespace FinanceTracker.Commands
{
    public class CreateOperationCommand : ICommand
    {
        private readonly OperationService _service;
        private readonly OperationType _type;
        private readonly Guid _bankAccountId;
        private readonly Guid _categoryId;
        private readonly decimal _amount;
        private readonly DateTime _date;
        private readonly string _description;

        public CreateOperationCommand(OperationService service, OperationType type, Guid bankAccountId, Guid categoryId, decimal amount, DateTime date, string description = "")
        {
            _service = service;
            _type = type;
            _bankAccountId = bankAccountId;
            _categoryId = categoryId;
            _amount = amount;
            _date = date;
            _description = description;
        }

        public void Execute()
        {
            var operation = _service.CreateOperation(_type, _bankAccountId, _categoryId, _amount, _date, _description);
            Console.WriteLine($"Добавлена операция: {operation}");
        }
    }
}
