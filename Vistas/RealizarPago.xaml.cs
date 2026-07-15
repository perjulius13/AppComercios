using AppComercios.Modelos;
using AppComercios.Servicios;

namespace AppComercios.Vistas;

public partial class RealizarPago : ContentPage
{


	int id = 0; 
	public RealizarPago(int IdAsignacion)
	{
		id = IdAsignacion;
		InitializeComponent();
	}


	AsignacionPlazaClass item = new AsignacionPlazaClass(); 

    protected override async void OnAppearing()
	{
        var servicio = new ApiService();
		item = await servicio.GetAsignacionById(id);

		txtnumplaza.Text = item.NumeroPlaza.ToString();
		txtfechaasig.Text = item.FechaAsig.ToShortDateString();
		txttotal.Text = "50";

		if (item.Pagado)
			btnpagar.IsEnabled = false; 


    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var servicio = new ApiService();
        var items = await servicio.CobrarPlazaApp(item);
		await Navigation.PushAsync(new CalendarioView()); 
    }
}