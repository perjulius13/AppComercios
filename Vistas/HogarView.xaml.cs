namespace AppComercios.Vistas;

public partial class HogarView : ContentPage
{
	public HogarView()
	{
		InitializeComponent();
	}





    protected override void OnAppearing()
    {
        txtnombre.Text = "Bienvendido ! "+ Preferences.Get("nombreuser", ""); 
    }

}