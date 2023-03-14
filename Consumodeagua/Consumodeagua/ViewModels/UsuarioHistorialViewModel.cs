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
    public class UsuarioHistorialViewModel : BaseViewModel
    {
        public UsuarioHistorialViewModel()
        {
        }

        #region VARIABLES
        string _Texto;
        string _Nombre;
        DateTime _datefecha;
        int _Flujo;
        bool _Estado;
        ObservableCollection<MHistorial> _ListaHistorial;
        #endregion
        #region CONSTRUCTOR
        public UsuarioHistorialViewModel(INavigation navigation)
        {
            Navigation = navigation;
            Title = "Historial";
            MostrarHistorial();
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
        public ObservableCollection<MHistorial> ListaHistorial
        {
            get { return _ListaHistorial; }
            set
            {
                SetValue(ref _ListaHistorial, value);
                OnpropertyChanged();
            }
        }
        #endregion
        #region PROCESOS
        public async Task InsertarHisto()
        {
            var funcion = new DHistorial();
            var parametros = new MHistorial();
                parametros.Nombre = "Abelardo";
                parametros.Fecha = datefecha;
                parametros.Flujo = 399;
                parametros.Estado = true;
                await funcion.InsertarHistorial(parametros);
        }
        public async Task MostrarHistorial()
        {
            var funcion = new DHistorial();
            ListaHistorial = await funcion.MostrarHistoriales();
        }
        private async Task OnPerfilClicked()
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(Perfil)}");
        }
        #endregion
        #region COMANDOS
        public ICommand Perfilcomand => new Command(async () => await OnPerfilClicked());
        public ICommand InsertarHistocomand => new Command(async () => await InsertarHisto());
        #endregion
    }
}