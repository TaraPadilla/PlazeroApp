using System;
using System.Collections.Generic;
using System.Text;
using J = Newtonsoft.Json.JsonPropertyAttribute;

namespace AppPlazero.Models
{
    public class Income
    {
        [J("ing_nidIngreso")] private int IdIngreso;
        [J("Nombre")] public string Nombre;
        [J("Fecha")] public DateTime Fecha;
        [J("Total")] public double Total;
        [J("ing_sRefDocumento")] public string refDocumento;    
    }
}
