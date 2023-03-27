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
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
        }

        #region VARIABLES
        string _Texto;
        string _Nombre;
        string _Contrasena;
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
        public string Nombre
        {
            get { return _Nombre; }
            set { SetValue(ref _Nombre, value); }
        }
        public string Contrasena
        {
            get { return _Contrasena; }
            set { SetValue(ref _Contrasena, value); }
        }
        #endregion
        #region PROCESOS
        private async Task OnLoginClicked()
        {
            var InstanciaLoginAuth = new UserService();
            var LoginAuth = await InstanciaLoginAuth.LoginAsync(Nombre, Contrasena);
            if (LoginAuth)
            {
                await Shell.Current.GoToAsync($"//{nameof(UsuarioPrincipal_SensordeFlujo)}");
                var currentUser = await InstanciaLoginAuth.GetCurrentUserAsync(); // Obtiene el usuario actual
                await Application.Current.MainPage.DisplayAlert("Bienvenido", $"¡Hola {currentUser.Info.DisplayName}!", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Usuario o contraseña Incorrectos", "OK");
            }
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
