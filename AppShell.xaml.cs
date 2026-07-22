using AppComercios.Vistas;

namespace AppComercios
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }






        private async void Button_Clicked(object sender, EventArgs e)
        {
            
            Preferences.Remove("iduser");
            Preferences.Remove("saldouser");
            Preferences.Remove("nombreuser");            

            App.Current.MainPage = new LoginView();

        }


    }
}
