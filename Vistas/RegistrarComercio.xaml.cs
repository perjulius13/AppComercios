using AppComercios.Modelos;
using AppComercios.Servicios;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

namespace AppComercios.Vistas;

public partial class RegistrarComercio : ContentPage
{
	public RegistrarComercio()
	{
		InitializeComponent();
        map.MoveToRegion(MapSpan.FromCenterAndRadius(pueblacenter, Distance.FromKilometers(0.2)));
    }

    private static readonly Location PeroteCenter = new(19.56188, -97.24406);
    Location pueblacenter = new Location(19.0851559, -98.2080411); 

    List<CategoriaComerClass> lista = new List<CategoriaComerClass>();
    List<TipoComercioClass> listatipocomer = new List<TipoComercioClass>();
    Pin marker = new Pin();
    ComerciosClass comer = new ComerciosClass(); 

    protected override async void OnAppearing()
	{
		var servicio = new ServiciosComercio();
		lista = await servicio.ListarCategorias();
        listatipocomer = await servicio.ListarTipoComercio();

        foreach (var item in listatipocomer)
        {
            cbtipocomercio.Items.Add(item.Tipo); 
        }

		foreach (var item in lista)
		{
			cbcategoria.Items.Add(item.Categoria); 
		}

        getLocation(); 
    }





	public async void getLocation ()
	{
        Location location = await Geolocation.Default.GetLastKnownLocationAsync();

        if (location != null)
        { 
            txtlatitud.Text = location.Latitude.ToString();
            txtlongitud.Text = location.Longitude.ToString();
            addmarker(location.Latitude, location.Longitude, "Ubicacion predeterminada"); 
        }

            //return $"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}";
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

    private async void Button_Clicked(object sender, EventArgs e)
    {
        //registrar comercio 

        comer.Nombre = txtnombre.Text;
        comer.IdCategoria = cbcategoria.SelectedIndex;
        comer.IdTipoComercio = 0;
        comer.Latitud = Convert.ToDouble(txtlatitud.Text);


        var servicio = new ServiciosComercio();
        await servicio.RegistrarComercio(comer);
    }

}