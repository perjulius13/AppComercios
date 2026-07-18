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

        //txtpendientes.Text = (pendientes == 0) ? "No hay pagos pendientes" : "Pendientes: " + pendientes; 

    }



    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new CalendarioView());
    }

    private async void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new MiPlazaView());
    }

}