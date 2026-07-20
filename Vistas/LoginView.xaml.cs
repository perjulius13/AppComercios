namespace AppComercios.Vistas;

public partial class LoginView : ContentPage
{
	public LoginView()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		App.Current.MainPage = new AppShell(); 
    }





}