using AppComercios.Modelos;
using System.Collections.ObjectModel;

namespace AppComercios.Vistas;

public partial class HistorialPagView : ContentPage
{


    public ObservableCollection<HistorialPagos> pagos { get; set; }


    public HistorialPagView()
	{
		InitializeComponent();

        pagos = new ObservableCollection<HistorialPagos>
        {
            new HistorialPagos
            {
                Id = "1",
                Cantidad = "200",
                FechaPag = "01/07/2026",
                Plaza = "3"
            },

            new HistorialPagos
            {
                Id = "2",
                Cantidad = "200",
                FechaPag = "07/07/2026",
                Plaza = "3"
            },


            new HistorialPagos
            {
                Id = "3",
                Cantidad = "200",
                FechaPag = "13/07/2026",
                Plaza = "3"
            },


        };


        BindingContext = this; 


    }




}