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
        public ObservableCollection<ProductoModel> CollecProductosView { get; set; }

        ProductoServicio servicioView = new ProductoServicio();
        ProductoModel modeloView;

        public ProductsViewModel()
        {
            GuardarCommand =   new Command(async()=>await Guardar(),()=> !IsBusy); 
            ModificarCommand = new Command(async () => await Modificar(), () => !IsBusy);
            EliminarCommand =  new Command(async () => await Eliminar(), () => !IsBusy);
            LimpiarCommand =   new Command(Limpiar, () => !IsBusy);
        }

        public async Task<ObservableCollection<ProductoModel>> Consultar()
        {
            CollecProductosView = await servicioView.Consultar();
            return CollecProductosView;
        }


        public Command GuardarCommand { get; set; }
        public Command ModificarCommand { get; set; }
        public Command EliminarCommand { get; set; }
        public Command LimpiarCommand { get; set; }

        private async Task Guardar()
        {
            IsBusy = true;
            Guid g = Guid.NewGuid();
            modeloView = new ProductoModel()
            {
                Nombre = this.Nombre
            };
            servicioView.Guardar(modeloView);
            await Task.Delay(2000);
            IsBusy = false;
        }

        private async Task Modificar()
        {
            IsBusy = true;

            modeloView = new ProductoModel()
            {
                Nombre = this.Nombre
            };

            servicioView.Modificar(modeloView);
            await Task.Delay(2000);
            IsBusy = false;
        }

        private async Task Eliminar()
        {
            IsBusy = true;
            servicioView.Eliminar(Id);
            await Task.Delay(2000);
            IsBusy = false;
        }

        private void Limpiar()
        {
            Nombre = "";
            CantidadActual = 0;
        }

    }
}
