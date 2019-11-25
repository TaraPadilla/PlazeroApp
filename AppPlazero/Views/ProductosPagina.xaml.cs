using AppPlazero.Models;
using AppPlazero.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPlazero.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductosPagina : ContentPage
    {
        ProductsViewModel contexto = new ProductsViewModel();
        public ProductosPagina()
        {
            InitializeComponent();
            BindingContext = contexto;
            LvPersonas.ItemSelected += LvPersonas_ItemSelected;
        }

        private void LvPersonas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                ProductoModel modelo = (ProductoModel)e.SelectedItem;
                contexto.Nombre = modelo.Nombre;
            }
        }
    }
}