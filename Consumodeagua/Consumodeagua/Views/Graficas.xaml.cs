using SkiaSharp;
using Microcharts;
using Entry = Microcharts.ChartEntry;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microcharts.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using Consumodeagua.Data;
using System;
using System.Threading.Tasks;
using Consumodeagua.ViewModels;

namespace Consumodeagua.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Graficas : ContentPage
    {
        public Graficas()
        {
            InitializeComponent();
            BindingContext = new GraficasViewModel(Navigation);
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var funcion = new DSensorFlujo();
            var entries = new List<Entry>();
            while (true)
            {
                var flow = await funcion.GetFlowValueAsync();
                entries.Add(new Entry((float)flow)
                {
                    Label = DateTime.Now.ToString("hh:mm:ss"),
                    ValueLabel = flow.ToString(),
                    Color = SKColor.Parse("#FF0000")
                });
                chartView.Chart = new LineChart() { Entries = entries };
                await Task.Delay(5000);
            }
        }

    }
}