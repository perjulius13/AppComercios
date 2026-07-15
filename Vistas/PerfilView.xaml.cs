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


    protected override async void OnAppearing()
	{
        var servicio = new ApiService();
        var item = await servicio.GetDatosUser(1);
		user = item;

		txtnombre.Text = "Nombre: " + user.Nombre;
        txtapellido.Text = "Apellidos: " + user.Apellidos;
        txttelefono.Text = "Telefono: " + user.Telefono;
		txtsaldo.Text = "Saldo: " + user.Saldo; 
		if (user.Habilitado)
			txtHabilitado.Text = "Estatus: Habilitado"; 
		else
            txtHabilitado.Text = "Estatus: Deshabilitado";

    }


}