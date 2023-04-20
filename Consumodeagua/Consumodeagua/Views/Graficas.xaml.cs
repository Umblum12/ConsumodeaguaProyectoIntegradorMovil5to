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
            webViewPage.Source = " https://graficasflujoyvalvula.web.app";
        }

        private void webViewPage_Navigated(object sender, WebNavigatedEventArgs e)
        {
            activity.IsVisible = false;
            activity.IsRunning = false;
        }

        private void webViewPage_Navigating(object sender, WebNavigatingEventArgs e)
        {
            activity.IsVisible = true;
            activity.IsRunning = true;
        }
    }
}