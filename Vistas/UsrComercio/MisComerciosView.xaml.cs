using AppComercios.Modelos;
using AppComercios.Servicios;

namespace AppComercios.Vistas.UsrComercio;

public partial class MisComerciosView : ContentPage
{
	public MisComerciosView()
	{
		InitializeComponent();
	}


    ComerciosAuxClass comer = new ComerciosAuxClass();
    List<PropietarioComerAuxClass> lista = new List<PropietarioComerAuxClass>();
    int iduser = 0;

    protected override async void OnAppearing()
    {
        var servicio = new ServiciosComercio();
        iduser = Preferences.Get("iduser", 0);

        lista = await servicio.ListarComerciosPropietario(iduser);

        lstComercios.ItemsSource = lista;   
    }






}