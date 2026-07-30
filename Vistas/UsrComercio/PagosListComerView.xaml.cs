using AppComercios.Modelos;
using AppComercios.Servicios;

namespace AppComercios.Vistas.UsrComercio;

public partial class PagosListComerView : ContentPage
{
	public PagosListComerView()
	{
		InitializeComponent();
	}




    List<PagosClass> lista = new List<PagosClass>(); 

    protected override async void OnAppearing()
    {
        var servicio = new ServiciosComercio();
        lista = await servicio.GetUltimosDiezPagos(1);

        lstPagos.ItemsSource = lista; 


    }


}