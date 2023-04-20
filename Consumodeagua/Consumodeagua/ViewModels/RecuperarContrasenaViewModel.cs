using Consumodeagua.Services;
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
    public class RecuperarContrasenaViewModel :BaseViewModel
    {
        public RecuperarContrasenaViewModel()
        {
        }
        #region VARIABLES
        string _Texto;
        string _Email;
        #endregion
        #region CONSTRUCTOR
        public RecuperarContrasenaViewModel(INavigation navigation)
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
        public string Email
        {
            get { return _Email; }
            set { SetValue(ref _Email, value); }
        }
        #endregion
        #region PROCESOS
        private async Task OnResetPasswordClicked()
        {
            var InstanciaAuth = new UserService();
            if (!string.IsNullOrEmpty(Email))
            {
                await InstanciaAuth.ResetPasswordAsync(Email);
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "No se puede dejar Usuario o contraseña vacios", "OK");
            }
        }
        private async Task OnVolverLoginClicked()
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
        #endregion
        #region COMANDOS
        public ICommand VolverLoginCommand => new Command(async () => await OnVolverLoginClicked());
        public ICommand ResetPasswordCommand => new Command(async () => await OnResetPasswordClicked());
        #endregion
    }
}