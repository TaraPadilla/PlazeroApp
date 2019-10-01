using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppPlazero.Models;
using Newtonsoft.Json;

namespace AppPlazero.Views
{
   
    public partial class LoginPage : ContentPage
    {
        private User UsuarioActivo;
        public LoginPage()
        {
            InitializeComponent();
            usernameEntry.Text = "x";
            passwordEntry.Text = "1";
            CargarInicio();
        }

        async void CargarInicio()
        {
            if (App.Current.Properties.ContainsKey("UsuarioActivo"))
            {
                App.strUsuario = App.Current.Properties["UsuarioActivo"] as string;
                UsuarioActivo = JsonConvert.DeserializeObject<User>(App.strUsuario);
            }
            else
            {
                App.strUsuario = JsonConvert.SerializeObject(UsuarioActivo);
                App.Current.Properties.Add("UsuarioActivo", App.strUsuario);
            }

            if (!(UsuarioActivo is null))
            {
                Shell.SetFlyoutBehavior(AppShell.Current.FlyoutBehavior, "false");
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
                    App.strUsuario = JsonConvert.SerializeObject(user);
                    Application.Current.Properties["UsuarioActivo"] = App.strUsuario;
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

        private void OnSignUpButtonClicked(object sender, EventArgs e)
        {

        }
    }
}