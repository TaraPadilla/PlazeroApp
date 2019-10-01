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
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public MainPage()
        {
            InitializeComponent();

            Items = new ObservableCollection<string>
            {
                "Item 1",
                "Item 2",
                "Item 3",
                "Item 4",
                "Item 5"
            };

            MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

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
