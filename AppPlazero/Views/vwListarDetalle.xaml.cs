using AppPlazero.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPlazero.Views
{
    public partial class vwListarDetalle : ContentPage
    {
        Income IngresoActual;
        public ObservableCollection<detailsIncome> DetailsIncome1 { get; private set; }
        public vwListarDetalle(Income IngresoActual)
        {
            InitializeComponent();
            this.IngresoActual = IngresoActual;
        }
        protected async override void OnAppearing()
        {
            CollectionListaDetalle.ItemsSource = await App.TodoManager.RefreshListDetailIncome(IngresoActual);
            base.OnAppearing();
        }

    }
}