using AppComercios.Modelos;
using AppComercios.Servicios;

namespace AppComercios.Vistas;

public partial class VisitasView : ContentPage
{
	public VisitasView()
	{
		InitializeComponent();
	}


    int idcomercio = 0;
    int idcategoria = 0;
    int idvisita = 0; 


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

    private async void lstcomercios_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        idcomercio = (int)(e.CurrentSelection.FirstOrDefault() as VisitComerAuxClass)?.Idcomercio;
        idcategoria = (int)(e.CurrentSelection.FirstOrDefault() as VisitComerAuxClass)?.IDcategoria;
        idvisita = (int)(e.CurrentSelection.FirstOrDefault() as VisitComerAuxClass)?.Id;

        await Navigation.PushAsync(new CobrarComercio(idcomercio, idcategoria, idvisita));
    }






}