using Consumodeagua.Views;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Consumodeagua.Models;
using Consumodeagua.Data;
using System.Collections.Generic;

namespace Consumodeagua.ViewModels
{
    public class UsuarioHistorialViewModel : BaseViewModel
    {
        public UsuarioHistorialViewModel()
        {
        }

        #region VARIABLES
        string _Texto;
        string _TxtIDUsuario;
        string _TxtNombre;
        DateTime _DatFecha;
        int _TxtFlujo;
        bool _TxtEstado;
        List<MHistorial> _ListaHistorial;
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
        public string TxtIDUsuario
        {
            get { return _TxtIDUsuario; }
            set { SetProperty(ref _TxtIDUsuario, value); }
        }
        public string TxtNombre
        {
            get { return _TxtNombre; }
            set { SetProperty(ref _TxtNombre, value); }
        }
        public DateTime DatFecha
        {
            get { return _DatFecha; }
            set { SetProperty(ref _DatFecha, value); }
        }
        public int TxtFlujo
        {
            get { return _TxtFlujo; }
            set { SetProperty(ref _TxtFlujo, value); }
        }
        public bool TxtEstado
        {
            get { return _TxtEstado; }
            set { SetProperty(ref _TxtEstado, value); }
        }
        public List<MHistorial> ListaHistorial
        {
            get { return _ListaHistorial; }
            set { SetProperty(ref _ListaHistorial, value); }
        }
        #endregion
        #region PROCESOS
        public async Task InsertarHisto()
        {
            var funcion = new DHistorial();
            var parametros = new MHistorial();

                parametros.Nombre = "Abelardo";
                parametros.Fecha = DatFecha;
                parametros.Flujo = 399;
                parametros.Estado = true;

                await funcion.InsertarHistorial(parametros);
        }

        public async Task MostrarHistorial()
        {
            var funcion = new DHistorial();
            ListaHistorial=await funcion.MostrarHistorial();
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