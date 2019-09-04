using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using AppPlazero.Models;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AppPlazero.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private const string Url = "http://plazeroapp.solucionespadilla.com/post.php"; //This url is a free public api intended for demos
        private readonly System.Net.Http.HttpClient _client = new HttpClient(); //Creating a new instance of HttpClient. (Microsoft.Net.Http)
        private ObservableCollection<Producto> _posts; //Refreshing the state of the UI in realtime when updating the ListView's Collection

        public Command LoadItemsCommand { get; set; }
        public ObservableCollection<Producto> Items { get; set; }
        
        public ItemsViewModel()
        {
            Title = "Productos";
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommandAsync());
            Items = _posts;

            /*
            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Item;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });*/
        }

        private async Task ExecuteLoadItemsCommandAsync()
        {

            if (IsBusy) return;
            IsBusy = true;

            try
            {
                string content = await _client.GetStringAsync(Url); //Sends a GET request to the specified Uri and returns the response body as a string in an asynchronous operation
                List<Producto> posts = JsonConvert.DeserializeObject<List<Producto>>(content); //Deserializes or converts JSON String into a collection of Post
                _posts = new ObservableCollection<Producto>(posts); //Converting the List to ObservalbleCollection of Post
                //ItemsListView.ItemsSource = _posts; //Assigning the ObservableCollection to MyListView in the XAML of this file
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);

                //foreach (var item in items)
                //{
                  //Items.Add(item);
                //}
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}