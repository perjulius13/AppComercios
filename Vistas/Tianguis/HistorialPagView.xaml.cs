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



    DateTime fecha1 = new DateTime();
    DateTime fecha2 = new DateTime();

    string f1 = "";
    string f2 = ""; 


        

    List<CobroPlazaClass> lista = new List<CobroPlazaClass>(); 

    protected override async void OnAppearing()
    {

        fecha1 = DateTime.Now;
        fecha2 = DateTime.Now;

        f1 = "01-07-2026";
        f2 = fecha2.Day + "-" + fecha2.Month + "-" + fecha2.Year;

        var servicio = new ApiService();

        lista = await servicio.ListarCobrosUser(f1, f2);


        cvComercios.ItemsSource = lista; 


    }




}