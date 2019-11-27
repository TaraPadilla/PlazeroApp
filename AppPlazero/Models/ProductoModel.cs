using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace AppPlazero.Models
{
    class ProductoModel : INotifyPropertyChanged
    {
        [JsonProperty("pro_nidProducto")]
        private int pro_nidProducto;
        public int Id
        {
            get { return pro_nidProducto; }
            set { pro_nidProducto = value; }
        }

        [JsonProperty("pro_sDescripcion")]
        private string pro_sDescripcion;
        public string Nombre
        {
            get { return pro_sDescripcion; }
            set {
                pro_sDescripcion = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Mensaje)); //Cuando modifica el nombre se cambia el mensaje.
                }
        }

        [JsonProperty("pro_fCantidadAct")]
        private int pro_fCantidadAct;
        public int CantidadActual
        {
            get { return pro_fCantidadAct; }
            set { pro_fCantidadAct = value;
                  OnPropertyChanged();
            }
        }

        [JsonProperty("pro_nidUnidadBase")]
        private int pro_nidUnidadBase;
        public int UnidadBase
        {
            get { return pro_nidUnidadBase; }
            set {
                pro_nidUnidadBase = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("pro_sProductoRuta")]
        private string pro_sProductoRuta;

        private string Ruta
        {
            get { return pro_sProductoRuta; }
        }

        private Xamarin.Forms.ImageSource image;
        public Xamarin.Forms.ImageSource Image
        {
            get
            {
                image = Xamarin.Forms.ImageSource.FromStream(
                        () => new MemoryStream(Convert.FromBase64String(Ruta)));
                return image;
            }
        }

        [JsonProperty("pro_sEstado")]
        private char pro_sEstado;
        public char Estado
        {
            get { return pro_sEstado; }
            set { pro_sEstado = value;
                  OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string nombre="") //Called captura el nombre de la propiedad que lo invoco.
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }

        public string Mensaje
        {
            get {
                return $"Existencias: {CantidadActual} - {UnidadBase}.";}
        }

        private bool isBusy = false;
        public  bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value;
                OnPropertyChanged();
                }
        }
    }
}
