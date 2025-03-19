FinanceTracker

1. Описание проекта

FinanceTracker — это консольное приложение для учёта финансов. Оно позволяет создавать банковские счета, категории расходов и доходов, управлять операциями, а также экспортировать данные в JSON, YAML, CSV.

Реализованный функционал:
Создание и управление банковскими счетами.
Добавление категорий (например, "Еда", "Транспорт").
Запись операций (доходы, расходы).
Экспорт данных в JSON, YAML, CSV.
Командная система для выполнения действий.

2. SOLID и GRASP в проекте

SOLID
S (Single Responsibility Principle) – Каждый класс отвечает за одну задачу:
BankAccountService — управление банковскими счетами.
OperationService — управление операциями.
CategoryService — управление категориями.
DataImportExportService — отвечает только за экспорт данных.
O (Open/Closed Principle) – Новые форматы экспорта можно добавить, создав новый IDataExporter<T>.
L (Liskov Substitution Principle) – JsonDataExporter<T>, YamlDataExporter<T>, CsvDataExporter<T> реализуют общий интерфейс IDataExporter<T>.
I (Interface Segregation Principle) – Разделение интерфейсов: IDataExporter<T> используется только для экспорта, DataImporter<T> только для импорта.
D (Dependency Inversion Principle) – DataImportExportService зависит от IDataExporter<T>, а не от конкретных реализаций.
GRASP
Information Expert – Логика работы с операциями, счетами и категориями размещена в соответствующих сервисах.
Creator – BankAccountService, OperationService, CategoryService создают объекты (BankAccount, Operation, Category).
Controller – Program управляет основным потоком выполнения.
3. Используемые паттерны GoF

Factory Method (EntityFactory)
Используется для создания объектов BankAccount, Operation, Category.
Упрощает управление созданием объектов и изолирует их от основной бизнес-логики.
Command (CreateAccountCommand, WithdrawAccountCommand, DeleteOperationCommand)
Реализует паттерн Команда, который позволяет отделить выполнение операций от вызывающего кода.
Decorator (LoggingOperationService)
Добавляет логирование к OperationService, не изменяя его код.

4. Инструкция по запуску

Требования:
.NET SDK 6.0+
ОС: Windows, MacOS, Linux
Клонирование репозитория:
git clone <ссылка на репозиторий>
Запуск:
Открыть терминал / командную строку.
Перейти в папку проекта:
cd FinanceTracker
Скомпилировать проект:
dotnet build
Запустить приложение:
dotnet run
Тестирование экспорта
После запуска, данные экспортируются в:

FinanceTracker/Testing/FinancialExports/
Файлы:

data.json
data.yaml
data.csv
