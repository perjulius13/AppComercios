namespace AppComercios.Vistas.UsrComercio;

public partial class HomeComercioView : ContentPage
{
	public HomeComercioView()
	{
		InitializeComponent();
	}


    string username = "";

    protected override void OnAppearing()
    {
        username = Preferences.Get("nombreuser", "");

        txtnombre.Text = username;

    }


}