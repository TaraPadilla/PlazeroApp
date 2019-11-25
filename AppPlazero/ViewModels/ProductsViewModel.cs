using AppPlazero.Models;
using AppPlazero.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppPlazero.ViewModels
{
    class ProductsViewModel : ProductoModel
    {
        public ObservableCollection<ProductoModel> Productos { get; set; }

        ProductoServicio servicio = new ProductoServicio();
        ProductoModel modelo;

        public ProductsViewModel()
        {
            Productos = servicio.Consultar();
            GuardarCommand = new Command(async()=>await Guardar().ConfigureAwait(true));
        }

        public Command GuardarCommand { get; set; }
        public Command ModificarCommand { get; set; }
        public Command EliminarCommand { get; set; }
        public Command LimpiarCommand { get; set; }

        private async Task Guardar()
        {
            modelo = new ProductoModel()
            {
                Nombre = Nombre
            };

            servicio.Guardar(modelo);
            await Task.Delay(2000).ConfigureAwait(true);
          
        }
    }
}
