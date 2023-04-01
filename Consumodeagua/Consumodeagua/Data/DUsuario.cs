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
using Consumodeagua.Services;
using Firebase.Auth;
using System.Collections.ObjectModel;

namespace Consumodeagua.Data
{
    public class DUsuario
    {
        //Peticiones a la API Json
        Cconexion conexion = new Cconexion();
        //Peticiones a los servicios firebase
        UserService userservices = new UserService();
        // Para realizar una solicitud GET
        public async Task<ObservableCollection<MUsuario>> MostrarRegUsuarios()
        {
            var response = await conexion.GetAsync("Consumodeagua.json");
            var json = response.ToString();
            // Leer la respuesta y deserializarla a un objeto ConsumoDeAgua
            var consumoDeAgua = JsonConvert.DeserializeObject<MConsumoDeAgua>(json);
            var items = new ObservableCollection<MUsuario>();
            foreach (var item in consumoDeAgua.Usuarios.Values)
            {
                items.Add(item);
            }
            return items;
        }
        // Para realizar una solicitud POST y registrar usuario
        public async Task InsertarRegUsuario(MUsuario parametros)
        {
            try
            {
                // Creamos el usuario en Firebase Authentication
                var RegisterAuth = await userservices.RegisterAsync(parametros.CorreoElectronico, parametros.Contrasena);
                // Aquí puedes guardar el ID del usuario generado por Firebase Authentication
                var firebaseUserId = RegisterAuth.Uid;
                // Creamos la entrada del usuario en la base de datos de usuarios
                MUsuario datos = new MUsuario
                {
                    Nombre = parametros.Nombre,
                    ApellidoPaterno = parametros.ApellidoPaterno,
                    ApellidoMaterno = parametros.ApellidoMaterno,
                    Direccion = parametros.Direccion,
                    CorreoElectronico = parametros.CorreoElectronico,
                    FechaNacimiento = parametros.FechaNacimiento,
                    Contrasena = parametros.Contrasena,
                    rol = parametros.rol,
                    UID = firebaseUserId  // Asignamos el UID generado por Firebase Authentication
                };
                var json = JsonConvert.SerializeObject(datos);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await conexion.PostAsync("Consumodeagua/Usuarios.json", content);
                var data = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(response);
                var firebaseKey = data.Keys.FirstOrDefault();
                var result = response.ToString();
            }
            catch (FirebaseAuthException ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Al registrar usuario en Firebase Authentication:" + ex.Message, "OK");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Al insertar registro de usuario:" + ex.Message, "OK");
            }
        }
    }
}
