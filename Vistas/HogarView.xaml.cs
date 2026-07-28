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

    List<VisitComerAuxClass> lista = new List<VisitComerAuxClass>();

    protected override async void OnAppearing()
    {
        iduser = Preferences.Get("iduser", 0); 

        var servicio = new ServiciosComercio();
        lista = await servicio.ListarVisitasComercio(iduser);
        totalcomer = await servicio.GetTotalComercios(); 

        txtnombre.Text = "Bienvendido ! "+ Preferences.Get("nombreuser", "");
        txtvistias.Text =  lista.Count.ToString();
        txttotalcomers.Text = totalcomer.ToString(); 

    }

}