using Consumodeagua.Data;
using Consumodeagua.Models;
using Consumodeagua.Views;
using Consumodeagua.VistaModelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
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
            set { SetValue(ref _TxtNombre, value); }
        }
        public string TxtApellidoPaterno
        {
            get { return _TxtApellidoPaterno; }
            set { SetValue(ref _TxtApellidoPaterno, value); }
        }
        public string TxtApellidoMaterno
        {
            get { return _TxtApellidoMaterno; }
            set { SetValue(ref _TxtApellidoMaterno, value); }
        }
        public string TxtDireccion
        {
            get { return _TxtDireccion; }
            set { SetValue(ref _TxtDireccion, value); }
        }
        public string TxtCorreoElectronico
        {
            get { return _TxtCorreoElectronico; }
            set { SetValue(ref _TxtCorreoElectronico, value); }
        }
        public DateTime DatFechaNacimiento
        {
            get { return _DatFechaNacimiento; }
            set { SetValue(ref _DatFechaNacimiento, value); }
        }
        public string TxtContrasena
        {
            get { return _TxtContrasena; }
            set { SetValue(ref _TxtContrasena, value); }
        }
        public string TxtConfirmarContrasena
        {
            get { return _TxtConfirmarContrasena; }
            set { SetValue(ref _TxtConfirmarContrasena, value); }
        }
        #endregion
        #region PROCESOS
        public async Task InsertarUsu()
        {

            var funcion = new DUsuario();
            var parametros = new MUsuario();
            if (string.IsNullOrEmpty(TxtNombre) || string.IsNullOrEmpty(TxtApellidoPaterno) || string.IsNullOrEmpty(TxtApellidoMaterno) || string.IsNullOrEmpty(TxtDireccion) || string.IsNullOrEmpty(TxtCorreoElectronico) ||DatFechaNacimiento == null || string.IsNullOrEmpty(TxtContrasena) || string.IsNullOrEmpty(TxtConfirmarContrasena))
            {
                await DisplayAlert("Error registro fallido", "El usuario se no se pudo registrar, ¡No se puede dejar los campos vacios!", "Continuar");
            }
            else if (!Regex.IsMatch(TxtNombre, @"^[a-zA-Z]+$") || TxtNombre.Length <= 3)
            {
                await DisplayAlert("Error registro fallido", "El usuario se no se pudo registrar, ¡No se puede dejar los campos vacios!", "Continuar");
            }
            else if (!Regex.IsMatch(TxtApellidoPaterno, @"^[a-zA-Z]+$") || TxtApellidoPaterno.Length <= 3)
            {
                await DisplayAlert("Error registro fallido", "El usuario se no se pudo registrar, ¡El apellido paterno no puede contener digitos y su longitud tiene que ser mayor de 3 caracteres!", "Continuar");
            }
            else if (!Regex.IsMatch(TxtApellidoMaterno, @"^[a-zA-Z]+$") || TxtApellidoMaterno.Length <= 3)
            {
                await DisplayAlert("Error registro fallido", "El usuario se no se pudo registrar, ¡El apellido materno no puede contener digitos y su longitud tiene que ser mayor de 3 caracteres!", "Continuar");
            }
            else if (!Regex.IsMatch(TxtDireccion, @"^[a-zA-Z]+$") || TxtDireccion.Length <= 3)
            {
                await DisplayAlert("Error registro fallido", "El usuario se no se pudo registrar, ¡La dirrección no puede contener digitos y su longitud tiene que ser mayor de 3 caracteres!", "Continuar");
            }
            else if (!Regex.IsMatch(TxtCorreoElectronico, @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$") || TxtCorreoElectronico.Length <= 3)
            {
                await DisplayAlert("Error registro fallido", "El usuario se no se pudo registrar, ¡Ingrese un correo electronico valido!", "Continuar");
            }
            else if (TxtContrasena != TxtConfirmarContrasena)
            {
                await DisplayAlert("Error registro fallido", "El usuario se no se pudo registrar, !Las contraseñas no coinciden¡", "Continuar");
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
                parametros.rol = "habitante";

                await funcion.InsertarRegUsuario(parametros);
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
