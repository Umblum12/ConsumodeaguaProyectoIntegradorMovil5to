using Consumodeagua.Conexion;
using Consumodeagua.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Consumodeagua.Data
{
    public class DValvula
    {
        //Peticiones a la API Json
        Cconexion conexion = new Cconexion();
        // Para realizar una solicitud GET
        public async Task<bool> GetYPutEstadoValueAsync(bool nuevoEstado)
        {
            // Obtener el estado actual del JSON
            var response = await conexion.GetAsync("Consumodeagua/Valvula.json");
            var json = response.ToString();
            // Leer la respuesta y deserializarla a un objeto MEstado
            var data = JsonConvert.DeserializeObject<MEstado>(json);
            bool estadoActual = data.Estado;

            // Cambiar el estado
            data.Estado = nuevoEstado;

            // Enviar la solicitud PUT con el nuevo estado
            var jsonContent = JsonConvert.SerializeObject(data);
            StringContent stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            await conexion.PutAsync("Consumodeagua/Valvula.json", stringContent);

            // Devolver el nuevo estado
            return nuevoEstado;
        }
    }
}