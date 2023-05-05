using Microsoft.Extensions.Logging;
using Mobile.KMT.Services.Interfaces;
using System;
using System.Collections.Generic;
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
                string currentDate = DateTime.UtcNow.ToString("yyyy-MM-dd");
                string logFileName = $"app_logs_{currentDate}.txt";
                string logFilePath = Path.Combine(LogDirectory, logFileName);

                var logEntry = $"INFO\t{DateTime.UtcNow}: {message}{Environment.NewLine}";
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
                string currentDate = DateTime.UtcNow.ToString("yyyy-MM-dd");
                string logFileName = $"app_logs_{currentDate}.txt";
                string logFilePath = Path.Combine(LogDirectory, logFileName);

                var logEntry = $"WARN\t{DateTime.UtcNow}: {message}{Environment.NewLine}";
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

                string currentDate = DateTime.UtcNow.ToString("yyyy-MM-dd");
                string logFileName = $"app_logs_{currentDate}.txt";
                string logFilePath = Path.Combine(LogDirectory, logFileName);

                var logEntry = $"ERROR\t{DateTime.UtcNow}: {message}{Environment.NewLine}";
                await File.AppendAllTextAsync(logFilePath, logEntry);
            }
            catch (Exception ex)
            {
                await App.ShowWarning(ex.Message);
            }
        }
    }
}
