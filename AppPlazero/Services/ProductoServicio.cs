using AppPlazero.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppPlazero.Services
{
    class ProductoServicio
    {
        private ObservableCollection<ProductoModel> CollectProductsService { get; set; }
        
        static readonly HttpClient client = new HttpClient();
        public ProductoServicio()
        {  if (CollectProductsService == null)
           {
             CollectProductsService = new ObservableCollection<ProductoModel>();
           }
        }

        public async Task<ObservableCollection<ProductoModel>> Consultar()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://plazeroapp.solucionespadilla.com/producto.php");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                CollectProductsService = JsonConvert.DeserializeObject<ObservableCollection<ProductoModel>>(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return CollectProductsService;
        }

        public void Guardar (ProductoModel item)
        {
            CollectProductsService.Add(item);
        }
        public void Modificar(ProductoModel item)
        {   
            for (int i = 0; i < CollectProductsService.Count; i++)
            {
                if (CollectProductsService[i].Id == item.Id)
                {
                    CollectProductsService[i] = item;
                }
            }
        }
        public void Eliminar(int Id)
        {
            ProductoModel modelo = CollectProductsService.FirstOrDefault(p => p.Id == Id);
            CollectProductsService.Remove(modelo);
        }
    }
}
