using System;
using System.Collections.Generic;
using System.IO;

namespace Lesson
{
    class Program
    {
        static void Main(string[] args)
        {
            Pathfinder Path1 = new Pathfinder(new ConsoleLogWritter());
            Path1.Find("Пишу лог в консоль");

            Pathfinder Path2 = new Pathfinder(new FileLogWritter());
            Path2.Find("Пишу лог в файл");

            Pathfinder Path3 = new Pathfinder(new FridayLogWritter(new FileLogWritter()));
            Path3.Find("Пишу лог в пятницу в файл");

            Pathfinder Path4 = new Pathfinder(new FridayLogWritter(new ConsoleLogWritter()));
            Path4.Find("Пишу лог в пятницу в консоль");

            Pathfinder Path5 = new Pathfinder(ChainOfLogWritter.Create(new ConsoleLogWritter(), new FridayLogWritter(new FileLogWritter())));
            Path5.Find("Пишет лог в консоль а по пятницам ещё и в файл.");
        }
    }

    interface ILogger
    {
        public void WriteError(string message);
    }

    class Pathfinder
    {

        private ILogger _ilogger;

        public Pathfinder(ILogger ilogger)
        {
            _ilogger = ilogger;
        }

        public void Find(string message)
        {
            _ilogger.WriteError(message);
        }
    }

    class ConsoleLogWritter : ILogger
    {
        public virtual void WriteError(string message)
        {
            Console.WriteLine(message);
        }
    }

    class FileLogWritter : ILogger
    {
        public virtual void WriteError(string message)
        {
            File.WriteAllText("log.txt", message);
        }
    }

    class FridayLogWritter : ILogger
    {
        private ILogger _ilogger;

        public FridayLogWritter(ILogger ilogger)
        {
            _ilogger = ilogger;
        }

        public void WriteError(string message)
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
            {
                _ilogger.WriteError(message);
            }
        }
    }

    class ChainOfLogWritter : ILogger
    {
        private IEnumerable<ILogger> _logWritters;

        public ChainOfLogWritter(IEnumerable<ILogger> logWritters)
        {
            _logWritters = logWritters;
        }

        public void WriteError(string message)
        {
            foreach (var logWritter in _logWritters)
                logWritter.WriteError(message);
        }

        public static ChainOfLogWritter Create(params ILogger[] loggers)
        {
            return new ChainOfLogWritter(loggers);
        }
    }
}
 