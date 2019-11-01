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
    public partial class caruselProducts : ContentView
    {
        Producto currentItem;
        public caruselProducts()
        {
            InitializeComponent();
            Cargar();
        }
         
        public async void Cargar()
        {
            caruselProductos.ItemsSource = await App.TodoManager.GetTasksAsync();
        }
        void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
            var imageSender = (Image)sender;
            imageSender.Source = "~/Resources/drawable/corporate.png";            
        }

        [Obsolete]
        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentItem = (e.CurrentSelection.FirstOrDefault() as Producto);

            if (currentItem == null)
                return;

            var pr = new PopUp(currentItem);
            var scaleAnimation = new ScaleAnimation
            {
                PositionIn = MoveAnimationOptions.Right,
                PositionOut = MoveAnimationOptions.Left
            };

            pr.Animation = scaleAnimation;
            await PopupNavigation.PushAsync(pr);
            
            ((CollectionView)sender).SelectedItem = null;           
        }       
    }
}