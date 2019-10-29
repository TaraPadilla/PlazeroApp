using AppPlazero.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPlazero.Views
{
    public partial class Principal : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public Principal()
        {
            InitializeComponent();

            Items = new ObservableCollection<string>
            {
                "Noticia 1.",
                "Noticia 2.",
                "Noticia 3.",
            };

            MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Info adicional", "Información acerca de la nota", "OK");

            ((ListView)sender).SelectedItem = null;
        }

        async private void desloguearse(object sender, EventArgs e)
        {
            AppShell.Current.FlyoutBehavior = FlyoutBehavior.Disabled;
            if (Application.Current.Properties.ContainsKey("UsuarioActivo"))
            {
                Application.Current.Properties.Remove("UsuarioActivo");
            }
                await Shell.Current.GoToAsync("//login");
        }
    }
}
