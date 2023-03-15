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
            return data;
        }

    }
}