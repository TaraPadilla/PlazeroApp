using AppPlazero.Views;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AppPlazero
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        Dictionary<string, Type> routes = new Dictionary<string, Type>();
        public AppShell()
        {
           InitializeComponent();
           RegisterRoutes();
        }

        void RegisterRoutes()
        {
            routes.Add("catdetails", typeof(ItemDetailPage));
        }
    }
}
