using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        public LoginPageViewModel()
        {
            Title = "Login Page";
        }

        [ObservableProperty]
        string emailOrUsername;
        [ObservableProperty]
        string password;

        [RelayCommand]
        public async Task Login()
        {
            await App.ShowInfo($"{EmailOrUsername} - {Password}");
            //await Shell.Current.GoToAsync($"{nameof(LoginPage)}", true);

        }
    }
}
