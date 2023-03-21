using System;
using System.Collections.Generic;
using System.Text;
using Consumodeagua.Models;
using Consumodeagua.Conexion;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Firebase.Database;
using Newtonsoft.Json;
using System.Net.Http;

namespace Consumodeagua.Data
{
    public class DHistorial
    {
        public async Task InsertarHistorial(MHistorial parametros)
        {
            await Cconexion.firebase
                .Child("Historial")
                .PostAsync(new MHistorial()
                {
                    Nombre = parametros.Nombre,
                    Fecha = parametros.Fecha,
                    Flujo = parametros.Flujo,
                    Estado = parametros.Estado
                });
        }

        public async Task<ObservableCollection<MHistorial>> MostrarHistoriale()
        {
            var data = await Task.Run(() => Cconexion.firebase
                .Child("Historial")
                .AsObservable<MHistorial>()
                .AsObservableCollection());
            return data;
        }


        //Peticiones a la API Json
        Cconexion conexion = new Cconexion();
        // Para realizar una solicitud GET
        public async Task<ObservableCollection<MHistorial>> MostrarHistoriales()
        {
            var response = await conexion.GetAsync("Consumodeagua.json");
            var json = response.ToString();
            // Leer la respuesta y deserializarla a un objeto ConsumoDeAgua
            var consumoDeAgua = JsonConvert.DeserializeObject<MConsumoDeAgua>(json);
            var items = new ObservableCollection<MHistorial>();
            foreach (var item in consumoDeAgua.Historial.Values)
            {
                items.Add(item);
            }
            return items;

        }
        // Para realizar una solicitud POST
        public async Task InsertarHistoriale(MHistorial parametros)
        {
            MHistorial Insert = new MHistorial
            {
                Nombre = parametros.Nombre,
                Fecha = parametros.Fecha,
                Flujo = parametros.Flujo,
                Estado = parametros.Estado
            };
            var json = JsonConvert.SerializeObject(Insert);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await conexion.PostAsync("Consumodeagua/Historial.json", content);
            var result = response.ToString();
        }
        // Para realizar una solicitud DELETE
        public async Task<string> DeleteHistorialAsync(string key)
        {
            return await conexion.DeleteAsync($"Consumodeagua/Historial/{key}.json");
        }


    }
}