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
    string username = "";
    string contra = "";

    private async void Button_Clicked(object sender, EventArgs e)
    {
        actividad.IsRunning = true;

        btningresar.IsEnabled = false;

        txtusuario.Text = "VISITADOR1";
        txtcontra.Text = "123";

        username = txtusuario.Text;
        contra = txtcontra.Text;

        user.Username = username;
        user.Contra = contra;

        var servicio = new ApiService();
        respuesta = await servicio.LoginApp(user); 

        if(respuesta.Username == username && respuesta.Contra == contra)
        {
            Preferences.Set("iduser", respuesta.IdUser);
            Preferences.Set("tipouser", respuesta.IdTipoUser);
            Preferences.Set("saldouser", 500);
            Preferences.Set("nombreuser", respuesta.Nombre + " "  + respuesta.Paterno + " " +respuesta.Materno);
            

            await DisplayAlertAsync("PEROTE", "Bienvenido " + respuesta.Nombre + " " + respuesta.Paterno + " " + respuesta.Materno, "Ok");
            App.Current.MainPage = new AppShell();

          
        }
        else
        {
            await DisplayAlertAsync("PEROTE", "Usuario o contraseña incorrectos", "Ok");
        }



        actividad.IsRunning = false;
        btningresar.IsEnabled = true;
    }

    private async void btnregistrer_Clicked(object sender, EventArgs e)
    {
        actividad.IsRunning = true;

        btningresar.IsEnabled = false;

        txtusuario.Text = "COMERCIO1";
        txtcontra.Text = "123";

        username = txtusuario.Text;
        contra = txtcontra.Text;

        user.Username = username;
        user.Contra = contra;

        var servicio = new ApiService();
        respuesta = await servicio.LoginApp(user);

        if (respuesta.Username == username && respuesta.Contra == contra)
        {
            Preferences.Set("iduser", respuesta.IdUser);
            Preferences.Set("tipouser", respuesta.IdTipoUser);
            Preferences.Set("saldouser", 500);
            Preferences.Set("nombreuser", respuesta.Nombre + " " + respuesta.Paterno + " " + respuesta.Materno);


            await DisplayAlertAsync("PEROTE", "Bienvenido " + respuesta.Nombre + " " + respuesta.Paterno + " " + respuesta.Materno, "Ok");
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