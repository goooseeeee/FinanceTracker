using System;
using FinanceTracker.Services;

namespace FinanceTracker.Commands
{
    public class DeleteOperationCommand : ICommand
    {
        private readonly OperationService _service;
        private readonly Guid _operationId;

        public DeleteOperationCommand(OperationService service, Guid operationId)
        {
            _service = service;
            _operationId = operationId;
        }

        public void Execute()
        {
            _service.DeleteOperation(_operationId);
            Console.WriteLine("Категория удалена.");
        }
    }
}
