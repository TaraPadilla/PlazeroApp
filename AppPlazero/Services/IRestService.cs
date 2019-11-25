using AppPlazero.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace AppPlazero.Services
{
    public interface IRestService
    {
        Task<ObservableCollection<Producto>> RefreshDataAsync();
        Task SaveTodoItemAsync(Producto item, bool isNewItem);
        Task DeleteTodoItemAsync(string id);
        Task<User> ValidarLogin(User usuario);
        Task<ObservableCollection<Income>> RefreshIncome();
        Task<ObservableCollection<detailsIncome>> RefreshListDetailIncome(Income IngresoHeader);
        Task crearIngreso(Income Ingreso);
    }
}
