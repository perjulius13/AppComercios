using AppComercios.Modelos;
using AppComercios.Servicios;

namespace AppComercios.Vistas;

public partial class LoginView : ContentPage
{
    public LoginView()
    {
        InitializeComponent();
    }


    UsuariosClass user = new UsuariosClass();
    UsuariosClass respuesta = new UsuariosClass();
    string tel = "";
    string contra = "";

    private async void Button_Clicked(object sender, EventArgs e)
    {
        actividad.IsRunning = true;

        btningresar.IsEnabled = false;

        txttelefono.Text = "2222398762";
        txtcontra.Text = "123"; 

        tel = txttelefono.Text;
        contra = txtcontra.Text;

        user.Telefono = tel;
        user.Contra = contra;

        var servicio = new ApiService();
        respuesta = await servicio.LoginApp(user); 

        if(respuesta.Telefono == tel && respuesta.Contra == contra)
        {
            Preferences.Set("iduser", respuesta.Iduser);
            Preferences.Set("saldouser", respuesta.Saldo);
            Preferences.Set("nombreuser", respuesta.Nombre + " "  + respuesta.Apellidos);
            

            await DisplayAlertAsync("PEROTE", "Bienvenido " + respuesta.Nombre + " " + respuesta.Apellidos, "Ok"); 
            App.Current.MainPage = new AppShell();
        }
        else
        {
            await DisplayAlertAsync("PEROTE", "Usuario o contraseña incorrectos", "Ok");
        }



        actividad.IsRunning = false;
        btningresar.IsEnabled = true;
    }













}