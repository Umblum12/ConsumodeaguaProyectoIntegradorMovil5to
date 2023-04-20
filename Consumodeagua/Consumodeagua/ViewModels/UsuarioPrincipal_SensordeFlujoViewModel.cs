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
    public class UsuarioPrincipal_SensordeFlujoViewModel : BaseViewModel
    {
        public UsuarioPrincipal_SensordeFlujoViewModel()
        {

        }
        #region VARIABLES
        string _Texto;
        string _txtNombrePerfil;
        string _LContadosTXT;
        bool _btnEnableValv;
        bool _bnt_click;
        int _N1;
        string _ImgSFA;
        private Timer _timer;
        private int _intervalo = 5000; // Intervalo de tiempo en milisegundos

        #endregion
        #region CONSTRUCTOR
        public UsuarioPrincipal_SensordeFlujoViewModel(INavigation navigation)
        {
            Navigation = navigation;
            bnt_click = false;
            ImgSFA = "https://imgbb.su/images/2023/02/28/Icono_SensorAgua_Grafica_fondo8936a83e1073933c.png";
            N1 = 127;
            Title = "SensordeFlujo";
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
        public bool btnEnableValv
        {
            get { return _btnEnableValv; }
            set { SetValue(ref _btnEnableValv, value); }
        }
        public bool bnt_click
        {
            get { return _bnt_click; }
            set { SetValue(ref _bnt_click, value); }
        }
        public int N1
        {
            get { return _N1; }
            set { SetValue(ref _N1, value); }
        }
        public string ImgSFA
        {
            get { return _ImgSFA; }
            set { SetValue(ref _ImgSFA, value); }
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
            LContadosTXT = flowValue.ToString();

            if (flowValue <= 0)
            {
                ImgSFA = "https://i.ibb.co/6PbSb8p/Icono-Sensor-Agua-Grafica-fondo.png";
            }
            else if (flowValue >= 0.1 && flowValue <= 0.9)
            {
                ImgSFA = "https://i.ibb.co/cQSGS84/Icono-Sensor-Agua-Grafica-Verde.png";
            }
            else if (flowValue >= 1 && flowValue <= 1.9)
            {
                ImgSFA = "https://i.ibb.co/RbKF2G1/Icono-Sensor-Agua-Grafica-Naranja.png";
            }
            else 
            {
                ImgSFA = "https://i.ibb.co/GsSQ3Vb/Icono-Sensor-Agua-Grafica-Rojo.png";
                await DisplayAlert("Cuidado", "El flujo esta en 2 o superor", "Ok");
            }
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