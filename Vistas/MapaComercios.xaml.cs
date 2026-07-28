
using AppComercios.Modelos;
using AppComercios.Servicios;
using AppComercios.Vistas.Componentes;
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

    Pin marker = new Pin();

    MapPin pin;

    MapPin[] pines;

    private List<MapPin> _pins;
    public List<MapPin> Pins
    {
        get { return _pins; }
        set { _pins = value; OnPropertyChanged(); }
    }

    string icono = ""; 
    protected override async void OnAppearing()
    {
        var servicio = new ServiciosComercio();
        lista = await servicio.ListarComercios();
        
        string titulo = "";
        int indice = 0;

        pines = new MapPin[lista.Count];

        foreach (var item in lista)
        {
            titulo = "Comercio # " + item.IdComer;


            pin = new MapPin(MapPinClicked)
            {
                Id = Guid.NewGuid().ToString(),
                Position = new Location(item.Latitud, item.Longitud),
                IconSrc = item.Pagado ? "greenpin" : "redpin"
            };

            pines[indice] = pin;
            indice++; 

        }

        Pins = pines.ToList();

        map.CustomPins = Pins;

        txttotal.Text = "Total de comercios " + lista.Count; 


    }






    private void MapPinClicked(MapPin pin)
    {
        // Handle pin click
    }

    //public void addmarker(double latitud, double longitud, string icono)
    //{
    //    pin = new MapPin(MapPinClicked)
    //    {
    //        Id = Guid.NewGuid().ToString(),
    //        Position = new Location(lista[x].Latitud.Value, lista[x].Longitud.Value),
    //        IconSrc = icono
    //    };

    //}


    //public void addmarker(double lat, double longi, string titulo)
    //{
    //    marker = new Pin
    //    {
    //        Label = titulo,
    //        Type = PinType.Place,
    //        Location = new Location(lat, longi),

    //    };

    //    map.Pins.Add(marker);
    //}




}