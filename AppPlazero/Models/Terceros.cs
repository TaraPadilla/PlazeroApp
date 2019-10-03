using System;
using System.Collections.Generic;
using System.Text;
using J = Newtonsoft.Json.JsonPropertyAttribute;

namespace AppPlazero.Models
{
    public class User
    {
        [J("bolAcceso")] private string Acceso;
        [J("rh_nidTercero")] private int Id;
        [J("rh_fechaCreacion")] private DateTime Creacion;
        [J("rh_sUsuario")] public string Username;
        [J("rh_sPassword")] public string Password;

        public Boolean EsHabilitado()
        {
           return Acceso.Equals("1") ? true : false;
        }

    }
}
