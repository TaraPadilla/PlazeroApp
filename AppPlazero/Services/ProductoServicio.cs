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
        public ObservableCollection<ProductoModel> Productos { get; set; }
        public ProductoServicio()
        {
            if (Productos == null)
            {
                Productos = new ObservableCollection<ProductoModel>();
            }
        }

        public ObservableCollection<ProductoModel> Consultar()
        {
            return Productos;
        }

        public void Guardar (ProductoModel item)
        {
            Productos.Add(item);
        }
        public void Modificar(ProductoModel item)
        {
            for (int i = 0; i < Productos.Count; i++)
            {
                if (Productos[i].Nombre == item.Nombre)
                {
                    Productos[i] = item;
                }
            }
        }

        public void Eliminar(string Nombre)
        {
            ProductoModel modelo = Productos.FirstOrDefault(p => p.Nombre == Nombre); //Buscar el objeto que corresponde.
        }
    }
}
