using System;
using System.Collections.Generic;
using System.Text;
using Consumodeagua.Models;
using Consumodeagua.Conexion;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

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

        //Peticiones a la API Json
        Cconexion conexion = new Cconexion();
        // Para realizar una solicitud POST y registrar usuario
        public async Task InsertarRegHistorial(MUser parametros)
        {
            MUser Insert = new MUser
            {
                email = parametros.email,
                password = parametros.password,
                returnSecureToken = parametros.returnSecureToken
            };
            var json = JsonConvert.SerializeObject(Insert);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await conexion.PostAsync1("v1/accounts:signUp?key=AIzaSyAtKvrBOrIfasAvix3UxYta7CiMlvTDJWg", content);
            var result = response.ToString();
        }
    }
}
