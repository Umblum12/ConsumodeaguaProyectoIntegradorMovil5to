using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Consumodeagua.ViewModels
{
    public class UsuarioManualViewModel : BaseViewModel
    {
        public UsuarioManualViewModel()
        {
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }

        #region VARIABLES
        string _Texto;
        #endregion
        #region CONSTRUCTOR
        public UsuarioManualViewModel(INavigation navigation)
        {
            Navigation = navigation;
            Title = "Manual";
        }
        #endregion
        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set { SetProperty(ref _Texto, value); }
        }
        #endregion
        #region PROCESOS
        public async Task Perfil()
        {
         
        }
        public async Task Volver()
        {
            
        }
        #endregion
        #region COMANDOS
        public ICommand Perfilcomand => new Command(async () => await Perfil());
        public ICommand Volvercomand => new Command(async () => await Volver());
        #endregion

    }
}