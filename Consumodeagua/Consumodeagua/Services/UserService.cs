using Consumodeagua.Config;
using Firebase.Auth;
using FirebaseAdmin.Auth;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Consumodeagua.VistaModelo;

namespace Consumodeagua.Services
{
    public class UserService: BaseViewModel
    {
        // Declaración de variables
        private static FirebaseAuthClient _firebaseAuth; // Instancia de FirebaseAuth
        private Firebase.Auth.UserCredential userCredential;// Credenciales de usuario
        private string token; // Token de autenticación
        


        // Método para obtener la instancia de FirebaseAuth
        public static FirebaseAuthClient FirebaseAuthInstance
        {
            // Getter
            get
            {
                // Comprueba si la instancia de FirebaseAuth es nula y la crea si es así
                if (_firebaseAuth == null)
                {
                    _firebaseAuth = new FirebaseAuthClient(FirebaseConfig.AuthConfig); // Crea la instancia de FirebaseAuth
                }
                return _firebaseAuth; // Regresa la instancia de FirebaseAuth
            }
        }

        // Método para iniciar sesión con correo y contraseña utilizando Firebase Auth
        public async Task<bool> LoginAsync(string email, string password)
        {
                // Bloque try-catch para evitar errores
                try
                {

                    // Inicia sesión con el correo y contraseña
                    userCredential = await FirebaseAuthInstance.SignInWithEmailAndPasswordAsync(email, password);
                    var user = userCredential.User; // Obtiene el usuario logueado
                    token = await user.GetIdTokenAsync(); // Obtiene el token de autenticación

                    return true; // Regresa true si el inicio de sesión fue exitoso
                }
                catch (Exception ex)
                {
                    // Muestra un mensaje de alerta con el error
                    await App.Current.MainPage.DisplayAlert("Error", "Error al iniciar sesión", "OK");
                    return false; // Regresa false si el inicio de sesión no fue exitoso
                }
        }
        public async Task<bool> LogoutAsync()
        {
                // Bloque try-catch para evitar errores
                try
                {

                // Cierra sesión con el correo y contraseña
                FirebaseAuthInstance.SignOut();
                return true; // Regresa true si cerrado de sesión fue exitoso
                }
                catch (Exception ex)
                {
                    // Muestra un mensaje de alerta con el error
                    await App.Current.MainPage.DisplayAlert("Error", "Error al cerrar sesión", "OK");
                    return false; // Regresa false si el inicio de sesión no fue exitoso
                }
        }
        public async Task ResetPasswordAsync(string email)
        {
                // Bloque try-catch para evitar errores
                try
                {

                // Cierra sesión con el correo y contraseña
                await FirebaseAuthInstance.ResetEmailPasswordAsync(email);
                }
                catch (Exception ex)
                {
                    // Muestra un mensaje de alerta con el error
                    await App.Current.MainPage.DisplayAlert("Error", "Error al cerrar sesión", "OK");
                }
        }

        // Método para obtener el usuario actual logueado
        public async Task<User> GetCurrentUserAsync()
        {
            // Bloque try-catch para evitar errores
            try
            {
                // Variables del usuario logueado
                var user = userCredential.User;
                var uid = user.Uid;
                var name = user.Info.DisplayName;

                return user; // Regresa el usuario logueado
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alerta", ex.Message, "OK");
                return null; // Si no hay usuario logueado, regresa null
            }
        }
        public async Task<User> RegisterAsync(string email, string password, string name)
        {
            try
            {
                var authResult = await FirebaseAuthInstance.CreateUserWithEmailAndPasswordAsync(email, password, name);
                var user = authResult.User;
                return user;
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                return null;
            }
        }
    }
}
