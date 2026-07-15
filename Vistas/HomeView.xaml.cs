using AppComercios.Modelos;
using AppComercios.Servicios;

namespace AppComercios.Vistas;

public partial class HomeView : ContentPage
{
	public HomeView()
	{
		InitializeComponent();
	}





    List<AsignacionPlazaClass> lista = new();

    int pendientes = 0; 

    protected override async void OnAppearing()
    {

        pendientes = 0;
        lista.Clear(); 
        var servicio = new ApiService();
        var items = await servicio.CalendarioPuestos(1);
        lista = items.ToList();


        foreach (var item in lista)
        {
            if (item.Pagado == false)
                pendientes++; 
        }

        txtpendientes.Text = (pendientes == 0) ? "No hay pagos pendientes" : "Pendientes: " + pendientes; 

    }


    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CalendarioView());
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CalendarioView());
    }



}