using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPlazero.Views
{
    public partial class HeaderIncome : ContentPage
    {
        public ObservableCollection<string> Incomes { get; set; }

        public HeaderIncome()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listIncome.ItemsSource = await App.TodoManager.RefreshIncome();
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

           
            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");
            ((ListView)sender).SelectedItem = null;
        }
    }
}
