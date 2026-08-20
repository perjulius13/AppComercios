using AppComercios.Modelos;
using AppComercios.Servicios;

namespace AppComercios.Vistas.UsrComercio;

public partial class SolBajaComerView : ContentPage
{
	public SolBajaComerView()
	{
		InitializeComponent();
	}

	int idcomer = 0; 

	ComerciosAuxClass comer = new ComerciosAuxClass(); 
    private async void Button_Clicked(object sender, EventArgs e)
    {
		var servicio = new ServiciosComercio();
		idcomer = Convert.ToInt32(txtcomercio.Text); 

		comer = await servicio.GetComercioById(idcomer);

    }




}