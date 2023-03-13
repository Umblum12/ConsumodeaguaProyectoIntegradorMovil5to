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

        public async Task<List<MHistorial>> MostrarHistorial()
        {
            return (await Cconexion.firebase
                .Child("Historial")
                .OnceAsync<MHistorial>())
                .Select(item => new MHistorial
                 {
                    Nombre = item.Object.Nombre,
                    Fecha = item.Object.Fecha,
                    Flujo = item.Object.Flujo,
                    Estado = item.Object.Estado
                 }).ToList();
        }

    }
}