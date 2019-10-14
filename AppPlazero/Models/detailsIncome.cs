using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppPlazero.Models
{
    public class detailsIncome
    {

            [JsonProperty("din_nidIngreso")]
            public Int32 IdDetalle { get; set; }

            [JsonProperty("pro_sDescripcion")]
            public string Descripcion { get; set; }

            [JsonProperty("din_fidCantidad")]
            public float Cantidad { get; set; }

            [JsonProperty("med_sDescripcion")]
            public string UnidadMedida { get; set; }

            [JsonProperty("din_dCosto")]
            public double Costo { get; set; }

            //[{"din_nidIngreso":"1","pro_sDescripcion":"ZANAHORIA","din_fidCantidad":"10",
            //"med_sDescripcion":"LIBRA(S)","din_dCosto":"50000"},]
    }
}
