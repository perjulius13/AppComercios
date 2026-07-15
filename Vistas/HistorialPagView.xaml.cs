using AppComercios.Modelos;
using AppComercios.Servicios;
using System.Collections.ObjectModel;

namespace AppComercios.Vistas;

public partial class HistorialPagView : ContentPage
{



    public HistorialPagView()
	{
		InitializeComponent();



    }


    List<CobroPlazaClass> lista = new List<CobroPlazaClass>(); 

    protected override async void OnAppearing()
    {
        var servicio = new ApiService();

        lista = await servicio.ListarCobrosUser();


        cvComercios.ItemsSource = lista; 


    }




}