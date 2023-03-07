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
    public partial class UsuarioPrincipal_SensordeFlujo : ContentPage
    {
        public UsuarioPrincipal_SensordeFlujo()
        {
            InitializeComponent();
            BindingContext = new UsuarioPrincipal_SensordeFlujoViewModel(Navigation);
        }
    }
}