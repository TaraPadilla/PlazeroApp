using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppPlazero.Models;
using AppPlazero.ViewModels;

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