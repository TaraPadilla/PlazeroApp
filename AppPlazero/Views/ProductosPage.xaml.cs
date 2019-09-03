using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppPlazero.Models;
using AppPlazero.Views;
using AppPlazero.ViewModels;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Net.Http;

namespace AppPlazero.Views
{
    public partial class ProductosPage : ContentPage
    {
        ItemsViewModel viewModel;

        private const string Url = "http://plazeroapp.solucionespadilla.com/api/ingresos.php"; //This url is a free public api intended for demos
        private readonly System.Net.Http.HttpClient _client = new HttpClient(); //Creating a new instance of HttpClient. (Microsoft.Net.Http)
        private ObservableCollection<Producto> _posts; //Refreshing the state of the UI in realtime when updating the ListView's Collection

        public ProductosPage()
        {
            InitializeComponent();
            Title = "Nuevo Titulo";
            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Producto;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            //ItemsListView.SelectedItem = null;
        }
        protected override async void OnAppearing()
        {
            string content = await _client.GetStringAsync(Url); //Sends a GET request to the specified Uri and returns the response body as a string in an asynchronous operation
            List<Producto> posts = JsonConvert.DeserializeObject<List<Producto>>(content); //Deserializes or converts JSON String into a collection of Post
            _posts = new ObservableCollection<Producto>(posts); //Converting the List to ObservalbleCollection of Post
            CollectionProductos.ItemsSource = _posts; //Assigning the ObservableCollection to MyListView in the XAML of this file
            base.OnAppearing();

            //if (viewModel.Items.Count == 0)
              //  viewModel.LoadItemsCommand.Execute(null);
        }
        async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }

        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Opcion Uno funcional de selección
            var item = e.CurrentSelection.FirstOrDefault() as Producto;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            //Opcion Dos 
            //string catName = (e.CurrentSelection.FirstOrDefault() as Producto).Title;
            //await Shell.Current.GoToAsync($"catdetails?Title='{catName}'");
        }

        private void OnAddItemClicked(object sender, EventArgs e)
        {

        }
    }
}