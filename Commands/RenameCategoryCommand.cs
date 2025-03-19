using System;
using FinanceTracker.Services;

namespace FinanceTracker.Commands
{
    public class RenameCategoryCommand : ICommand
    {
        private readonly CategoryService _service;
        private readonly Guid _categoryId;
        private readonly string _newName;

        public RenameCategoryCommand(CategoryService service, Guid categoryId, string newName)
        {
            _service = service;
            _categoryId = categoryId;
            _newName = newName;
        }

        public void Execute()
        {
            _service.RenameCategory(_categoryId, _newName);
            Console.WriteLine($"Категория переименована в: {_newName}");
        }
    }
}
