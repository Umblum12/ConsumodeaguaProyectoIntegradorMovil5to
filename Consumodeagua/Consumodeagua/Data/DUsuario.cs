using System;
using System.Collections.Generic;
using System.Text;
using Consumodeagua.Models;
using Consumodeagua.Conexion;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;

namespace Consumodeagua.Data
{
    public class DUsuario
    {
        public async Task InsertarUsuario(MUsuario parametros)
        {
            await Cconexion.firebase
                .Child("Usuario")
                .PostAsync(new MUsuario()
                {
                    Nombre = parametros.Nombre,
                    ApellidoPaterno = parametros.ApellidoPaterno,
                    ApellidoMaterno = parametros.ApellidoMaterno,
                    Direccion = parametros.Direccion,
                    CorreoElectronico = parametros.CorreoElectronico,
                    FechaNacimiento = parametros.FechaNacimiento,
                    Contrasena = parametros.Contrasena
                });
        }
    }
}
