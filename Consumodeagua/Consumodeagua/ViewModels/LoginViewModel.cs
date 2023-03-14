using Consumodeagua.Views;
using Consumodeagua.VistaModelo;
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
        public LoginViewModel()
        {
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
            set { SetValue(ref _Texto, value); }
        }
        #endregion
        #region PROCESOS
        private async Task OnLoginClicked()
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(UsuarioPrincipal_SensordeFlujo)}");
        }

        private async Task OnRegisterClicked()
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(RegisterPage)}");
        }
        #endregion
        #region COMANDOS
        public ICommand LoginCommand => new Command(async () => await OnLoginClicked());
        public ICommand RegisterCommand => new Command(async () => await OnRegisterClicked());

        #endregion

    }
}
