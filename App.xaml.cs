namespace Mobile.KMT;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		MainPage = new AppShell();
	}

    public static async Task ShowWarning(string message)
    {
        await Shell.Current.DisplayAlert("Warning", message, "OK");
    }
    public static async Task ShowInfo(string message)
    {
        await Shell.Current.DisplayAlert("Notification", message, "OK");
    }


}
