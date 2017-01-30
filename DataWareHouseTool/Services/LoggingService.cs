using System;
using DataWareHouseTool.Services.Interfaces;

namespace DataWareHouseTool.Services
{
    public class LoggingService : ILoggingService
    {
        public void Log(Exception exception)
        {
            Console.WriteLine(exception);
        }
    }
}