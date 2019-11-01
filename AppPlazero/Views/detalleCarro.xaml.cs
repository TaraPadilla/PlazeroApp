using AppPlazero.Models;
using Rg.Plugins.Popup.Animations;
using Rg.Plugins.Popup.Enums;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPlazero.Views
{
    public partial class detalleCarro : ContentView
    {
        public static ObservableCollection<Producto> CollectionCarrito { get; private set; }
        public detalleCarro()
        {
            InitializeComponent();
            CollectionCarrito = new ObservableCollection<Producto>();
            ViewDetalleCarro.ItemsSource = CollectionCarrito;
        }

        [Obsolete]
        public static void agregarItem(Producto item)
        {
            CollectionCarrito.Add(item);
        }
    }
}