
using AppComercios.Modelos;
using AppComercios.Servicios;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

namespace AppComercios.Vistas.UsrComercio;

public partial class MiComercioView : ContentPage
{
	public MiComercioView()
	{
		InitializeComponent();
	}



    ComerciosAuxClass comer = new ComerciosAuxClass();
    Location location = new Location();
    Pin marker = new Pin();

    protected override async void OnAppearing()
    {
        var servicio = new ServiciosComercio();

        comer = await servicio.GetComercioById(1);

        txtcalle.Text = comer.Calle;
        txtgiro.Text = comer.Categoriatxt;
        txtlicenciamer.Text = comer.LicenciaMercantil; 
        txtnombrecomer.Text = comer.Nombre;
        txtpropietario.Text = comer.Propietario;
        txtestatuspag.Text = comer.Pagado ? "Pagado" : "Pendiente de Pago"; 
        location = new Location(comer.Latitud, comer.Longitud); 

        map.MoveToRegion(MapSpan.FromCenterAndRadius(location, Distance.FromKilometers(0.2)));

        addmarker(comer.Latitud, comer.Longitud, comer.Nombre); 
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