using System;

using AppPlazero.Models;

namespace AppPlazero.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Producto Item { get; set; }
        public ItemDetailViewModel(Producto item = null)
        {
            Title = item?.Title;
            Item = item;
        }
    }
}
