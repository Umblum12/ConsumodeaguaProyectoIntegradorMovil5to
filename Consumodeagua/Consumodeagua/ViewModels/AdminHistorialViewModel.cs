using Consumodeagua.Views;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Consumodeagua.Models;
using Consumodeagua.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Consumodeagua.VistaModelo;

namespace Consumodeagua.ViewModels
{
    public class AdminHistorialViewModel : BaseViewModel
    {
        public AdminHistorialViewModel()
        {
        }
        #region VARIABLES
        string _Texto;
        DateTime _datefecha;
        ObservableCollection<MUsuario> _ListaUsuarios;
        #endregion
        #region CONSTRUCTOR
        public AdminHistorialViewModel(INavigation navigation)
        {
            Navigation = navigation;
            Title = "Historial";
            MostrarLosUsuarios();
        }
        #endregion
        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set { SetProperty(ref _Texto, value); }
        }
        public DateTime datefecha
        {
            get { return _datefecha; }
            set { SetValue(ref _datefecha, value); }
        }
        public ObservableCollection<MUsuario> ListaUsuarios
        {
            get { return _ListaUsuarios; }
            set
            {
                SetValue(ref _ListaUsuarios, value);
                OnpropertyChanged();
            }
        }
        #endregion
        #region PROCESOS
        public async Task InsertarRegHisto()
        {
            var funcion = new DHistorial();
            var parametros = new MHistorial();
            parametros.Nombre = "Abelardo";
            parametros.Fecha = datefecha;
            parametros.Flujo = 399;
            parametros.Estado = true;
            await funcion.InsertarRegHistorial(parametros);
        }
        public async Task MostrarLosUsuarios()
        {
            var funcion = new DUsuario();
            ListaUsuarios = await funcion.MostrarRegUsuarios();
        }
        public async Task EliminarRegHisto()
        {
            bool respuesta = await DisplayAlert("Confirmación", "¿Estás seguro de que deseas continuar?", "Acceptar", "Cancelar");

            if (respuesta)
            {
                // El usuario seleccionó "Sí"
                var funcion = new DHistorial();
                var key = "NQwxjxP4DXL4uto70hk"; // la clave del registro que desea eliminar
                var result = await funcion.DeleteRegHistorial(key);
                await DisplayAlert("Acceptado", "Registro eliminado", "Ok");
            }
            else
            {
                // El usuario seleccionó "No"
                await DisplayAlert("Cancelado", "Registro no eliminado", "Ok");
            }
        }
        private async Task OnPerfilClicked()
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(Perfil)}");
        }
        #endregion
        #region COMANDOS
        public ICommand Perfilcomand => new Command(async () => await OnPerfilClicked());
        public ICommand InsertarRegHistocomand => new Command(async () => await InsertarRegHisto());
        public ICommand EliminarRegHistocomand => new Command(async () => await EliminarRegHisto());
        #endregion

    }
}