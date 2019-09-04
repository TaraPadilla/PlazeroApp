using AppPlazero.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppPlazero.Services
{
    public class ProductoItemManager
    {
        IRestService restService;
        public ProductoItemManager(IRestService service)
        {
            restService = service;
        }

        public Task<List<Producto>> GetTasksAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task SaveTaskAsync(Producto item, bool isNewItem = false)
        {
            return restService.SaveTodoItemAsync(item, isNewItem);
        }

        public Task DeleteTaskAsync(Producto item)
        {
            return restService.DeleteTodoItemAsync(item.Nombre);
        }

    }
}
