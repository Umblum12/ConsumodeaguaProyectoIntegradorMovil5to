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
using Firebase.Auth;
using System.Linq;
using Consumodeagua.Services;
using Rg.Plugins.Popup.Services;

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
            var parametros = new MHistorialUA();
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
        public async Task EliminarRegHisto(string userId)
        {
            var funcion = new DUsuario();
            bool respuesta = await DisplayAlert("Confirmación", "¿Estás seguro de que deseas continuar?", "Acceptar", "Cancelar");

            if (respuesta)
            {
                var userToDelete = ListaUsuarios.FirstOrDefault(n => n.UID == userId);
                if (userToDelete != null)
                {
                    // Aquí va el código para eliminar el usuario usando Firebase
                    bool deleted = await funcion.EliminarRegUsuario(userToDelete.UID);
                    if (deleted)
                    {
                        ListaUsuarios.Remove(userToDelete);
                    }
                }
                await DisplayAlert("Acceptado", "Registro eliminado", "Ok");
            }
            else
            {
                // El usuario seleccionó "No"
                await DisplayAlert("Cancelado", "Registro no eliminado", "Ok");
            }
        }
        public async Task EditarRegHisto(string userId)
        {
            await PopupNavigation.Instance.PushAsync(new PopupEditar());
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
        public ICommand EliminarRegHistocomand => new Command<string>(async (userId) => await EliminarRegHisto(userId));
        public ICommand EditarRegHistocomand => new Command<string>(async (userId) => await EditarRegHisto(userId));
        #endregion

    }
}