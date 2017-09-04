namespace AnotherWebFormsIocApproach
{
    using System;
    using System.Diagnostics;

    public interface ILogger 
    {
        Guid Id { get; }
        void LogMessage(string message);
    }

    public class Logger : ILogger, IDisposable
    {
        public Logger()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }

        public void LogMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void Dispose()
        {
            Debug.WriteLine("Logger was disposed.");
        }
    }
}