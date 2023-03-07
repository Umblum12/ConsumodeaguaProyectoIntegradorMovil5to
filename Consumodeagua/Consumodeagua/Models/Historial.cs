using System;

namespace Consumodeagua.Models
{
    public class Historial
    {
        public int IdHistoiral { get; set; }
        public int IDUsuario { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public int Flujo { get; set; }
        public bool Estado { get; set; }
    }
}
