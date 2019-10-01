using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppPlazero.Models;
using Newtonsoft.Json;

namespace AppPlazero.Views
{
   
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            usernameEntry.Text = "x";
            passwordEntry.Text = "1";
            Constants.UsuarioActivo = new User();
            CargarInicio();
        }

        async void CargarInicio()
        {
            if (App.Current.Properties.ContainsKey("UsuarioActivo"))
            {
                Constants.strUsuario = App.Current.Properties["UsuarioActivo"] as string;
                Constants.UsuarioActivo = JsonConvert.DeserializeObject<User>(Constants.strUsuario);
            }
            else
            {
                Constants.strUsuario = JsonConvert.SerializeObject(Constants.UsuarioActivo);
                App.Current.Properties.Add("UsuarioActivo", Constants.strUsuario);
            }

            if (!(Constants.UsuarioActivo.Username is null))
            {
                AppShell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
                await Shell.Current.GoToAsync("//main");
            }
        }


        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var user = new User
            {
                Username = usernameEntry.Text,
                Password = passwordEntry.Text
            };

            var isValid = AreCredentialsCorrect(user);

            if (isValid)
            {
                if (Application.Current.Properties.ContainsKey("UsuarioActivo"))
                {
                    Constants.strUsuario = JsonConvert.SerializeObject(user);
                    Application.Current.Properties["UsuarioActivo"] = Constants.strUsuario;
                    AppShell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
                    await Shell.Current.GoToAsync("//main");
                }
            }
            else
            {
                messageLabel.Text = "Autentificación de usuario falló.";
                await DisplayAlert("Sorry", "Something went wrong in server.", "Ok");
                passwordEntry.Text = string.Empty;
            }
        }

        bool AreCredentialsCorrect(User user)
        {
            return user.Username == Constants.Username && user.Password == Constants.Password;
        }
    }
}