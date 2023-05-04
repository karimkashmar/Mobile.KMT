using CommunityToolkit.Mvvm.ComponentModel;

namespace Mobile.KMT.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        string title;
        public BaseViewModel()
        {
            
        }

    }
}
