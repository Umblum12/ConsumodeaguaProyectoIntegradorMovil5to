using Consumodeagua.Conexion;
using Consumodeagua.Models;
using Consumodeagua.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Consumodeagua.Data
{
    public class DSensorFlujo
    {
        //Peticiones a la API Json
        Cconexion conexion = new Cconexion();
        // Para realizar una solicitud GET
        public async Task<double> GetFlowValueAsync()
        {
            var response = await conexion.GetAsync("Consumodeagua/SensordeFlujo/1.json");
            var json = response.ToString();
            // Leer la respuesta y deserializarla a un objeto ConsumoDeAgua
            var sensorDeFlujo = JsonConvert.DeserializeObject<MFlujo>(json);
            double flow = sensorDeFlujo.flujo;
            return flow;
        }
    }
}