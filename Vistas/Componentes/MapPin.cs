using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace AppComercios.Vistas.Componentes
{
    public class MapPin
    {
        public string Id { get; set; }
        public Location Position { get; set; }
        public string IconSrc { get; set; }
        public ICommand ClickedCommand { get; set; }

        public MapPin(Action<MapPin> clicked)
        {
            ClickedCommand = new Command(() => clicked(this));
        }

    }
}
