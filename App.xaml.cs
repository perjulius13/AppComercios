using AppComercios.Vistas;
using Microsoft.Extensions.DependencyInjection;

namespace AppComercios
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            if (Preferences.Get("iduser", 0) == 0)
            {
                return new Window(new LoginView());
            }
            else
            {
                return new Window(new AppShell());
            }
            
        }





    }
}