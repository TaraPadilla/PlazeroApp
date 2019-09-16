using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppPlazero.Models;

namespace AppPlazero.Views
{
    public partial class MyViewModel : ContentView
    {
        public MyViewModel()
        {
            InitializeComponent();
            this.BindingContext = new ViewModel();
        }
    }
}