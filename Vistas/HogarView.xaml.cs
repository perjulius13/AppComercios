using AppComercios.Modelos;
using AppComercios.Servicios;

namespace AppComercios.Vistas;

public partial class HogarView : ContentPage
{
	public HogarView()
	{
		InitializeComponent();
	}


    int iduser = 0;
    int totalcomer = 0;
    int visitas = 0;
    int pendientes = 0; 

    List<VisitComerAuxClass> lista = new List<VisitComerAuxClass>();

    protected override async void OnAppearing()
    {
        iduser = Preferences.Get("iduser", 0); 

        var servicio = new ServiciosComercio();
        lista = await servicio.ListarVisitasComercio(iduser);
        totalcomer = await servicio.GetTotalComercios();

        
        visitas = lista.Where(e => e.Atendida == false).Count();
        pendientes = visitas;

        txtpendientes.Text = pendientes.ToString(); 

        txtnombre.Text = "Bienvendido ! "+ Preferences.Get("nombreuser", "");
        txtvistias.Text = visitas.ToString(); 
        txttotalcomers.Text = totalcomer.ToString(); 


    }

}