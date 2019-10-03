using AppPlazero.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppPlazero.Services
{
    public interface IRestService
    {
        Task<List<Producto>> RefreshDataAsync();
        Task SaveTodoItemAsync(Producto item, bool isNewItem);
        Task DeleteTodoItemAsync(string id);
        Task<User> ValidarLogin(User usuario);

    }
}
