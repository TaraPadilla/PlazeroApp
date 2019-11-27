using AppPlazero.Models;
using AppPlazero.ViewModels;
using System.Collections.ObjectModel;
using System.Linq;

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
            ViewCollecProductos.SelectionChanged += OnCollectionViewSelectionChanged;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            contexto.IsBusy = true;
            ViewCollecProductos.ItemsSource = await contexto.Consultar();
            contexto.IsBusy = false;
        }

        private void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                string current = (e.CurrentSelection.FirstOrDefault() as ProductoModel)?.Nombre;
                contexto.Nombre = current;
            }

        }
    }
}