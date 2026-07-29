
using AppComercios.Modelos;
using AppComercios.Servicios;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

namespace AppComercios.Vistas;

public partial class CobrarComercio : ContentPage
{

    int idcomercio = 0; 
    int idcategoria = 0;
    int idvisita = 0; 
	public CobrarComercio(int idcomer, int idcat, int idvisit)
	{
        idcomercio = idcomer; 
        idcategoria = idcat; 
        idvisita = idvisit;
		InitializeComponent();
	}

    VisitasComercioclass visita = new VisitasComercioclass(); 
    CategoriaComerClass cate = new CategoriaComerClass();
    ComerciosClass comer = new ComerciosClass();
    PagosClass pag = new PagosClass(); 
    double total = 0;
    Pin marker = new Pin();

    protected override async void OnAppearing()
    {
        var servicio = new ServiciosComercio();
        cate = await servicio.GetCategoriaById(idcategoria);
        comer = await servicio.GetComercioById(idcomercio);


        for (int i = 1; i < 30; i++)
        {
            cbyears.Items.Add(i.ToString());
        }

        cbyears.SelectedIndex = 0; 

        txtnombrecomer.Text = comer.Nombre; 

        txtcostolic.Text = cate.CostoLicencia.ToString();
        txtidcomer.Text = idcomercio.ToString();

        txttotal.Text = cate.CostoLicencia.ToString();

        Location location = new Location(comer.Latitud, comer.Longitud); 

        map.MoveToRegion(MapSpan.FromCenterAndRadius(location, Distance.FromKilometers(0.3)));

        addmarker(comer.Latitud, comer.Longitud, "Comercio " + comer.IdComer); 
    }



    private void PickerCiudades_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;

        if (picker.SelectedIndex == -1)
            return;

        string valor = picker.SelectedItem. ToString();

        total = Convert.ToDouble(valor) * cate.CostoLicencia;
        pag.Total = total; 
        txttotal.Text = total.ToString();   

    
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        //cobrar comercio 
        var servicio = new ServiciosComercio();

        pag.IdComercio = idcomercio;
        pag.IdUserReg = Preferences.Get("iduser", 0);
        pag.Cantidad = Convert.ToInt32(cbyears.SelectedItem);
        pag.Importe = cate.CostoLicencia;


        visita.Id = idvisita;
        visita.Atendida = true;
        visita.Observaciones = ""; 
        

        await servicio.CobrarComercio(pag);
        await servicio.ActualizarVisita(visita); 


        App.Current.MainPage = new AppShell();
    }


    public void addmarker(double lat, double longi, string titulo)
    {
        marker = new Pin
        {
            Label = titulo,
            Type = PinType.Place,
            Location = new Location(lat, longi),
        };

        map.Pins.Add(marker);
    }


}