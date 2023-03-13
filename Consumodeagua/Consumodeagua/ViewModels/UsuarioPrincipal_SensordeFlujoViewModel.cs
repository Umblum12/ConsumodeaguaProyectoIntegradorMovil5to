using Consumodeagua.Views;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Consumodeagua.ViewModels
{
    public class UsuarioPrincipal_SensordeFlujoViewModel : BaseViewModel
    {
        public UsuarioPrincipal_SensordeFlujoViewModel()
        {
            
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        #region VARIABLES
        string _Texto;
        string _LContadosTXT;
        bool _btnEnableValv;
        bool _bnt_click;
        int _N1;
        string _ImgSFA;
        public ICommand OpenWebCommand { get; }

        #endregion
        #region CONSTRUCTOR
        public UsuarioPrincipal_SensordeFlujoViewModel(INavigation navigation)
        {
            Navigation = navigation;
            bnt_click = false;
            ImgSFA = "https://imgbb.su/images/2023/02/28/Icono_SensorAgua_Grafica_fondo8936a83e1073933c.png";
            N1 = 127;
            LContadosTXT = "0";
            Title = "SensordeFlujo";
        }
        #endregion
        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set { SetProperty(ref _Texto, value); }
        }
        public string LContadosTXT
        {
            get { return _LContadosTXT; }
            set { SetProperty(ref _LContadosTXT, value); }
        }
        public bool btnEnableValv
        {
            get { return _btnEnableValv; }
            set { SetProperty(ref _btnEnableValv, value); }
        }
        public bool bnt_click
        {
            get { return _bnt_click; }
            set { SetProperty(ref _bnt_click, value); }
        }
        public int N1
        {
            get { return _N1; }
            set { SetProperty(ref _N1, value); }
        }
        public string ImgSFA
        {
            get { return _ImgSFA; }
            set { SetProperty(ref _ImgSFA, value); }
        }
        #endregion
        #region PROCESOS
        public void SimularFlujoAgua()
        {
            if (N1 == 127)
            {
                N1 = 254;
                ImgSFA = "https://imgbb.su/images/2023/02/28/Icono_SensorAgua_Grafica_Verde0d0c4b0d569ebd4e.png";
                LContadosTXT = "127";
            }
            else if (N1 == 254)
            {
                N1 = 381;
                ImgSFA = "https://imgbb.su/images/2023/02/28/Icono_SensorAgua_Grafica_Naranja3f5f06680bbf003a.png";
                LContadosTXT = "254";
            }
            else if (N1 == 381)
            {
                N1 = 0;
                ImgSFA = "https://imgbb.su/images/2023/02/28/Icono_SensorAgua_Grafica_Rojo539dc19d96028df7.png";
                DisplayAlert("Cuidado", "El flujo esta en 381", "Ok");
                LContadosTXT = "381";
            }
            else if (N1 == 0)
            {
                N1 = 127;
                ImgSFA = "https://imgbb.su/images/2023/02/28/Icono_SensorAgua_Grafica_fondo8936a83e1073933c.png";
                LContadosTXT = "0";
            }
        }
        private async Task OnPerfilClicked()
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(Perfil)}");
        }
        #endregion
        #region COMANDOS
        public ICommand SimularFlujoAguacomand => new Command(SimularFlujoAgua);
        public ICommand Perfilcomand => new Command(async () => await OnPerfilClicked());
        #endregion
    }
}