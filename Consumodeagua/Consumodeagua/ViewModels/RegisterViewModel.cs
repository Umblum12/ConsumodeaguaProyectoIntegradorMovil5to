using Consumodeagua.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Consumodeagua.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {

        public Command VolverLoginCommand { get; }

        public RegisterViewModel()
        {
            VolverLoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

        #region VARIABLES
        string _Texto;
        #endregion
        #region CONSTRUCTOR
        public RegisterViewModel(INavigation navigation)
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
