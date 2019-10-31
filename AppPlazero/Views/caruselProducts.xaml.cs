using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPlazero.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class caruselProducts : ContentPage
    {
        int tapCount = 0;
        public caruselProducts()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            caruselProductos.ItemsSource = await App.TodoManager.GetTasksAsync();

        }

        void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
            //tapCount++;
            var imageSender = (Image)sender;
            // watch the monkey go from color to black&white!
            //if (tapCount % 2 == 0)
            {
                imageSender.Source = "~/Resources/drawable/corporate.png";
                tapCount = 0;
            }
            //else
            {
                //imageSender.Source = "tapped_bw.jpg";
            }
        }
    }
}