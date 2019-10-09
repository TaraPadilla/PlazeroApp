using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AppPlazero.ViewModels
{
    class IProducto : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
