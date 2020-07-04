using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversidadContoso.Models
{
    public class Departamento
    {
        [Key] public int ID_Depto { get; set; }
        public string Titulo_Depto { get; set; }
        public string Descripcion_Depto { get; set; }


    }
}