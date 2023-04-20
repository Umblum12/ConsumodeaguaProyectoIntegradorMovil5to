using Consumodeagua.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Consumodeagua.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(Name), "name")]
    [QueryProperty(nameof(Uid), "uid")]
    public partial class UsuarioPrincipal_SensordeFlujo : ContentPage
    {

        public UsuarioPrincipal_SensordeFlujo()
        {

            InitializeComponent();
            BindingContext = new UsuarioPrincipal_SensordeFlujoViewModel(Navigation);
            string savedUsername = Preferences.Get("username", ""); // Recupera el nombre de la caché
            perfil.Text = savedUsername; // Establece el nombre en el Label
        }
        public string Name
        {
            set
            {
                LoadDatos(value);
            }
        }
        public string Uid
        {
            set
            {
                LoadDatos(value);
            }
        }
        void LoadDatos(string name)
        {
            try
            {
                perfil.Text = name;
                Preferences.Set("username", name); // Guarda el nombre en la caché
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load user.");
            }
        }
    }

}

