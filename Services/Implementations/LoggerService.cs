using Microsoft.Extensions.Logging;
using Mobile.KMT.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.KMT.Services.Implementations
{
    public class LoggerService : ILoggerService
    {
        private string LogDirectory;

        public LoggerService()
        {
            LogDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        }
        public async Task LogInformation(string message)
        {
            try
            {
                var callingMethod = new StackTrace(skipFrames: 5).GetFrame(0).GetMethod();
                var callingClassName = callingMethod.DeclaringType.Name;
                var callingMethodName = callingMethod.Name;


                string currentDate = DateTime.UtcNow.ToString("yyyy-MM-dd");
                string logFileName = $"app_logs_{currentDate}.txt";
                string logFilePath = Path.Combine(LogDirectory, logFileName);

                var logEntry = ToLog("INFO", message, callingClassName, callingMethodName);
                await File.AppendAllTextAsync(logFilePath, logEntry);
            }
            catch (Exception ex)
            {
                await App.ShowWarning(ex.Message);
            }
        }

        public async Task LogWarning(string message)
        {
            try
            {
                var callingMethod = new StackTrace(skipFrames: 5).GetFrame(0).GetMethod();
                var callingClassName = callingMethod.DeclaringType.Name;
                var callingMethodName = callingMethod.Name;

                string currentDate = DateTime.UtcNow.ToString("yyyy-MM-dd");
                string logFileName = $"app_logs_{currentDate}.txt";
                string logFilePath = Path.Combine(LogDirectory, logFileName);

                var logEntry = ToLog("WARN", message, callingClassName, callingMethodName);
                await File.AppendAllTextAsync(logFilePath, logEntry);
            }
            catch (Exception ex)
            {
                await App.ShowWarning(ex.Message);
            }
        }

        public async Task LogError(string message)
        {
            try
            {
                await App.ShowWarning(message);

                var callingMethod = new StackTrace(skipFrames: 5).GetFrame(0).GetMethod();
                var callingClassName = callingMethod.DeclaringType.Name;
                var callingMethodName = callingMethod.Name;

                string currentDate = DateTime.UtcNow.ToString("yyyy-MM-dd");
                string logFileName = $"app_logs_{currentDate}.txt";
                string logFilePath = Path.Combine(LogDirectory, logFileName);

                var logEntry = ToLog("ERROR", message, callingClassName, callingMethodName);
                await File.AppendAllTextAsync(logFilePath, logEntry);
            }
            catch (Exception ex)
            {
                await App.ShowWarning(ex.Message);
            }
        }

        public string ToLog(string logType, string message, string callingClassName, string callingMethodName)
        {
            return $"{logType}\t{DateTime.UtcNow} - {callingClassName} - {callingMethodName}: {message}{Environment.NewLine}";
        }
    }
}
