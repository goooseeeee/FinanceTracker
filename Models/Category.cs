using System;

namespace FinanceTracker.Models {
    public class Category
{
    public Guid Id { get; }  // Уникальный идентификатор категории
    public string Name { get; private set; }  // Название категории
    public CategoryType Type { get; }  // Тип категории (Доход / Расход)

    public Category(string name, CategoryType type)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Название категории не может быть пустым.", nameof(name));

        Id = Guid.NewGuid();
        Name = name;
        Type = type;
    }

    // Обновление названия категории
    public void Rename(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentException("Название категории не может быть пустым.", nameof(newName));

        Name = newName;
    }

    public override string ToString()
    {
        return $"{Name} ({Type})";
    }
}

// Перечисление для типа категории
public enum CategoryType
{
    Income,  // Доход
    Expense  // Расход
}
}