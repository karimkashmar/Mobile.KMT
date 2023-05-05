using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.KMT.Services.Interfaces
{
    public interface ILoggerService
    {
        Task LogInformation(string message);
        Task LogWarning(string message);
        Task LogError(string message);
    }
}
