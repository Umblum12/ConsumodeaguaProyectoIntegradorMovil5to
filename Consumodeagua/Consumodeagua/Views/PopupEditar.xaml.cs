using Rg.Plugins.Popup.Extensions;
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
    public partial class PopupEditar : Rg.Plugins.Popup.Pages.PopupPage
    {
        public PopupEditar()
        {
            InitializeComponent();
        }
        private async void Cerrar_popup(object sender, EventArgs e)
        {
            await Navigation.PopAllPopupAsync();
        }
    }
}