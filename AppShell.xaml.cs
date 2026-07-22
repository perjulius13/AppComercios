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
            App.Current.MainPage = new LoginView();

        }


    }
}
