using Mobile.KMT.ViewModels;

namespace Mobile.KMT.Views;

public partial class MainPage : ContentPage
{
    private MainPageViewModel _viewModel;


    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

}