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
        private Int32 IdIngreso; 

        [JsonProperty("Nombre")]
        public string Nombre { get; set; }

        [JsonProperty("ing_fFechaIngreso")]
        public DateTime FechaIngreso { get; set; }

        [JsonProperty("ing_fCostoTotal")]
        public  float CostoTotal { get; set; }

        [JsonProperty("ing_sRefDocumento")]
        public string Documento { get; set; }

        //[{"ing_nidIngreso":"1","Nombre":"DAVID CAMPOS","Fecha":"2019-10-11 11:47:29",
        //    "Total":"155500","ing_sRefDocumento":"Recibo de caja"}]

    }
}
