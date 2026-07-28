using AppComercios.Modelos;
using AppComercios.Servicios;

namespace AppComercios.Vistas;

public partial class CobrarComercio : ContentPage
{

    int idcomercio = 0; 
    int idcategoria = 0; 
	public CobrarComercio(int idcomer, int idcat)
	{
        idcomercio = idcomer; 
        idcategoria = idcat; 
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {

    }


    CategoriaComerClass cate = new CategoriaComerClass();
    ComerciosClass comer = new ComerciosClass(); 

    protected override async void OnAppearing()
    {
        var servicio = new ServiciosComercio();
        cate = await servicio.GetCategoriaById(idcategoria);
        comer = await servicio.GetComercioById(idcomercio);


        for (int i = 1; i < 20; i++)
        {
            cbyears.Items.Add(i.ToString());
        }

        txtnombrecomer.Text = "Comercio: " + comer.Nombre; 

        txtcostolic.Text = cate.CostoLicencia.ToString();
        txtidcomer.Text = "ID del comercio " + comer.IdComer.ToString();

        txttotal.Text = cate.CostoLicencia.ToString(); 

    }



}