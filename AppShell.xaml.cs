using AppComercios.Vistas;
using AppComercios.Vistas.UsrComercio;

namespace AppComercios
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            idtipouser = Preferences.Get("tipouser", 0); 


            switch(idtipouser)
            {
                case 4:
                    MenuVisitador();
                    break;

                case 5:
                    MenuComerciante(); 
                    break; 
            }


            generales(); 

        }

    
        int idtipouser = 0; 

  


        private async void Button_Clicked(object sender, EventArgs e)
        {
            
            Preferences.Remove("iduser");
            Preferences.Remove("saldouser");
            Preferences.Remove("nombreuser");
            Preferences.Remove("tipouser");

            App.Current.MainPage = new LoginView();

        }



        public void MenuVisitador()
        {
            menutabs.Items.Add(new ShellContent
            {
                Title = "Home",
                Icon = "hogar.png",
                ContentTemplate = new DataTemplate(typeof(HogarView)),                
            });

            menutabs.Items.Add(new ShellContent
            {
                Title = "Mapa",
                Icon = "mapa.png",
                ContentTemplate = new DataTemplate(typeof(MapaComercios))
            });

            menutabs.Items.Add(new ShellContent
            {
                Title = "Visitas",
                Icon = "lista.png",
                ContentTemplate = new DataTemplate(typeof(VisitasView))
            });

            menutabs.Items.Add(new ShellContent
            {
                Title = "Registar Comercio",
                Icon = "plaza.png",
                ContentTemplate = new DataTemplate(typeof(RegistrarComercio))
            });
            //plaza
        }




        public void generales()
        {
            this.Items.Add(
                new ShellContent
            {
                Title = "Mi Perfil",
                Icon = "profile.png",
                ContentTemplate = new DataTemplate(typeof(PerfilView))
            });

            this.Items.Add(
              new ShellContent
              {
                  Title = "Ayuda",
                  Icon = "informacion.png",
                  ContentTemplate = new DataTemplate(typeof(PerfilView))
              });

        }




        public void MenuComerciante ()
        {

            menutabs.Items.Add(new ShellContent
            {
                Title = "Home",
                Icon = "hogar.png",
                ContentTemplate = new DataTemplate(typeof(HomeComercioView)),
            });

            menutabs.Items.Add(new ShellContent
            {
                Title = "Mi Comercio",
                Icon = "plaza.png",
                ContentTemplate = new DataTemplate(typeof(MiComercioView)),
            });

            menutabs.Items.Add(new ShellContent
            {
                Title = "Mis Pagos",
                Icon = "lista.png",
                ContentTemplate = new DataTemplate(typeof(PagosListComerView)),
            });


        }



    }
}
