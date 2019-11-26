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
            CollectionProductos.SelectionChanged += OnCollectionViewSelectionChanged;
        }

        private void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                ProductoModel modelo = (ProductoModel)e.CurrentSelection;
                contexto.Nombre = modelo.Nombre;
            }

        }
    }
}