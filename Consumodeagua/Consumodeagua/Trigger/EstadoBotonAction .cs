using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Consumodeagua.Trigger
{
    public class EstadoBotonAction : TriggerAction<Button>
    {
        public string Estado { get; set; }
        protected override void Invoke(Button button)
        {
            if (Estado == "abrir")
            {
                button.Text = "cerrar";
                button.BackgroundColor = Color.Red;
            }
            else if (Estado == "cerrar")
            {
                button.Text = "abrir";
                button.BackgroundColor = Color.Green;
            }
        }
    }
}
