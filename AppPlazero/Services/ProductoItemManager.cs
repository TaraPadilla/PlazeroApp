using AppPlazero.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public Task<ObservableCollection<Producto>> GetTasksAsync()
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

        public Task<User> ValidarLogin(User usuario)
        {
            return restService.ValidarLogin(usuario);
        }

        public Task<ObservableCollection<Income>> RefreshIncome()
        {
            return restService.RefreshIncome();
        }
        public Task<ObservableCollection<detailsIncome>> RefreshListDetailIncome(Income IngresoHeader)
        {
           return restService.RefreshListDetailIncome(IngresoHeader);
        }
    }
}
