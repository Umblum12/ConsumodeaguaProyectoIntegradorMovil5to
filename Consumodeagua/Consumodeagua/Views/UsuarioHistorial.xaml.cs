using Consumodeagua.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Consumodeagua.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsuarioHistorial : ContentPage
    {
        UsuarioHistorialViewModel vm;
        public UsuarioHistorial()
        {
            vm = new UsuarioHistorialViewModel(Navigation);
            InitializeComponent();
            BindingContext = vm;
            this.Appearing += UsuarioHistorial_Appearing;
        }

        private void UsuarioHistorial_Appearing(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}