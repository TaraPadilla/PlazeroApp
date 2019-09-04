using System;
using Xamarin.Forms;
using AppPlazero.Models;

namespace AppPlazero.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new Producto();
        }

        async void OnGuardarClicked(object sender, EventArgs e)
        {
            var ProductoItem = (Producto)BindingContext;
            await App.TodoManager.SaveTaskAsync(ProductoItem, true);
            await Navigation.PopAsync();

        }
    }
}