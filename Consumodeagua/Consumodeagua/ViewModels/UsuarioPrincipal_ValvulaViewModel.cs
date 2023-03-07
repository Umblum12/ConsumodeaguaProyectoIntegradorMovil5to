using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Consumodeagua.ViewModels
{
    public class UsuarioPrincipal_ValvulaViewModel : BaseViewModel
    {
        public UsuarioPrincipal_ValvulaViewModel()
        {
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }
        public ICommand OpenWebCommand { get; }

        #region VARIABLES
    string _Texto;
        string _ImgValvula;
        bool _btnEnableValv;
        bool _bnt_click;
        string _btn_AbrirCerrarColor;
        string _btn_AbrirCerrarTXT;
        #endregion
        #region CONSTRUCTOR
        public UsuarioPrincipal_ValvulaViewModel(INavigation navigation)
        {
            Navigation = navigation;
            bnt_click = false;
            ImgValvula = "https://i.ibb.co/1RG6MSS/Icono-Valvula-Agua.png";
            btn_AbrirCerrarColor = "Green";
            btn_AbrirCerrarTXT = "Abierto";
            Title = "Válvula";
        }
        #endregion
        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set { SetProperty(ref _Texto, value); }
        }
        public string ImgValvula
        {
            get { return _ImgValvula; }
            set { SetProperty(ref _ImgValvula, value); }
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
        public string btn_AbrirCerrarColor
        {
            get { return _btn_AbrirCerrarColor; }
            set { SetProperty(ref _btn_AbrirCerrarColor, value); }
        }
        public string btn_AbrirCerrarTXT
        {
            get { return _btn_AbrirCerrarTXT; }
            set { SetProperty(ref _btn_AbrirCerrarTXT, value); }
        }
        #endregion
        #region PROCESOS
        public void btn_Abrir_Cerrar()
        {
            if (bnt_click == false)
            {
                bnt_click = true;
                ImgValvula = "https://imgbb.su/images/2023/02/27/Icono_ValvulaAgua_Cerrada3912fd1fb4609f9b.png";
                btn_AbrirCerrarColor = "Red";
                btn_AbrirCerrarTXT = "Cerrado";
            }
            else
            {
                bnt_click = false;
                ImgValvula = "https://i.ibb.co/1RG6MSS/Icono-Valvula-Agua.png";
                btn_AbrirCerrarColor = "Green";
                btn_AbrirCerrarTXT = "Abierto";
            }
        }
        public async Task Perfil()
        {
            
        }
        #endregion
        #region COMANDOS
        public ICommand Perfilcomand => new Command(async () => await Perfil());
        public ICommand btn_Abrir_Cerrarcomand => new Command(btn_Abrir_Cerrar);
        #endregion
    }
}