using Consumodeagua.Services;
using Consumodeagua.ViewModels;
using Consumodeagua.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Consumodeagua
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            var instacelogout = new UserService();
            await instacelogout.LogoutAsync();
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
