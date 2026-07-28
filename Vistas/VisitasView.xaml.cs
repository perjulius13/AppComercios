using AppComercios.Modelos;
using AppComercios.Servicios;

namespace AppComercios.Vistas;

public partial class VisitasView : ContentPage
{
	public VisitasView()
	{
		InitializeComponent();
	}




    List<VisitComerAuxClass> lista = new List<VisitComerAuxClass>();
    int iduser = 0; 

    protected override async void OnAppearing()
    {
        actividad.IsRunning = true; 

        iduser = Preferences.Get("iduser", 0); 
        var servicio = new ServiciosComercio();
        lista = await servicio.ListarVisitasComercio(iduser);

        lstcomercios.ItemsSource = lista; 
        actividad.IsRunning = false; 
    }


}