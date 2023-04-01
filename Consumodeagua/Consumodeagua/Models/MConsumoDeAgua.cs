using System;
using System.Collections.Generic;
using System.Text;

namespace Consumodeagua.Models
{
    internal class MConsumoDeAgua
    {
        public Dictionary<string, MHistorial> Historial { get; set; }
        public Dictionary<string, MUsuario> Usuarios { get; set; }
    }
}
