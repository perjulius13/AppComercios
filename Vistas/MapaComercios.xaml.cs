using AppComercios.Modelos;
using AppComercios.Servicios;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

namespace AppComercios.Vistas;

public partial class MapaComercios : ContentPage
{
	public MapaComercios()
	{
		InitializeComponent();
        map.MoveToRegion(MapSpan.FromCenterAndRadius(PeroteCenter, Distance.FromKilometers(0.5)));
    }


    private static readonly Location PeroteCenter = new(19.56188, -97.24406);

    List<ComerciosAuxClass> lista = new List<ComerciosAuxClass>();

    protected override async void OnAppearing()
    {
        var servicio = new ServiciosComercio();
        lista = await servicio.ListarComercios();
        
        string titulo = "";

        foreach (var item in lista)
        {
            titulo = "Comercio # " + item.IdComer;
            addmarker(item.Latitud, item.Longitud, titulo);
        }

        txttotal.Text = "Total de comercios " + lista.Count; 
        //txtTotal.Text = "Total de Plazas: " + lista.Count;
        //txtocupadas.Text = "Plazas ocupadas " + listaocupadas.Count;

    }

    Pin marker = new Pin();


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