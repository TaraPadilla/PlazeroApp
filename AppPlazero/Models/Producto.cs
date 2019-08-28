using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppPlazero.Models
{
    public class Producto
    {

        // public string pro_nidProducto { get; set; }

        private string pro_sDescripcion;
        [JsonProperty("pro_sDescripcion")]
        public string Title
        {
            get => pro_sDescripcion;
            set
            {
                pro_sDescripcion = value;
                // OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
            }
        }


        public Int32 pro_fCantidadAct { get; set; }
        public Int32 pro_nidUnidadBase { get; set; }
    }
}

