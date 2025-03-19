using System;
using FinanceTracker.Models;
using FinanceTracker.Services;

namespace FinanceTracker.Commands
{
    public class CreateCategoryCommand : ICommand
    {
        private readonly CategoryService _service;
        private readonly string _name;
        private readonly CategoryType _type;

        public CreateCategoryCommand(CategoryService service, string name, CategoryType type)
        {
            _service = service;
            _name = name;
            _type = type;
        }

        public void Execute()
        {
            var category = _service.CreateCategory(_name, _type);
            Console.WriteLine($"Создана новая категория: {category}");
        }
    }
}
