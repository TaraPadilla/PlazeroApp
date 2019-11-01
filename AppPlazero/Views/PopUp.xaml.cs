using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppPlazero.Models;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace AppPlazero.Views

{
    public partial class PopUp //: PopupPage
    {
        Producto detalleIngreso; 
        public PopUp(Producto item)
        {
            InitializeComponent();
            detalleIngreso = item;
        }
       
        [Obsolete]
        private async void agregarDetalle(object sender, EventArgs e)
        {
            detalleCarro.agregarItem(detalleIngreso);
            await PopupNavigation.Instance.PopAsync();

        }
    }
}