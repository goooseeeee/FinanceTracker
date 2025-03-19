using System;
using System.Collections.Generic;
using System.Linq;
using FinanceTracker.Models;
using FinanceTracker.Factory;

namespace FinanceTracker.Services {
    public class CategoryService
{
    private readonly List<Category> _categories = new List<Category>();

    // Создание новой категории
    public Category CreateCategory(string name, CategoryType type)
    {
        var category = EntityFactory.CreateCategory(name, type);
        _categories.Add(category);
        return category;
    }

    // Получение всех категорий
    public IEnumerable<Category> GetAllCategories()
    {
        return _categories;
    }

    // Поиск категории по ID
    public Category GetCategoryById(Guid categoryId)
    {
        return _categories.FirstOrDefault(cat => cat.Id == categoryId) ?? throw new InvalidOperationException("Категория не найдена.");
    }

    // Удаление категории по ID
    public void DeleteCategory(Guid categoryId)
    {
        var category = GetCategoryById(categoryId);
        _categories.Remove(category);
    }

    // Переименование категории
    public void RenameCategory(Guid categoryId, string newName)
    {
        var category = GetCategoryById(categoryId);
        category.Rename(newName);
    }
}
}