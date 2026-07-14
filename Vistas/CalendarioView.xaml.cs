using AppComercios.Modelos;
using AppComercios.Servicios;

namespace AppComercios.Vistas;

public partial class CalendarioView : ContentPage
{


    List<AsignacionPlazaClass> lista = new();

    

    public CalendarioView()
	{
		InitializeComponent();
       
	}




    protected override async void OnAppearing()
    {
        actividad.IsEnabled = true; 

        var servicio = new ApiService();
        var items = await servicio.CalendarioPuestos(1);
        lista = items.ToList();

        lstcalendario.ItemsSource = lista;
        actividad.IsEnabled = false;
    }

    int idasig = 0; 

    public async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        //string previous = (e.PreviousSelection.FirstOrDefault() as AsingacionPlazaClass)?.NombrePuesto;
        //string current = (e.CurrentSelection.FirstOrDefault() as AsingacionPlazaClass)?.NombrePuesto;

        idasig =(int)(e.CurrentSelection.FirstOrDefault() as AsignacionPlazaClass)?.Id; 
        await Navigation.PushAsync(new RealizarPago(idasig));
       

    }



}