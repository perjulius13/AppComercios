using AppComercios.Modelos;
using AppComercios.Servicios;

namespace AppComercios.Vistas;

public partial class CalendarioView : ContentPage
{


    List<AsignacionPlazaClass> lista = new();

    List<AsigPlazaAuxClass> listachida = new();



    public CalendarioView()
	{
		InitializeComponent();
       
	}



    AsigPlazaAuxClass a = new AsigPlazaAuxClass(); 
    protected override async void OnAppearing()
    {
        actividad.IsEnabled = true;
        actividad.IsVisible = true;

        listachida.Clear(); 

        var servicio = new ApiService();
        var items = await servicio.CalendarioPuestos(1);
        lista = items.ToList();

        foreach (var item in lista)
        {
            a = new AsigPlazaAuxClass();
            a.Pagado = item.Pagado;
            a.FechaAsig = item.FechaAsig;
            a.FechaRegistro = item.FechaRegistro;
            a.NumeroPlaza = item.NumeroPlaza;
            a.IduserReg = item.IduserReg;
            a.Id = item.Id;

            a.EstatusPago = item.Pagado ? "Pagado" : "Pago Pendiente"; 

            listachida.Add(a); 
        }

        lstcalendario.ItemsSource = listachida;
        actividad.IsEnabled = false;
        actividad.IsVisible = false; 
    }

    int idasig = 0; 

    public async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        //string previous = (e.PreviousSelection.FirstOrDefault() as AsingacionPlazaClass)?.NombrePuesto;
        //string current = (e.CurrentSelection.FirstOrDefault() as AsingacionPlazaClass)?.NombrePuesto;

        idasig =(int)(e.CurrentSelection.FirstOrDefault() as AsignacionPlazaClass)?.Id; 
        await Navigation.PushAsync(new RealizarPago(idasig));
       

    }



}