using AppComercios.Modelos;
using AppComercios.Servicios;

namespace AppComercios.Vistas;

public partial class CalendarioView : ContentPage
{


    List<AsingacionPlazaClass> lista = new();

    

    public CalendarioView()
	{
		InitializeComponent();
        BindingContext = this; 
	}




    protected override async void OnAppearing()
    {
        var servicio = new ApiService();
        var items = await servicio.CalendarioPuestos(1);
        lista = items.ToList();
        



    }



}