using AppComercios.Modelos;
using AppComercios.Servicios;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

namespace AppComercios.Vistas.UsrComercio;

public partial class ComercioDetailView : ContentPage
{
    public ComercioDetailView(int idcomercio)
    {
        idcomer = idcomercio;
        InitializeComponent();
    }

    int idcomer = 0;

    ComerciosAuxClass comer = new ComerciosAuxClass();
    Location location = new Location();
    Pin marker = new Pin();

    protected override async void OnAppearing()
    {
        actividad.IsRunning = true;

        var servicio = new ServiciosComercio();

        comer = await servicio.GetComercioById(idcomer);

        txtcalle.Text = comer.Calle;
        txtgiro.Text = comer.Categoriatxt;
        txtlicenciamer.Text = comer.LicenciaMercantil;
        txtnombrecomer.Text = comer.Nombre;
        txtpropietario.Text = comer.Propietario;
        txtestatuspag.Text = comer.Pagado ? "Pagado" : "Pendiente de Pago";
        location = new Location(comer.Latitud, comer.Longitud);

        txtnumerodir.Text = comer.NumeroDir;
        txttelpropietario.Text = comer.TelPropietario;
        txtemailprop.Text = comer.EmailPropietario;
        txtdimensiones.Text = comer.DimensionesLocal;

        map.MoveToRegion(MapSpan.FromCenterAndRadius(location, Distance.FromKilometers(0.2)));

        addmarker(comer.Latitud, comer.Longitud, comer.Nombre);

        actividad.IsRunning = false;

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
        comer.IdUsuarioReg = Preferences.Get("iduser", 0);

        comer.EmailPropietario = txtemailprop.Text; 
        comer.TelPropietario = txttelpropietario.Text;
        comer.DimensionesLocal = txtdimensiones.Text;
        comer.NumeroDir = txtnumerodir.Text;
        comer.LicenciaMercantil = txtlicenciamer.Text; 

        var servicio = new ServiciosComercio();

        bool isConfirmed = await DisplayAlertAsync(
    "Actualizar Datos",
    "¿ Estas seguro de que los datos son correctos ?",
    "Si",
    "No"
);

        if (isConfirmed)
        {
            await servicio.ActualizarComercio(comer);
            await Navigation.PopAsync(true); 
        }


    }


}