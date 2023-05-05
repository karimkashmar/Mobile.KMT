using Mobile.KMT.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.KMT.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel()
        {
            Title = "Main Page";
        }

        public async Task OnLoaded()
        {
            try
            {
                await Shell.Current.GoToAsync($"{nameof(LoginPage)}", true);

            }
            catch (Exception ex)
            {

                // Log
            }
        }
    }
}
