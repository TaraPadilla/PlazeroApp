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
        public string Nombre
        {
            get => pro_sDescripcion;
            set => pro_sDescripcion = value;
        }

        public Int32 pro_fCantidadAct { get; set; }
        public Int32 pro_nidUnidadBase { get; set; }
    }
}

