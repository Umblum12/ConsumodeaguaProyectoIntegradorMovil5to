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
using System.Diagnostics;

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

        public async Task<ObservableCollection<MHistorial>> MostrarHistoriales()
        {
            var data = await Task.Run(() => Cconexion.firebase
                .Child("Historial")
                .AsObservable<MHistorial>()
                .AsObservableCollection());

            Debug.WriteLine(data.ToList());

            foreach(MHistorial item in data) 
            {
                Debug.WriteLine($"PONME ATENCION WE {item.Nombre} {item.Estado} {item.Flujo} {item.Fecha}");
            }
            return data;
        }

    }
}