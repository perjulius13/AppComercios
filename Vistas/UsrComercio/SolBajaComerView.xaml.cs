using AppComercios.Modelos;
using AppComercios.Servicios;

namespace AppComercios.Vistas.UsrComercio;

public partial class SolBajaComerView : ContentPage
{
	public SolBajaComerView()
	{
		InitializeComponent();
	}

	int idusuario = 0;
    string nombrecomer = ""; 
	List<PropietarioComerAuxClass> lista = new();
    SolbajacomerClass sol = new(); 
    int idcomercio = 0; 


    protected override async void OnAppearing()
    {
        var servicio = new ServiciosComercio();
        idusuario = Preferences.Get("iduser", 0);

        lista = await servicio.ListarComerciosPropietario(idusuario);

        foreach (var item in lista)
        {
            combocomercios.Items.Add(item.NombreComer);
        }
    }

   
    private async void Button_Clicked(object sender, EventArgs e)
    {
        var servicio = new ServiciosComercio();


        bool isConfirmed = await DisplayAlertAsync(
"Solicitud de Baja",
"¿ Estas seguro de que los datos son correctos ?",
"Si",
"No"
);

        if(isConfirmed)
        {
            nombrecomer = combocomercios.SelectedItem.ToString();
            idcomercio = lista.Where(a => a.NombreComer == nombrecomer).FirstOrDefault().Idcomercio;
            sol.Idcomercio = idcomercio;
            sol.Motivo = txtmotivo.Text;

            await servicio.RegistrarSolBaja(sol);

            await Navigation.PopAsync(); 

        }   

               
    }




}