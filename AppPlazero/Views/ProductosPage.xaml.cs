using System;
using System.Linq;
using Xamarin.Forms;

using AppPlazero.Models;

namespace AppPlazero.Views
{
    public partial class ProductosPage : ContentPage
    {
        public ProductosPage()
        {
            InitializeComponent();
            Title = "Nuevo Titulo";
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Producto;
            if (item == null)
                return;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }

        void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Opcion Uno funcional de selección
            var item = e.CurrentSelection.FirstOrDefault() as Producto;
            if (item == null)
                return;
        }

        async void OnAgregarProductoClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ItemDetailPage());
        }
    }
}