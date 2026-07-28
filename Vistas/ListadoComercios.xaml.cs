using AppComercios.Modelos;
using AppComercios.Servicios;

namespace AppComercios.Vistas;

public partial class ListadoComercios : ContentPage
{
	public ListadoComercios()
	{
		InitializeComponent();
	}


	List<ComerciosAuxClass> lista = new List<ComerciosAuxClass>();

    int idcomercio = 0;
    int idcategoria = 0; 

    protected override async void OnAppearing()
	{
		actividad.IsEnabled = true;


        var servicio = new ServiciosComercio();
        lista = await servicio.ListarComercios();

		foreach (var item in lista)
		{
            item.EstatusPag = item.Pagado ? "Pagado" : "Pago Pendiente";
        }

		lstcalendario.ItemsSource = lista; 


        actividad.IsEnabled = false; 
	}



    public async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        idcomercio = (int)(e.CurrentSelection.FirstOrDefault() as ComerciosAuxClass)?.IdComer;
        idcategoria = (int)(e.CurrentSelection.FirstOrDefault() as ComerciosAuxClass)?.IdCategoria;
        await Navigation.PushAsync(new CobrarComercio(idcomercio, idcategoria));
    }


}