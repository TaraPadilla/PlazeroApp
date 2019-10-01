using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppPlazero.Models
{
    public static class Constants
    {
        public static string BaseAddress = Device.RuntimePlatform == Device.Android ? "https://10.0.2.2:5001" : "https://localhost:5001";
        public static string TodoItemsUrl = "http://plazeroapp.solucionespadilla.com/api/ingresos.php";
        //public static string TodoItemsUrl = BaseAddress + "/api/todoitems/{0}";
        public static string Username = "x";
        public static string Password = "1";
    }
}
