
using AppComercios.Modelos;
using AppComercios.Servicios;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

namespace AppComercios.Vistas;

public partial class MiPlazaView : ContentPage
{


	public MiPlazaView()
	{
		InitializeComponent();
        map.MoveToRegion(MapSpan.FromCenterAndRadius(PeroteCenter, Distance.FromKilometers(0.2)));
    }


	PlazaClass plaza = new PlazaClass();
    Pin marker = new Pin();


    private static readonly Location PeroteCenter = new(19.56188, -97.24406);

    protected override async void OnAppearing()
	{
        var servicio = new ApiService();
        plaza = await servicio.GetPlazaById(15);

        txtplaza.Text = "Plaza # " + plaza.Numero;
        txtcosto.Text = "Costo $ " + plaza.Costo;

        addmarker(plaza.Latitud, plaza.Longitud, plaza.Numero.ToString());
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