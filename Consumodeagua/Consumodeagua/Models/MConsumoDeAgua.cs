using Consumodeagua.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consumodeagua.Models
{
    public class MConsumoDeAgua { 
         public Dictionary<string, MHistorialUA> Historial1 { get; set; }
    
        public Dictionary<string, MUsuario> Usuarios { get; set; }
    }
}
