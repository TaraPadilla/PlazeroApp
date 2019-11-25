using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AppPlazero.Models
{
    class ProductoModel : INotifyPropertyChanged
    {
        private string pro_sDescripcion;
        public string Nombre
        {
            get { return pro_sDescripcion; }
            set { pro_sDescripcion = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Mensaje)); //Cuando modifica el nombre se cambia el mensaje.
                }
        }

        private int pro_fCantidadAct;
        public int CantidadActual
        {
            get { return pro_fCantidadAct; }
            set { pro_fCantidadAct = value;
                  OnPropertyChanged();
            }
        }

        private int pro_nidUnidadBase;
        public int UnidadBase
        {
            get { return pro_nidUnidadBase; }
            set {
                pro_nidUnidadBase = value;
                OnPropertyChanged();
            }
        }

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

        private string mensaje;
        public string Mensaje
        {
            get { 
                return $"El producto {Nombre} tiene {CantidadActual} en stock.";}
        }

        private bool isBusy = false;
        public  bool IsBusy
        {
            get { return isBusy = false; }
            set { isBusy = value;
                OnPropertyChanged();
                }
        }
    }
}
