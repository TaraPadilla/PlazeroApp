using System;
using Xamarin.Forms;
using AppPlazero.Models;

namespace AppPlazero.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        Producto ProductoItem;
        public ItemDetailPage()
        {
            InitializeComponent();
            ProductoItem = new Producto();
            //ProductoItem = (Producto)BindingContext;
            BindingContext = ProductoItem; // new Producto();
        }

        async void OnGuardarClicked(object sender, EventArgs e)
        {
            await App.TodoManager.SaveTaskAsync(ProductoItem, true);
            await Navigation.PopAsync();

        }

        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                ProductoItem.pro_nidUnidadBase = selectedIndex;
                //monkeyNameLabel.Text = picker.Items[selectedIndex];
            }
        }
    }
}