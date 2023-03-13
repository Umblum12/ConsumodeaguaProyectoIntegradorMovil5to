using System;
using System.Collections.Generic;
using System.Text;

namespace Consumodeagua.Models
{
    public class MUsuario
    {
        public string Nombre { get; set; }
        public string ApellidoPaterno{ get; set; }
        public string ApellidoMaterno { get; set; }
        public string Direccion { get; set; }
        public string CorreoElectronico { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Contrasena { get; set; }
    }
}
