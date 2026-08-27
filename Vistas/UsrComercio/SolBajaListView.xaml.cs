using AppComercios.Modelos;
using AppComercios.Servicios;

namespace AppComercios.Vistas.UsrComercio;

public partial class SolBajaListView : ContentPage
{
	public SolBajaListView()
	{
		InitializeComponent();
	}



    List<SolBajaComerAuxClass> lst = new List<SolBajaComerAuxClass>();
    
    int iduser = 0;



    protected override async void OnAppearing()
    {
        actividad.IsRunning = true; 

        var servicio = new ServiciosComercio();
        iduser = Preferences.Get("iduser", 0);

        lst = await servicio.ListarSolBajas(iduser);
        lstbajas.ItemsSource = lst;
        actividad.IsRunning = false; 
    }


    private void lstComercios_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        //mirar solicitud 

    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SolBajaComerView())  ;
    }


}