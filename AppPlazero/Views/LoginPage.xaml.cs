using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppPlazero.Models;

namespace AppPlazero.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            usernameEntry.Text = "x";
            passwordEntry.Text = "1";
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
                App.IsUserLoggedIn = true;
                /* "https://stackoverflow.com/questions/54586621/whats-the-correct-way-to-implement-login-page-in-xamarin-shell" */
                Application.Current.MainPage = new AppShell();
                await Navigation.PopAsync();
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