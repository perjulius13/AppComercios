using AppComercios.Modelos;
using AppComercios.Servicios;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

namespace AppComercios.Vistas;

public partial class MapaView : ContentPage
{
	public MapaView()
	{
		InitializeComponent();
        map.MoveToRegion(MapSpan.FromCenterAndRadius(PeroteCenter, Distance.FromKilometers(0.5)));
    }



    private static readonly Location PeroteCenter = new(19.56188, -97.24406);

    List<PlazaClass> lista = new List<PlazaClass>(); 


    protected override async void OnAppearing()
    {
        var servicio = new ApiService();
        lista = await servicio.ListarPlazas();
        string titulo = ""; 

        foreach (var item in lista)
        {
            titulo = "Plaza # " + item.Numero; 
            addmarker(item.Latitud, item.Longitud, titulo);
        }

    }


    Pin marker = new Pin(); 


    public void addmarker(double lat, double longi, string titulo)
    {
        marker = new Pin
        {
            Label =titulo,
            Type = PinType.Place,
            Location = new Location(lat, longi) ,
        };

        map.Pins.Add(marker); 
    }


}