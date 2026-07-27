using AppComercios.Modelos;
using AppComercios.Servicios;

namespace AppComercios.Vistas;

public partial class RegistrarComercio : ContentPage
{
	public RegistrarComercio()
	{
		InitializeComponent();
	}



	List<CategoriaComerClass> lista = new List<CategoriaComerClass>();


    protected override async void OnAppearing()
	{
		var servicio = new ServiciosComercio();
		lista = await servicio.ListarCategorias();

		foreach (var item in lista)
		{
			cbcategoria.Items.Add(item.Categoria); 
		}

    }






}