using Consumodeagua.Data;
using Consumodeagua.Models;
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
        public RegisterViewModel()
        {
            
        }

        #region VARIABLES
        string _TxtNombre;
        string _TxtApellidoPaterno;
        string _TxtApellidoMaterno;
        string _TxtDireccion;
        string _TxtCorreoElectronico;
        DateTime _DatFechaNacimiento;
        string _TxtContrasena;
        string _TxtConfirmarContrasena;
        #endregion
        #region CONSTRUCTOR
        public RegisterViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region OBJETOS
        public string TxtNombre
        {
            get { return _TxtNombre; }
            set { SetProperty(ref _TxtNombre, value); }
        }
        public string TxtApellidoPaterno
        {
            get { return _TxtApellidoPaterno; }
            set { SetProperty(ref _TxtApellidoPaterno, value); }
        }
        public string TxtApellidoMaterno
        {
            get { return _TxtApellidoMaterno; }
            set { SetProperty(ref _TxtApellidoMaterno, value); }
        }
        public string TxtDireccion
        {
            get { return _TxtDireccion; }
            set { SetProperty(ref _TxtDireccion, value); }
        }
        public string TxtCorreoElectronico
        {
            get { return _TxtCorreoElectronico; }
            set { SetProperty(ref _TxtCorreoElectronico, value); }
        }
        public DateTime DatFechaNacimiento
        {
            get { return _DatFechaNacimiento; }
            set { SetProperty(ref _DatFechaNacimiento, value); }
        }
        public string TxtContrasena
        {
            get { return _TxtContrasena; }
            set { SetProperty(ref _TxtContrasena, value); }
        }
        public string TxtConfirmarContrasena
        {
            get { return _TxtConfirmarContrasena; }
            set { SetProperty(ref _TxtConfirmarContrasena, value); }
        }
        #endregion
        #region PROCESOS
        public async Task InsertarUsu()
        {
           
            var funcion = new DUsuario();
            var parametros = new MUsuario();
            if (TxtNombre == null || TxtApellidoPaterno == null || TxtApellidoMaterno == null || TxtDireccion == null || TxtCorreoElectronico == null || DatFechaNacimiento == null || TxtContrasena == null)
            {
                await DisplayAlert("Registro Fallido", "El usuario se no se pudo registrar, no deje los campos vacios", "Continuar");
            }
            else
            {
                parametros.Nombre = TxtNombre;
                parametros.ApellidoPaterno = TxtApellidoPaterno;
                parametros.ApellidoMaterno = TxtApellidoMaterno;
                parametros.Direccion = TxtDireccion;
                parametros.CorreoElectronico = TxtCorreoElectronico;
                parametros.FechaNacimiento = DatFechaNacimiento;
                parametros.Contrasena = TxtContrasena;

                await funcion.InsertarUsuario(parametros);
                await DisplayAlert("Registro Exitoso", "El usuario se registro exitosamente", "Continuar");
                await OnVolverLoginClicked();
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
        public ICommand InsertarUsuCommand => new Command(async () => await InsertarUsu());
        #endregion

    }
}
