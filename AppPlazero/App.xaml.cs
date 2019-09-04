using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppPlazero.Services;
using AppPlazero.Views;

namespace AppPlazero
{
    public partial class App : Application
    {
        public static bool IsUserLoggedIn { get; set; }
        public static ProductoItemManager TodoManager { get; private set; }
        public App()
        {
            TodoManager = new ProductoItemManager(new RestService());

            if (!IsUserLoggedIn)
                MainPage = new NavigationPage(new LoginPage());
            else
                Application.Current.MainPage = new AppShell();
        }



        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
