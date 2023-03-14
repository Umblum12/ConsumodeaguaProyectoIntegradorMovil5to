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
    public partial class Graficas : ContentPage
    {
        //ItemsViewModel _viewModel;
        public Graficas()
        {
            InitializeComponent();
            //webView.Source = "https://upload.wikimedia.org/wikipedia/es/timeline/6zswa00f78sek0xned6xv13ie6tq40i.png";
        }
    }
}