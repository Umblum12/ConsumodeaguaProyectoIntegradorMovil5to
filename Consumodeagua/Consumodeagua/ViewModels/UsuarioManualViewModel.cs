using Consumodeagua.Views;
using Consumodeagua.VistaModelo;
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
        }

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
            set { SetValue(ref _Texto, value); }
        }
        #endregion
        #region PROCESOS
        private async Task OnPerfilClicked()
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