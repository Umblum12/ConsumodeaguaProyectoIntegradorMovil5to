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
using Consumodeagua.Services;

namespace Consumodeagua.ViewModels
{
    public class UsuarioHistorialViewModel : BaseViewModel
    {
        public UsuarioHistorialViewModel()
        {
        }

        #region VARIABLES
        string _Texto;
        DateTime _datefecha;
        ObservableCollection<MHistorialUA> _ListaHistoriales;
        #endregion
        #region CONSTRUCTOR
        public UsuarioHistorialViewModel(INavigation navigation)
        {
            Navigation = navigation;
            Title = "Historial";
            MostrarHistorialUsuarioActualUid();
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
        public ObservableCollection<MHistorialUA> ListaHistoriales
        {
            get { return _ListaHistoriales; }
            set
            {
                SetValue(ref _ListaHistoriales, value);
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
            parametros.id = 6;
            parametros.uid = "M0SkZDEVnGT67uYLxWw56w8HXp13";
            await funcion.InsertarRegHistorial(parametros);
        }
        public async Task MostrarHistorialUsuarioActualUid()
        {
            var funcion = new DHistorial();
            ListaHistoriales = await funcion.ObtenerHistorial();
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
        #endregion

    }
}