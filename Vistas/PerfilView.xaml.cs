using AppComercios.Modelos;
using AppComercios.Servicios;

namespace AppComercios.Vistas;

public partial class PerfilView : ContentPage
{
	public PerfilView()
	{
		InitializeComponent();
	}





	UsuariosClass user = new UsuariosClass();

	int iduser = 0; 

    protected override async void OnAppearing()
	{
		iduser = Preferences.Get("iduser", 0); 
        var servicio = new ApiService();
        var item = await servicio.GetDatosUser(iduser);
		user = item;

		txtnombre.Text = "Nombre: " + user.Nombre;
        txtapellido.Text = "Apellidos: " + user.Paterno + " " + user.Materno;
        txttelefono.Text = "Telefono: " + user.Telefono;
		txtsaldo.Text = "Saldo: 500" ; 
		if (user.Habilitado)
			txtHabilitado.Text = "Estatus: Habilitado"; 
		else
            txtHabilitado.Text = "Estatus: Deshabilitado";

    }


}