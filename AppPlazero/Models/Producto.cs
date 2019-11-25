using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace AppPlazero.Models
{
    public class Producto : INotifyPropertyChanged
    {
        private string pro_sDescripcion;
        [JsonProperty("pro_sDescripcion")]
        public string Nombre
        {
            get => pro_sDescripcion;
            set
            {
                if (Nombre != value)
                {
                    pro_sDescripcion = value;
                    OnPropertyChanged("nombre");
                }
            }
        }

        public Int32 Pro_fCantidadAct { get; set; }
        public string Pro_sEstado { get; set; }
        public Int32 Pro_nidUnidadBase { get; set; }

        private string pro_sImagen;
        [JsonProperty("pro_sProductoRuta")]

        public string Ruta
        {
            get
            {
                return pro_sImagen;
            } 
            set
            {
                pro_sImagen = value;
            }
        }

        private Xamarin.Forms.ImageSource image;
        public Xamarin.Forms.ImageSource Image
        {
            get
            {
                if (image == null)
                {
                    image = Xamarin.Forms.ImageSource.FromStream(
                        () => new MemoryStream(Convert.FromBase64String(Ruta)));
                }
                return image;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string Propiedad)
        {
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Propiedad));
        }
    }
}


