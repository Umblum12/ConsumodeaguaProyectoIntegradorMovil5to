using Consumodeagua.Views;
using Consumodeagua.VistaModelo;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Consumodeagua.ViewModels
{
    public class PerfilViewModel : BaseViewModel
    {
        public Command Cerrarsesioncomand { get; }
        public PerfilViewModel()
        {
            Title = "Perfil";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
            Cerrarsesioncomand = new Command(OnLoginClicked);
        }
        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

        public ICommand OpenWebCommand { get; }
    }
}