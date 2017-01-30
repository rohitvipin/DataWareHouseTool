using System;

namespace DataWareHouseTool.Services.Interfaces
{
    public interface ILoggingService
    {
        void Log(Exception exception);
    }
}