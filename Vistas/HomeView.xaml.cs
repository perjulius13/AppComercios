namespace AppComercios.Vistas;

public partial class HomeView : ContentPage
{
	public HomeView()
	{
		InitializeComponent();
	}



    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CalendarioView());

    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HistorialPagView());
    }



}