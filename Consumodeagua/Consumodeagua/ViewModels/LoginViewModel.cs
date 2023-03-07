using Consumodeagua.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Consumodeagua.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(UsuarioPrincipal_SensordeFlujo)}");
        }

        #region VARIABLES
        string _Texto;
        #endregion
        #region CONSTRUCTOR
        public LoginViewModel(INavigation navigation)
        {
            Navigation = navigation;
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
        private async Task Login()
        {

        }
        public async Task Volver()
        {

        }
        #endregion
        #region COMANDOS
        public ICommand Logincomand => new Command(async () => await Login());
        public ICommand Volvercomand => new Command(async () => await Volver());
        #endregion

    }
}
