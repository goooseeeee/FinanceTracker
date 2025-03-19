using System;
using System.Diagnostics;

namespace FinanceTracker.Commands
{
    public class CommandTimerDecorator : ICommand
    {
        private readonly ICommand _command;
        private readonly string _commandName;

        public CommandTimerDecorator(ICommand command)
        {
            _command = command;
            _commandName = command.GetType().Name;
        }

        public void Execute()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            _command.Execute();
            stopwatch.Stop();
            Console.WriteLine($"[TIME] Команда {_commandName} выполнена за {stopwatch.ElapsedMilliseconds} мс");
        }
    }
}
