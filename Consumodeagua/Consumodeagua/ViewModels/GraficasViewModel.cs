using Consumodeagua.Data;
using Consumodeagua.Models;
using Consumodeagua.Services;
using Consumodeagua.Views;
using Consumodeagua.VistaModelo;
using System;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Consumodeagua.ViewModels
{
    public class GraficasViewModel : BaseViewModel
    {
        public GraficasViewModel()
        {

        }
        #region VARIABLES
        string _Texto;
        string _txtNombrePerfil;
        string _LContadosTXT;
        private Timer _timer;
        private int _intervalo = 5000; // Intervalo de tiempo en milisegundos

        #endregion
        #region CONSTRUCTOR
        public GraficasViewModel(INavigation navigation)
        {
            Navigation = navigation;
            Title = "Graficas";
            StartTimer(); // Iniciar el temporizador
        }
        #endregion
        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        public string txtNombrePerfil
        {
            get { return _txtNombrePerfil; }
            set { SetValue(ref _txtNombrePerfil, value); }
        }
        public string LContadosTXT
        {
            get { return _LContadosTXT; }
            set { SetValue(ref _LContadosTXT, value); }
        }
        #endregion
        #region PROCESOS
        private void StartTimer()
        {

            _timer = new Timer(_intervalo);
            _timer.Elapsed += async (sender, e) => await MostrarFlujoAgua(); // Cada vez que el temporizador se ejecuta, actualizar el valor del sensor
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }
        public async Task MostrarFlujoAgua()
        {
            var funcion = new DSensorFlujo();
            var flowValue = await funcion.GetFlowValueAsync();
            LContadosTXT = flowValue.ToString() + " Litros";
        }
        public async Task OnPerfilClicked()
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(Perfil)}");
        }
        #endregion
        #region COMANDOS
        public ICommand Perfilcomand => new Command(async () => await OnPerfilClicked());
        #endregion
    }
}