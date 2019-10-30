using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Newtonsoft.Json;

namespace AppPlazero.Models
{
    public class Income 
    {
        [JsonProperty("ing_nidIngreso")]
        public Int32 IdIngreso { get; set; } 

        [JsonProperty("Nombre")]
        public string Nombre { get; set; }

        [JsonProperty("ing_fFechaIngreso")]
        public DateTime FechaIngreso { get; set; }

        [JsonProperty("ing_fCostoTotal")]
        public  double CostoTotal { get; set; }

        [JsonProperty("ing_sRefDocumento")]
        public string Documento { get; set; }

        List<Producto> DetalleIngreso = new List<Producto>();
    }   
}
