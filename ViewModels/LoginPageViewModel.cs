using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using Mobile.KMT.Services.Interfaces;
using Mobile.KMT.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.KMT.ViewModels
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        private readonly ILoggerService _logger;
        public LoginPageViewModel(ILoggerService logger)
        {
            Title = "Login Page";
            _logger = logger;
        }

        [ObservableProperty]
        string emailOrUsername;
        [ObservableProperty]
        string password;

        [RelayCommand]
        public async Task Login()
        {
            try
            {
                await _logger.LogInformation($"{EmailOrUsername} - {Password}");
                //await App.ShowInfo($"{EmailOrUsername} - {Password}");
                //await Shell.Current.GoToAsync($"{nameof(LoginPage)}", true);
            }
            catch (Exception ex)
            {
                await _logger.LogError($"{ex.Message} - {ex.StackTrace} - {ex.InnerException?.Message} - {ex.InnerException?.StackTrace}");
            }

        }
    }
}
