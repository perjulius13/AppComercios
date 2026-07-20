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
            return new Window(new LoginView());
        }





    }
}