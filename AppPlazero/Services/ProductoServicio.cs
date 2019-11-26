using AppPlazero.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AppPlazero.Services
{
    class ProductoServicio
    {
        public ObservableCollection<ProductoModel> CollectProductsService { get; set; }
        public ProductoServicio()
        {  if (CollectProductsService == null)
           {
             CollectProductsService = new ObservableCollection<ProductoModel>();
           }
        }

        public ObservableCollection<ProductoModel> Consultar()
        {
            return CollectProductsService;
        }

        public void Guardar (ProductoModel item)
        {
            CollectProductsService.Add(item);
        }
        public void Modificar(ProductoModel item)
        {   for (int i = 0; i < CollectProductsService.Count; i++)
            {
                if (CollectProductsService[i].Id == item.Id)
                {
                    CollectProductsService[i] = item;
                }
            }
        }
        public void Eliminar(int Id)
        {
            ProductoModel modelo = CollectProductsService.FirstOrDefault(p => p.Id == Id); //Buscar el objeto que corresponde.
            CollectProductsService.Remove(modelo);
        }
    }
}
