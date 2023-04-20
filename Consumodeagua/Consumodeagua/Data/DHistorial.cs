using System;
using System.Collections.Generic;
using System.Text;
using Consumodeagua.Conexion;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Firebase.Database;
using Newtonsoft.Json;
using System.Net.Http;
using Consumodeagua.Models;
using Newtonsoft.Json.Linq;

namespace Consumodeagua.Data
{
    public class DHistorial
    {
        //Peticiones a la API Json
        Cconexion conexion = new Cconexion();
        // Para realizar una solicitud GET
        public async Task<ObservableCollection<MHistorialUA>> ObtenerHistorial()
        {
                var response = await conexion.GetAsync("Consumodeagua.json");
                var json = response.ToString();
                // Leer la respuesta y deserializarla a un objeto ConsumoDeAgua
                var consumoDeAgua = JsonConvert.DeserializeObject<MConsumoDeAgua>(json);
                var items = new ObservableCollection<MHistorialUA>();
                foreach (var item in consumoDeAgua.Historial1.Values)
                {
                    items.Add(item);
                }
                return items;
            }

            //public async Task<ObservableCollection<MHistorial>> MostrarRegistros()
            //{
            //    var response = await conexion.GetAsync("Consumodeagua.json");
            //    var json = response.ToString();
            //    var consumoDeAgua = JsonConvert.DeserializeObject<MConsumoDeAgua>(json);

            //    var items = new ObservableCollection<MHistorial>();

            //    foreach (var item in consumoDeAgua.Historial.Values)
            //    {
            //            items.Add(item);
            //    }
            //    return items;
            //}
            //public async Task<ObservableCollection<MHistorialUA>> MostrarRegistros()
            //{
            //    var response = await conexion.GetAsync("Consumodeagua.json");
            //    var json = response.ToString();
            //    var consumoDeAgua = JsonConvert.DeserializeObject<MConsumoDeAgua>(json);

            //    var items = new ObservableCollection<MHistorialUA>();

            //    foreach (var historial in consumoDeAgua.Historial.Values)
            //    {
            //        foreach (var item in historial.HistorialUA.Values)
            //        {
            //            items.Add(item);
            //        }
            //    }
            //    return items;
            //}


            //public async Task<ObservableCollection<MHistorialUA>> MostrarRegHistorial(string uid)
            //{
            //    var endpoint = $"Consumodeagua/Historial.json";
            //    var response = await conexion.GetAsync(endpoint);
            //    var json = response.ToString();
            //    // Leer la respuesta y deserializarla a un objeto ConsumoDeAgua
            //    var historiales = JsonConvert.DeserializeObject<MHistorial>(json);
            //    var items = new ObservableCollection<MHistorialUA>();
            //    foreach (var item in historiales.HistorialUA.Values)
            //    {
            //        items.Add(item);
            //    }
            //    return items;
            //}
            // Para realizar una solicitud POST
            public async Task InsertarRegHistorial(MHistorialUA parametros)
        {
            MHistorialUA Insert = new MHistorialUA
            {
                Nombre = parametros.Nombre,
                Fecha = parametros.Fecha,
                Flujo = parametros.Flujo,
                Estado = parametros.Estado,
                id = parametros.id,
                uid = parametros.uid
            };
            var json = JsonConvert.SerializeObject(Insert);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await conexion.PostAsync($"Consumodeagua/Historial.json", content);
            var result = response.ToString();
        }
        // Para realizar una solicitud DELETE
        public async Task<string> DeleteRegHistorial(string key)
        {
            return await conexion.DeleteAsync($"Consumodeagua/Historial/{key}.json");
        }
    }
}