using System;
using FinanceTracker.Services;

namespace FinanceTracker.Commands
{
    public class DeleteCategoryCommand : ICommand
    {
        private readonly CategoryService _service;
        private readonly Guid _categoryId;

        public DeleteCategoryCommand(CategoryService service, Guid categoryId)
        {
            _service = service;
            _categoryId = categoryId;
        }

        public void Execute()
        {
            _service.DeleteCategory(_categoryId);
            Console.WriteLine("Категория удалена.");
        }
    }
}
