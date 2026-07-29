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
    }



    List<CategoriaComerClass> lista = new List<CategoriaComerClass>();
    List<TipoComercioClass> listatipocomer = new List<TipoComercioClass>();
    Pin marker = new Pin();
    ComerciosClass comer = new ComerciosClass();
    List<int> zona = new List<int>();

    protected override async void OnAppearing()
    {
        actividad.IsRunning = true;

        getLocation();


        for (int i = 1; i < 10; i++)
        {
            zona.Add(i);
            cbzona.Items.Add(i.ToString());
        }

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

        actividad.IsRunning = false;
    }

    public async void getLocation()
    {
        
        var request = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(10));
        using var cts = new CancellationTokenSource();
        Location location = await Geolocation.Default.GetLocationAsync(request, cts.Token);

        if (location != null)
        {
            txtlatitud.Text = location.Latitude.ToString();
            txtlongitud.Text = location.Longitude.ToString();
            map.MoveToRegion(MapSpan.FromCenterAndRadius(location, Distance.FromKilometers(0.3)));
            addmarker(location.Latitude, location.Longitude, "Ubicacion predeterminada");

            GetAddressFromLocation(location.Latitude, location.Longitude); 

//            await DisplayAlertAsync("Direccion", direccion, "Ok");
        }

    }

    string mensaje = ""; 
    string direccion = ""; 
    public async void GetAddressFromLocation(double latitude, double longitude)
    {        
            IEnumerable<Placemark> placemarks = await Geocoding.Default.GetPlacemarksAsync(latitude, longitude);
            Placemark placemark = placemarks?.FirstOrDefault();

            if (placemark != null)
            {
                // 2. Format and return the address string
                direccion =  $"{placemark.Thoroughfare} {placemark.SubThoroughfare}, " +
                       $"{placemark.Locality}, {placemark.AdminArea} {placemark.PostalCode}, " +
                       $"{placemark.CountryName}";

            comer.Calle = placemark.Thoroughfare;
            comer.Cp = Convert.ToInt32(placemark.PostalCode) ;
            comer.Colonia = placemark.SubLocality;
            comer.NumeroDir = placemark.SubThoroughfare; 

                
            }        
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

    string select = "";
    private async void Button_Clicked(object sender, EventArgs e)
    {
        //registrar comercio 
        btnRegistrar.IsEnabled = false;

        comer.Nombre = txtnombre.Text;

        select = cbcategoria.SelectedItem.ToString();
        comer.IdCategoria = lista.Where(e => e.Categoria == select).FirstOrDefault().IdCat;
        select = cbtipocomercio.SelectedItem.ToString();
        comer.IdTipoComercio = listatipocomer.Where(e => e.Tipo == select).FirstOrDefault().IdTipoComer;

        comer.Latitud = Convert.ToDouble(txtlatitud.Text);
        comer.Longitud = Convert.ToDouble(txtlongitud.Text);
        comer.Observaciones = txtobservaciones.Text;
        comer.LicenciaMercantil = txtlicencia.Text;
        comer.Propietario = txtpropietarionombre.Text;
        comer.TelPropietario = txttelefonoprop.Text;
        comer.EmailPropietario = txtemailprop.Text;
        comer.Habilitado = true;
        comer.IdUsuarioReg = Preferences.Get("iduser", 0);
        comer.Usuarioreg = Preferences.Get("nombreuser", "");
        comer.Zona = Convert.ToInt32(cbzona.SelectedItem);
        comer.IdSubcategoria = 1; 

        var servicio = new ServiciosComercio();
        await servicio.RegistrarComercio(comer);

        comer = new ComerciosClass();

        App.Current.MainPage = new AppShell();

    }

}