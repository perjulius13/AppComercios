using AppComercios.Modelos;
using AppComercios.Servicios;

namespace AppComercios.Vistas.UsrComercio;

public partial class SolBajaListView : ContentPage
{
	public SolBajaListView()
	{
		InitializeComponent();
	}



    List<PropietarioComerAuxClass> lista = new List<PropietarioComerAuxClass>();
    int iduser = 0;



    protected override async void OnAppearing()
    {
        var servicio = new ServiciosComercio();
        iduser = Preferences.Get("iduser", 0);

        lista = await servicio.ListarComerciosPropietario(iduser);

        lstComercios.ItemsSource = lista;
    }

    private void lstComercios_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        //mirar solicitud 
    }




}