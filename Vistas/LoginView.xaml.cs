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

        tel = txttelefono.Text;
        contra = txtcontra.Text;

        user.Telefono = tel;
        user.Contra = contra;

        var servicio = new ApiService();
        respuesta = await servicio.LoginApp(user); 
        if(respuesta.Telefono == tel && respuesta.Contra == contra)
        {
            await DisplayAlertAsync("PEROTE", "Bienvenido " + user.Nombre, "Ok"); 
            App.Current.MainPage = new AppShell();
        }
        else
        {
            await DisplayAlertAsync("PEROTE", "Usuario o contraseña incorrectos", "Ok");
        }

        
    }













}