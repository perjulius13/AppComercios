using AppComercios.Modelos;
using AppComercios.Servicios;

namespace AppComercios.Vistas;

public partial class CalendarioView : ContentPage
{


    List<AsingacionPlazaClass> lista = new();

    AsingacionPlazaClass elemento = new AsingacionPlazaClass(); 

    public CalendarioView()
	{
		InitializeComponent();
	}




    protected override async void OnAppearing()
    {
        var servicio = new ApiService();
        var items = await servicio.ListarAsignaciones();
        lista = items.ToList();
        if (lista.Count > 0)
            elemento = lista[0]; 
    }



}