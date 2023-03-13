using System;
using System.Collections.Generic;
using System.Text;

namespace Consumodeagua.Models
{
    public class MHistorial
    {
        public string Nombre { get; set; }
        public DateTime? Fecha { get; set; }
        public int Flujo { get; set; }
        public bool Estado { get; set; }
    }
}
